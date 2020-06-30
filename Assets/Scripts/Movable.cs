using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    private Controller controller;

    private void Start() {
        if (controller == null) {
            controller = GetComponent<Controller>();
        }
        controller.registerOnControlInputted((dir) => Move(dir));
    }

    private void Move(Vector2 dir) {
        var newXPos = transform.position.x + dir.x;
        transform.position = new Vector2(newXPos, transform.position.y);
    }
}
