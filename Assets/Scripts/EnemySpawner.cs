using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Wave> waves = null;

    [SerializeField]
    private int waveIndex = 0;

    [SerializeField]
    private float waveDelay = 2f;

    [SerializeField]
    private UnityEvent onWavesComplete;

    private int enemiesCompletedNavigation = 0;
    private int enemiesDestroyed = 0;

    private void Start() {
        StartCoroutine(spawnWave(waves[waveIndex], waveDelay));
    }

    private void Update() {
        int enemiesRemoved = enemiesCompletedNavigation + enemiesDestroyed;
        bool waveCleared = enemiesRemoved == waves[waveIndex].getNumEnemies();
        if (waveCleared) {
            if (waveIndex < waves.Count - 1) {
                waveIndex++;
                StartCoroutine(spawnWave(waves[waveIndex], waveDelay));
            } else {
                onWavesComplete.Invoke();
            }
        }
    }

    private IEnumerator spawnWave(Wave wave, float waveDelay) {
        yield return new WaitForSeconds(waveDelay);
        enemiesCompletedNavigation = 0;
        enemiesDestroyed = 0;
        for (int i = 0; i < wave.getNumEnemies(); i++) {
            Path path = wave.getPath();
            var enemy = Instantiate(wave.getEnemy(), path.getWaypoints()[0].position, Quaternion.identity);
            Navigable navigable = enemy.GetComponent<Navigable>();
            navigable.setPath(path);
            navigable.setMoveSpeed(wave.getMoveSpeed());
            navigable.registerOnNavigationComplete(() => {
                Destroy(enemy);
                enemiesCompletedNavigation++;
            });
            navigable.setIsLooping(wave.getIsLooping());

            Damagable damagable = enemy.GetComponent<Damagable>();
            damagable.registerOnKilled(() => { enemiesDestroyed++; });
            yield return new WaitForSeconds(wave.getSpawnTime());
        }
    }
}
