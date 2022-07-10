using UnityEngine;
using TMPro;

public class FPS_Counter : MonoBehaviour
{
    [Header("Framerate")]
    [SerializeField] private int targetFPS;

    private TMP_Text FPS_Text;

    private void Awake()
    {
        FPS_Text = GetComponent<TMP_Text>();
        Application.targetFrameRate = targetFPS;
    }

    private void Update()
    {
        if (FPS_Text != null)
        {
            float currentFPS = (int)(1f / Time.unscaledDeltaTime);

            if (Time.timeScale == 0f)
            {
                currentFPS = 0f;
            }


            if (Time.frameCount % 60 == 0)
            {
                FPS_Text.text = "FPS: " + currentFPS.ToString();
                Debug.Log($"FPS: {currentFPS.ToString()}");
            }
        }
        else
            throw new System.Exception("No TextMeshPro found on GameObject where script is located.");
    }
}
