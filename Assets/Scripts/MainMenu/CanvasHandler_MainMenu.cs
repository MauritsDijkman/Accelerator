using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasHandler_MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject selectionScreen;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private TMP_Text loadingPercentage;

    private void Start()
    {
        if (!selectionScreen.activeSelf)
            selectionScreen.SetActive(true);

        if (loadingScreen.activeSelf)
            loadingScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        if (!loadingScreen.activeSelf)
            loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            loadingPercentage.text = (progress * 100).ToString("F0") + "%";
            //Debug.Log("Progress: " + (progress * 100).ToString("F0") + "%");
            yield return null;
        }
    }
}
