using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    private void Start() {
        if (player) {
            Damagable damagable = player?.GetComponent<Damagable>();
            damagable?.registerOnKilled((score) => loadGameOver());
        }
    }

    public void loadStartMenu() {
        SceneManager.LoadScene("01-start-menu");
    }

    public void loadGameScene() {
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.ResetGameSession();
        SceneManager.LoadScene("02-game");
    }

    public void loadGameOver() {
        StartCoroutine(delayLoad(0.75f, "03-game-over"));
    }

    private IEnumerator delayLoad(float seconds, string scene) {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
    }

    public void quitGame() {
        Application.Quit();
    }
}
