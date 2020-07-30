using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private Controller controller;

    [SerializeField]
    private GameObject projectile = null;

    [SerializeField]
    private float firingCooldown = 0.1f;

    [SerializeField]
    private bool onCooldown = false;

    private UnityEvent onShootProjectile = new UnityEvent();

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
            onShootProjectile.Invoke();
            StartCoroutine(startFiringCooldown());
        }
    }

    private IEnumerator startFiringCooldown() {
        onCooldown = true;
        yield return new WaitForSeconds(firingCooldown);
        onCooldown = false;
    }

    public void registerOnShootProjectile(UnityAction action) {
        onShootProjectile.AddListener(action);
    }
}
