using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private GameObject wall;

    private void Start()
    {
        if (wall.activeSelf)
            wall.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!wall.activeSelf)
                wall.SetActive(true);
        }
    }
}
