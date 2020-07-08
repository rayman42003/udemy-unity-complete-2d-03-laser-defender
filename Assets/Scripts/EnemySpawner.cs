using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Wave> waves = null;

    [SerializeField]
    private int waveIndex = 0;

    private List<bool> currWave;

    private void Start() {
        Wave wave = waves[waveIndex];
        StartCoroutine(spawnWave(wave));
    }

    private IEnumerator spawnWave(Wave wave) {
        for (int i = 0; i < wave.getNumEnemies(); i++) {
            Path path = wave.getPath();
            var enemy = Instantiate(wave.getEnemy(), path.getWaypoints()[0].position, Quaternion.identity);
            Navigable navigable = enemy.GetComponent<Navigable>();
            navigable.setPath(path);
            navigable.setMoveSpeed(wave.getMoveSpeed());
            yield return new WaitForSeconds(wave.getSpawnTime());
        }
    }
}
