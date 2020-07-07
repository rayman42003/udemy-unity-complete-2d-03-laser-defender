using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private Controller controller;

    [SerializeField]
    private GameObject projectile;

    private void Start() {
        if (controller == null) {
            controller = GetComponent<Controller>();
        }
        controller.registerOnShootInputted(() => shoot());
    }

    private void shoot() {
        Vector3 spawnPoint = transform.position + new Vector3(0, 0, 0.5f);
        Instantiate(projectile, spawnPoint, Quaternion.identity);
    }
}
