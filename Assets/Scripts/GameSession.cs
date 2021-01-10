using UnityEngine;
using UnityEngine.Events;

public class GameSession : MonoBehaviour
{
    private int score = 0;

    private IntEvent onScoreChange = new IntEvent();

    private void Awake() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void initialize() {
        score = 0;
        onScoreChange.Invoke(score);
    }

    public int getScore() {
        return score;
    }

    public void incrementScore(int points) {
        score += points;
        onScoreChange.Invoke(score);
    }

    public void registerOnScoreChange(UnityAction<int> action) {
        onScoreChange.AddListener(action);
    }

    public void ResetGameSession() {
        initialize();
    }
}
