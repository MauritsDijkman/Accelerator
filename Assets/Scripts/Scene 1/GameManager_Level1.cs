using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager_Level1 : MonoBehaviour
{
    public static GameManager_Level1 instance;
    [HideInInspector] public bool inputEnabled = true;

    [Header("UI")]
    [SerializeField] private GameObject introCanvas;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameoverCanvas;
    [SerializeField] private GameObject winningCanvas;
    [SerializeField] private TMP_Text FPSCounter;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!introCanvas.activeSelf)
            introCanvas.SetActive(true);

        if (pauseButton.activeSelf)
            pauseButton.SetActive(false);

        if (pauseCanvas.activeSelf)
            pauseCanvas.SetActive(false);

        if (FPSCounter.gameObject.activeSelf)
            FPSCounter.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (introCanvas.activeSelf || pauseCanvas.activeSelf || gameoverCanvas.activeSelf || winningCanvas.activeSelf)
        {
            Time.timeScale = 0f;
            inputEnabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            inputEnabled = true;
        }
    }

    public void DisableIntroCanvas()
    {
        if (introCanvas.activeSelf)
            introCanvas.SetActive(false);

        if (!pauseButton.activeSelf)
            pauseButton.SetActive(true);
    }

    public void GameOver()
    {
        if (!gameoverCanvas.activeSelf)
            gameoverCanvas.SetActive(true);

        if (pauseCanvas.activeSelf)
            pauseCanvas.SetActive(false);

        if (pauseButton.activeSelf)
            pauseButton.SetActive(false);

        if (FPSCounter.gameObject.activeSelf)
            FPSCounter.gameObject.SetActive(false);
    }

    public void EnableWinningScreen()
    {
        if (!winningCanvas.activeSelf)
            winningCanvas.SetActive(true);

        if (pauseButton.activeSelf)
            pauseButton.SetActive(false);

        if (pauseCanvas.activeSelf)
            pauseCanvas.SetActive(false);

        if (FPSCounter.gameObject.activeSelf)
            FPSCounter.gameObject.SetActive(false);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
