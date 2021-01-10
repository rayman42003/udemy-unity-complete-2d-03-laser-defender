using UnityEngine;

public class GameSession : MonoBehaviour
{
    private int score = 0;

    private void Awake() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void initialize() {
        score = 0;
    }

    public int GetScore() {
        return score;
    }

    public void AddToScore(int points) {
        score += points;
        Debug.Log($"Score: {score}");
    }

    public void ResetGameSession() {
        initialize();
        Debug.Log($"Reset game: {score}");
    }
}
