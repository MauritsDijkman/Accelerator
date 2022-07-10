using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [Header("Border")]
    [SerializeField] private float borderLeft;
    [SerializeField] private float borderRight;

    [Header("Phone sensitivity")]
    [SerializeField] private float sensitivity = 0.1f;

    [Header("Speed value")]
    [SerializeField] private float speed = 5f;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        HandelInput();
        CheckBorder();
    }

    private void HandelInput()
    {
        if (InputManager.instance.inputAcceleration.x > sensitivity)
            transform.Translate(Vector3.right * InputManager.instance.inputAcceleration.x * speed * Time.deltaTime);
        else if (InputManager.instance.inputAcceleration.x < sensitivity * -1)
            transform.Translate(Vector3.left * (InputManager.instance.inputAcceleration.x * -1) * speed * Time.deltaTime);
    }

    private void CheckBorder()
    {
        if (transform.position.x <= borderLeft)
            transform.position = new Vector3(borderLeft, originalPosition.y, 0);
        else if (transform.position.x >= borderRight)
            transform.position = new Vector3(borderRight, originalPosition.y, 0);
    }
}
