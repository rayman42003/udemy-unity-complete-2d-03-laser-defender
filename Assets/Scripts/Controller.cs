using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    private UnityEvent<Vector2> onControlInputted = new VectorEvent();

    private UnityEvent onShootInputted = new UnityEvent();

    public void registerOnControlInputted(UnityAction<Vector2> action) {
        onControlInputted.AddListener(action);
    }

    public void registerOnShootInputted(UnityAction action) {
        onShootInputted.AddListener(action);
    }

    // Update is called once per frame
    private void Update() {
        var xInput = Input.GetAxis("Horizontal");
        var yInput = Input.GetAxis("Vertical");
        onControlInputted.Invoke(new Vector2(xInput, yInput));

        var shootInput = Input.GetButtonDown("Fire1");
        if (shootInput) {
            onShootInputted.Invoke();
        }
    }
}
