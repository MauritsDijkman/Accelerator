using UnityEngine;

public class PlayerController_PipeLevel : MonoBehaviour
{
    // Move object using accelerometer
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private Transform topPosition;
    [SerializeField] private Transform bottomPosition;

    private float positiveInputValue = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Pipe"))
        {
            GameManager_Level2.instance.GameOver();
            Debug.Log("Player hit pipe");
        }
        else if (collision.transform.CompareTag("Border"))
        {
            GameManager_Level2.instance.GameOver();
            Debug.Log("Player hit border");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PipeScore"))
            CanvasHandler.instance.AddScore(1);
    }

    private void Update()
    {
        if (!GameManager_Level2.instance.isInputEnabled)
            return;

        //OldInputFunction();
        NewInputMethod();
    }

    private void NewInputMethod()
    {
        positiveInputValue = InputManager.instance.inputAcceleration.z;

        if (positiveInputValue < 0)
            positiveInputValue *= -1;

        if (InputManager.instance.inputAcceleration.z <= -0.05f)
            transform.position = Vector3.Lerp(transform.position, topPosition.position, positiveInputValue * speed * Time.deltaTime);
        else if (InputManager.instance.inputAcceleration.z >= 0.05f)
            transform.position = Vector3.Lerp(transform.position, bottomPosition.position, positiveInputValue * speed * Time.deltaTime);
    }

    private void OldInputFunction()
    {
        positiveInputValue = InputManager.instance.inputAcceleration.z;

        if (positiveInputValue < 0)
            positiveInputValue *= -1;

        if (InputManager.instance.inputAcceleration.z <= -0.05f)
        {
            // Move object
            transform.Translate(Vector3.up * Time.deltaTime * (positiveInputValue * speed));
        }
        else if (InputManager.instance.inputAcceleration.z >= 0.05f)
        {
            // Move object
            transform.Translate(Vector3.down * Time.deltaTime * (positiveInputValue * speed));
        }

    }
}
// Using the lerp function to move player to target position