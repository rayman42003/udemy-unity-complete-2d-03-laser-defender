using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    private Controller controller;

    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private float boundaryPadding = 0.5f;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    private void Start() {
        if (controller == null) {
            controller = GetComponent<Controller>();
        }
        controller.registerOnControlInputted((dir) => Move(dir));
        calculateBoundaries();
    }

    private void calculateBoundaries() {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + boundaryPadding;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - boundaryPadding;

        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + boundaryPadding;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - boundaryPadding;
    }

    private void Move(Vector2 dir) {
        if (dir.magnitude > 1.0f) {
            dir.Normalize();
        }

        var deltaTime = Time.deltaTime;

        var newXPos = transform.position.x + dir.x * moveSpeed * deltaTime;
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        var newYPos = transform.position.y + dir.y * moveSpeed * deltaTime;
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }
}
