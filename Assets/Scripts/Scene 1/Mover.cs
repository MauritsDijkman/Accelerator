using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Direction")]
    [SerializeField] private bool right = false;
    [SerializeField] private bool left = false;
    [SerializeField] private bool up = false;
    [SerializeField] private bool down = false;

    [Header("Way of movement")]
    [SerializeField] private bool addForce = true;
    [SerializeField] private bool translate = false;

    [Header("Speed")]
    [SerializeField] private float speed = 10f;

    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (addForce)
        {
            float maxSpeed = 10;
            rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxSpeed);

            if (right)
                rig.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.Acceleration);
            else if (left)
                rig.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode.Acceleration);
            else if (up)
                rig.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode.Acceleration);
            else if (down)
                rig.AddForce(Vector3.down * speed * Time.deltaTime, ForceMode.Acceleration);
        }
        else if (translate)
        {
            if (right)
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            else if (left)
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            else if (up)
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            else if (down)
                transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            rig.AddForce(Vector3.up * 100);
        }


    }
}
