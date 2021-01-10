using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    private TMP_Text healthText;

    private void Start() {
        healthText = GetComponent<TMP_Text>();

        PlayerController playerController = FindObjectOfType<PlayerController>();
        Damagable damagable = playerController.gameObject.GetComponent<Damagable>();
        damagable.registerOnDamaged((shipInfo) => updateHealth(shipInfo));
        updateHealth(damagable.getShipInfo());
    }

    private void updateHealth(ShipInfo shipInfo) {
        healthText.text = $"HP: {shipInfo.getHitPoints()} Lives: {shipInfo.getLives()}";
    }
}
