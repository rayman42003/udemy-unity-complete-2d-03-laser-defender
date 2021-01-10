using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField]
    private int hitPoints = 1;

    [SerializeField]
    private int score = 0;

    private bool isInvulnerable = false;

    private UnityEvent onDamaged = new UnityEvent();
    private IntEvent onKilled = new IntEvent();

    public void Start() {
        GameSession gameSession = FindObjectOfType<GameSession>();
        registerOnKilled((score) => gameSession.AddToScore(score));
    }

    public void takeDamage(int damage) {
        if (isInvulnerable) {
            return;
        }
        hitPoints -= damage;
        if (hitPoints == 0) {
            kill();
        } else {
            onDamaged.Invoke();
        }
    }

    private void kill() {
        onKilled.Invoke(score);
        Destroy(gameObject);
    }

    public void registerOnDamaged(UnityAction action) {
        onDamaged.AddListener(action);
    }

    public void registerOnKilled(UnityAction<int> action) {
        onKilled.AddListener(action);
    }

    public void setIsInvulnerable(bool isInvulnerable) {
        this.isInvulnerable = isInvulnerable;
    }
}
