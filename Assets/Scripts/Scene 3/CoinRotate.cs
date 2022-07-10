using UnityEngine;
using TMPro;

public class CoinRotate : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text coinsText;

    [Header("Objects")]
    [SerializeField] private GameObject endWall;

    [Header("Values")]
    [SerializeField] private float rotationSpeed = 50;

    private int totalCoins = 0;
    [HideInInspector] public int grabbedCoins = 0;

    private void Start()
    {
        totalCoins = 0;
        grabbedCoins = 0;

        foreach (Transform child in transform)
            totalCoins += 1;

        if (!endWall.activeSelf)
            endWall.SetActive(true);
    }

    private void Update()
    {
        foreach (Transform child in transform)
            Rotate(child);

        coinsText.text = "Coins: " + grabbedCoins + " / " + totalCoins.ToString();

        if (grabbedCoins == totalCoins)
        {
            if (endWall.activeSelf)
                endWall.SetActive(false);
        }
    }

    private void Rotate(Transform _child)
    {
        _child.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}
