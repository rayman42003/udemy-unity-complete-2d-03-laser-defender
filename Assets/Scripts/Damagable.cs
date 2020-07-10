using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField]
    private int hitPoints = 1;

    private UnityEvent onDamaged = new UnityEvent();
    private UnityEvent onKilled = new UnityEvent();

    public void takeDamage(int damage) {
        hitPoints -= damage;
        if (hitPoints == 0) {
            kill();
        } else {
            onDamaged.Invoke();
        }
    }

    private void kill() {
        onKilled.Invoke();
        Destroy(gameObject);
    }

    private void registerOnDamaged(UnityAction action) {
        onDamaged.AddListener(action);
    }

    private void registerOnKilled(UnityAction action) {
        onKilled.AddListener(action);
    }
}
