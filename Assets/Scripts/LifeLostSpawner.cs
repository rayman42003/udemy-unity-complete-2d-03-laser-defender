using UnityEngine;

public class LifeLostSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;

    private void Start() {
        Damagable damageable = GetComponent<Damagable>();
        damageable.registerOnLifeLost((shipInfo) => spawn());
    }

    private void spawn() {
        Instantiate(spawnObject, gameObject.transform.position, Quaternion.identity);
    }
}
