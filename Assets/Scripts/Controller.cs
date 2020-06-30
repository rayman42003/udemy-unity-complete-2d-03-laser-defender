using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    private UnityEvent<Vector2> onControlInputted = new VectorEvent();

    public void registerOnControlInputted(UnityAction<Vector2> action) {
        onControlInputted.AddListener(action);
    }

    // Update is called once per frame
    private void Update() {
        var xInput = Input.GetAxis("Horizontal");
        var yInput = Input.GetAxis("Vertical");
        onControlInputted.Invoke(new Vector2(xInput, yInput));
    }
}
