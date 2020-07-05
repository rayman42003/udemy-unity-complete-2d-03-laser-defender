using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    private Controller controller;

    [SerializeField]
    private float moveSpeed = 10.0f;

    private void Start() {
        if (controller == null) {
            controller = GetComponent<Controller>();
        }
        controller.registerOnControlInputted((dir) => Move(dir));
    }

    private void Move(Vector2 dir) {
        if (dir.magnitude > 1.0f) {
            dir.Normalize();
        }

        var deltaTime = Time.deltaTime;

        var newXPos = transform.position.x + dir.x * moveSpeed * deltaTime;

        var newYPos = transform.position.y + dir.y * moveSpeed * deltaTime;

        transform.position = new Vector2(newXPos, newYPos);
    }
}
