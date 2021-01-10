using UnityEngine;

public class DeathSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;

    private void Start() {
        Damagable damageable = GetComponent<Damagable>();
        damageable.registerOnKilled((score) => spawn());
    }

    private void spawn() {
        Instantiate(spawnObject, gameObject.transform.position, Quaternion.identity);
    }
}
