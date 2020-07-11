using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{
    protected UnityEvent<Vector2> onControlInputted = new VectorEvent();

    protected UnityEvent onShootInputted = new UnityEvent();

    public void registerOnControlInputted(UnityAction<Vector2> action) {
        onControlInputted.AddListener(action);
    }

    public void registerOnShootInputted(UnityAction action) {
        onShootInputted.AddListener(action);
    }
}
