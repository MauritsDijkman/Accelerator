using UnityEngine;

public class PlayerController_Game1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
            GameManager_Level1.instance.GameOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
            GameManager_Level1.instance.EnableWinningScreen();
        else if (other.gameObject.CompareTag("Border"))
            GameManager_Level1.instance.GameOver();
    }
}
