using UnityEngine;
using System;
using TMPro;

public class GameManager_Level2 : MonoBehaviour
{
    public static GameManager_Level2 instance;
    [NonSerialized] public bool isInputEnabled = true;

    [Header("UI")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject introCanvas;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private TMP_Text FPSCounter;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!introCanvas.activeSelf)
            introCanvas.SetActive(true);

        if (gameOverScreen.activeSelf)
            gameOverScreen.SetActive(false);

        if (pauseButton.activeSelf)
            pauseButton.SetActive(false);

        if (pauseScreen.activeSelf)
            pauseScreen.SetActive(false);

        if (FPSCounter.gameObject.activeSelf)
            FPSCounter.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (introCanvas.activeSelf || gameOverScreen.activeSelf || pauseScreen.activeSelf)
        {
            Time.timeScale = 0f;
            isInputEnabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            isInputEnabled = true;
        }
    }

    public void GameOver()
    {
        if (!gameOverScreen.activeSelf)
            gameOverScreen.SetActive(true);

        if (pauseButton.activeSelf)
            pauseButton.SetActive(false);

        if (FPSCounter.gameObject.activeSelf)
            FPSCounter.gameObject.SetActive(false);
    }
}
