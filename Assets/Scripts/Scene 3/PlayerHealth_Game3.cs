using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth_Game3 : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float health = 10;

    [Header("UI")]
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private GameObject damageEffect;

    private void Start()
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void DoDamage(float _damage)
    {
        if (health > 0)
        {
            health -= _damage;
            healthText.text = "Health: " + health.ToString();
            damageEffect.SetActive(true);
            StartCoroutine(DamageEffect(0.4f));
        }
    }

    private IEnumerator DamageEffect(float time)
    {
        if (!damageEffect.activeSelf)
            damageEffect.SetActive(true);

        yield return new WaitForSeconds(time);

        if (damageEffect.activeSelf)
            damageEffect.SetActive(false);
    }

    public float GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
            GameManager_Level3.instance.LoadWinningScreen();
    }
}
