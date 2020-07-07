using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private Controller controller;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float firingCooldown = 0.1f;

    [SerializeField]
    private bool onCooldown = false;

    private void Start() {
        if (controller == null) {
            controller = GetComponent<Controller>();
        }
        controller.registerOnShootInputted(() => shoot());
    }

    private void shoot() {
        if (!onCooldown) {
            Vector3 spawnPoint = transform.position + new Vector3(0, 0, 0.5f);
            Instantiate(projectile, spawnPoint, Quaternion.identity);
            StartCoroutine(startFiringCooldown());
        }
    }

    private IEnumerator startFiringCooldown() {
        onCooldown = true;
        yield return new WaitForSeconds(firingCooldown);
        onCooldown = false;
    }
}
