using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    private static readonly int DEFAULT_HIT_POINTS = 1;

    [SerializeField]
    private int maxHitPoints = DEFAULT_HIT_POINTS;

    private int currHitPoints = DEFAULT_HIT_POINTS;

    [SerializeField]
    private int lives = 1;

    [SerializeField]
    private int pointValue = 0;

    private bool isInvulnerable = false;

    private ShipEvent onDamaged = new ShipEvent();
    private ShipEvent onLifeLost = new ShipEvent();
    private ShipEvent onKilled = new ShipEvent();

    public void Awake() {
        currHitPoints = maxHitPoints;
    }

    public void Start() {
        GameSession gameSession = FindObjectOfType<GameSession>();
        registerOnKilled((shipInfo) => gameSession.incrementScore(shipInfo.getPointValue()));
    }

    public void takeDamage(int damage) {
        if (isInvulnerable) {
            return;
        }
        currHitPoints -= damage;
        if (currHitPoints <= 0) {
            lives--;
            if (lives <= 0) {
                kill();
            } else {
                currHitPoints = maxHitPoints;
            }
            onLifeLost.Invoke(getShipInfo());
        }
        onDamaged.Invoke(getShipInfo());
    }

    public ShipInfo getShipInfo() {
        return new ShipInfo(currHitPoints, lives, pointValue);
    }

    private void kill() {
        onKilled.Invoke(getShipInfo());
        Destroy(gameObject);
    }

    public void registerOnDamaged(UnityAction<ShipInfo> action) {
        onDamaged.AddListener(action);
    }

    public void registerOnLifeLost(UnityAction<ShipInfo> action) {
        onLifeLost.AddListener(action);
    }

    public void registerOnKilled(UnityAction<ShipInfo> action) {
        onKilled.AddListener(action);
    }

    public void setIsInvulnerable(bool isInvulnerable) {
        this.isInvulnerable = isInvulnerable;
    }
}
