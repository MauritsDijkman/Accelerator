using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager_Level3 : MonoBehaviour
{
    public static GameManager_Level3 instance;
    [HideInInspector] public bool inputEnabled = true;

    [Header("UI")]
    [SerializeField] private GameObject introCanvas;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private GameObject damageEffect;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject winningCanvas;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private TMP_Text FPSCounter;

    private PlayerHealth_Game3 player;

    private void Awake()
    {
        instance = this;
        player = FindObjectOfType<PlayerHealth_Game3>();
    }

    private void Start()
    {
        if (!introCanvas.activeSelf)
            introCanvas.SetActive(true);

        if (coinsText.gameObject.activeSelf)
            coinsText.gameObject.SetActive(false);

        if (healthText.gameObject.activeSelf)
            healthText.gameObject.SetActive(false);

        if (damageEffect.activeSelf)
            damageEffect.SetActive(false);

        if (gameOverCanvas.activeSelf)
            gameOverCanvas.SetActive(false);

        if (winningCanvas.activeSelf)
            winningCanvas.SetActive(false);

        if (pauseButton.activeSelf)
            pauseButton.SetActive(false);

        if (pauseCanvas.activeSelf)
            pauseCanvas.SetActive(false);

        if (FPSCounter.gameObject.activeSelf)
            FPSCounter.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (introCanvas.activeSelf || player.GetHealth() <= 0 || pauseCanvas.activeSelf || winningCanvas.activeSelf)
        {
            Time.timeScale = 0f;
            inputEnabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            inputEnabled = true;
        }

        if (player.GetHealth() <= 0)
        {
            if (!gameOverCanvas.activeSelf)
                gameOverCanvas.SetActive(true);

            if (FPSCounter.gameObject.activeSelf)
                FPSCounter.gameObject.SetActive(false);

            if (pauseButton.activeSelf)
                pauseButton.SetActive(false);

            if (pauseCanvas.activeSelf)
                pauseCanvas.SetActive(false);
        }
    }

    public void DisableIntroCanvas()
    {
        if (introCanvas.activeSelf)
            introCanvas.SetActive(false);

        if (!coinsText.gameObject.activeSelf)
            coinsText.gameObject.SetActive(true);

        if (!healthText.gameObject.activeSelf)
            healthText.gameObject.SetActive(true);

        if (!pauseButton.activeSelf)
            pauseButton.SetActive(true);
    }

    public void LoadWinningScreen()
    {
        if (!winningCanvas.activeSelf)
            winningCanvas.SetActive(true);

        if (coinsText.gameObject.activeSelf)
            coinsText.gameObject.SetActive(false);

        if (healthText.gameObject.activeSelf)
            healthText.gameObject.SetActive(false);

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
