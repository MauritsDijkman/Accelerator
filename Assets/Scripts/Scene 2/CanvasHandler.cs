using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CanvasHandler : MonoBehaviour
{
    public static CanvasHandler instance;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;

    [NonSerialized] public int playerScore = 0;

    private PipeSpawner pipeSpawner;

    private void Awake()
    {
        instance = this;
        pipeSpawner = FindObjectOfType<PipeSpawner>();
    }

    private void Start()
    {
        if (scoreText.gameObject.activeSelf)
            scoreText.gameObject.SetActive(false);

        scoreText.text = "Score: " + playerScore.ToString();

        if (!PlayerPrefs.HasKey("Highscore"))
            PlayerPrefs.SetInt("Highscore", playerScore);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int _score)
    {
        playerScore += _score;
        scoreText.text = "Score: " + playerScore.ToString();

        if (pipeSpawner != null)
            pipeSpawner.localScore += _score;
    }

    private void Update()
    {
        if (!GameManager_Level2.instance.isInputEnabled)
            return;

        //Debug.Log("Gets updated");

        if (playerScore > PlayerPrefs.GetInt("Highscore"))
            PlayerPrefs.SetInt("Highscore", playerScore);

        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
}
