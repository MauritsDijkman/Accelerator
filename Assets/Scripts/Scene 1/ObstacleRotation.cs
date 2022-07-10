using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float speed = 30f;

    [Header("Phone sensitivity")]
    [SerializeField] private float sensitivity = 0.1f;

    private void Update()
    {
        if (InputManager.instance.inputAcceleration.x < sensitivity * -1)
            transform.Rotate(new Vector3(0, 0, 1) * (InputManager.instance.inputAcceleration.x * -1) * speed * Time.deltaTime);
        else if (InputManager.instance.inputAcceleration.x > sensitivity)
            transform.Rotate(new Vector3(0, 0, -1) * InputManager.instance.inputAcceleration.x * speed * Time.deltaTime);
    }
}
