using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private float backgroundSpeed = 0.1f;

    private Material backgroundMaterial;

    // Start is called before the first frame update
    private void Start() {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    private void Update() {
        Vector2 offset = new Vector2(0f, backgroundSpeed * Time.deltaTime);
        backgroundMaterial.mainTextureOffset += offset;
    }
}
