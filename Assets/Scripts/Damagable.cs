using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField]
    private int hitPoints = 1;

    [SerializeField]
    private int score = 0;

    private bool isInvulnerable = false;

    private IntEvent onDamaged = new IntEvent();
    private IntEvent onKilled = new IntEvent();

    public void Start() {
        GameSession gameSession = FindObjectOfType<GameSession>();
        registerOnKilled((score) => gameSession.incrementScore(score));
    }

    public void takeDamage(int damage) {
        if (isInvulnerable) {
            return;
        }
        hitPoints -= damage;
        if (hitPoints <= 0) {
            kill();
        }
        onDamaged.Invoke(hitPoints);
    }

    private void kill() {
        onKilled.Invoke(score);
        Destroy(gameObject);
    }

    public int getHitPoints() {
        return hitPoints;
    }

    public void registerOnDamaged(UnityAction<int> action) {
        onDamaged.AddListener(action);
    }

    public void registerOnKilled(UnityAction<int> action) {
        onKilled.AddListener(action);
    }

    public void setIsInvulnerable(bool isInvulnerable) {
        this.isInvulnerable = isInvulnerable;
    }
}
