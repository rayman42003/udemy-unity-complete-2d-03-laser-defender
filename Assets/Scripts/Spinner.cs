using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private float speed = 360f;

    private void Update() {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
