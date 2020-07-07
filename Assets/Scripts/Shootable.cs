using UnityEngine;

public class Shootable : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed = 10f;

    [SerializeField]
    private Camera gameCamera;

    [SerializeField]
    private float yMin = -0.05f;

    [SerializeField]
    private float yMax = 1.05f;

    private void Start() {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, projectileSpeed);

        gameCamera = Camera.main;
    }

    private void Update() {
        Vector3 positionInCameraUnits = gameCamera.WorldToViewportPoint(transform.position);
        if (positionInCameraUnits.y < yMin || positionInCameraUnits.y > yMax) {
            Destroy(gameObject);
        }
    }
}
