using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour
{
    private UnityEvent onKilled = new UnityEvent();

    public void kill() {
        onKilled.Invoke();
        Destroy(gameObject);
    }
}
