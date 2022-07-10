using UnityEngine;

public class Bouncher : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * speed);
    }
}
