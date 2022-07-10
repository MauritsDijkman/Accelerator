using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private TMP_Text FPSText;
    [SerializeField] private Toggle FPSToggler;

    private void Start()
    {
        CheckOnOff();

        //if (!PlayerPrefs.HasKey("FPS"))
        //    PlayerPrefs.SetInt("FPS", 0);
        //else
        //{
        //    if (PlayerPrefs.GetInt("FPS") == 0)
        //        ToggleFPS(false);
        //    else if (PlayerPrefs.GetInt("FPS") == 1)
        //        ToggleFPS(true);
        //}
    }

    public void Resume()
    {
        if (this.gameObject.activeSelf)
            this.gameObject.SetActive(false);

        if (!pauseButton.activeSelf)
            pauseButton.SetActive(true);
    }

    public void Recalibrate()
    {
        if (InputManager.instance != null)
            InputManager.instance.SetAcceleration();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleFPS(bool toggle)
    {
        if (toggle)
        {
            if (PlayerPrefs.GetInt("FPS") == 0)
                PlayerPrefs.SetInt("FPS", 1);

            // if (!FPSText.gameObject.activeSelf)
            // FPSText.gameObject.SetActive(true);
        }
        else if (!toggle)
        {
            if (PlayerPrefs.GetInt("FPS") == 1)
                PlayerPrefs.SetInt("FPS", 0);

            // if (FPSText.gameObject.activeSelf)
            // FPSText.gameObject.SetActive(false);
        }
    }

    public void CheckOnOff()
    {
        if (!PlayerPrefs.HasKey("FPS"))
            PlayerPrefs.SetInt("FPS", 0);

        if (PlayerPrefs.GetInt("FPS") == 0)
        {
            if (FPSText.gameObject.activeSelf)
                FPSText.gameObject.SetActive(false);

            FPSToggler.isOn = false;
        }
        else if (PlayerPrefs.GetInt("FPS") == 1)
        {
            if (!FPSText.gameObject.activeSelf)
                FPSText.gameObject.SetActive(true);

            FPSToggler.isOn = true;
        }
    }

    private void Update()
    {
        CheckOnOff();
    }
}
