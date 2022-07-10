using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float maxTime = 1;
    [SerializeField] private float timeTakenFromMaxTime = 0.1f;
    [SerializeField] private float timeBeforeDestroy = 5f;

    [Header("Prefab")]
    [SerializeField] private GameObject pipe;

    [Header("Other")]
    [SerializeField] private float height;
    [SerializeField] private int neededPointsForSpeedUpgrade = 5;

    private float timer = 0;

    [HideInInspector]
    public int localScore = 0;

    private void Start()
    {
        SpawnPipe();
        localScore = 0;
    }

    private void Update()
    {
        if (!GameManager_Level2.instance.isInputEnabled)
            return;

        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;

        HandleSpeeder();
    }

    private void SpawnPipe()
    {
        GameObject newPipe = Instantiate(pipe);
        newPipe.transform.parent = GameObject.Find("----- PipeList -----").transform;
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        Destroy(newPipe, timeBeforeDestroy);
    }

    private void HandleSpeeder()
    {
        if (maxTime <= 0.5f)
            return;

        if (localScore == neededPointsForSpeedUpgrade)
        {
            maxTime -= timeTakenFromMaxTime;
            localScore = 0;
        }
    }
}
