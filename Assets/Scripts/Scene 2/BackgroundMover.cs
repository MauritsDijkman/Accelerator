using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private float X_Coordinate = -33.7f;
    private Vector3 spawnPosition;

    [SerializeField] private GameObject wall_1;
    [SerializeField] private GameObject wall_2;

    private void Start()
    {
        spawnPosition = wall_2.transform.position;
    }

    private void Update()
    {
        wall_1.transform.Translate(Vector3.right * Time.deltaTime * speed);
        wall_2.transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (wall_1.transform.position.x <= X_Coordinate)
            wall_1.transform.position = spawnPosition;

        if (wall_2.transform.position.x <= X_Coordinate)
            wall_2.transform.position = spawnPosition;
    }
}
