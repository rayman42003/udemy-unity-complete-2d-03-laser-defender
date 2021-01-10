using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text scoreText;

    private void Start() {
        scoreText = GetComponent<TMP_Text>();

        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.registerOnScoreChange((score) => updateScore(score));
        updateScore(gameSession.getScore());
    }

    private void updateScore(int score) {
        scoreText.text = score.ToString();
    }
}
