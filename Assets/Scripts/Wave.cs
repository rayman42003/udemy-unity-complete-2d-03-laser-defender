using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave")]
public class Wave : ScriptableObject
{
    [SerializeField]
    private GameObject enemy = null;

    [SerializeField]
    private int numEnemies = 3;

    [SerializeField]
    private GameObject path = null;

    [SerializeField]
    private bool isLooping = false;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float spawnTime = 1f;

    public GameObject getEnemy() {
        return enemy;
    }

    public int getNumEnemies() {
        return numEnemies;
    }

    public Path getPath() {
        return path.GetComponent<Path>();
    }

    public bool getIsLooping() {
        return isLooping;
    }

    public float getMoveSpeed() {
        return moveSpeed;
    }

    public float getSpawnTime() {
        return spawnTime;
    }
}
