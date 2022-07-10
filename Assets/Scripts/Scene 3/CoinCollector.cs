using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private CoinRotate coinManager;

    private void Awake()
    {
        coinManager = FindObjectOfType<CoinRotate>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinManager.grabbedCoins++;
        }
    }
}
