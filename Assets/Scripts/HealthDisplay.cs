using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    private TMP_Text healthText;

    private void Start() {
        healthText = GetComponent<TMP_Text>();

        PlayerController playerController = FindObjectOfType<PlayerController>();
        Damagable damagable = playerController.gameObject.GetComponent<Damagable>();
        damagable.registerOnDamaged((hitPoints) => updateHealth(hitPoints));
        updateHealth(damagable.getHitPoints());
    }

    private void updateHealth(int hitPoints) {
        healthText.text = $"HP: {hitPoints}";
    }
}
