using UnityEngine;

public class PlayerController : Controller
{
    // Update is called once per frame
    private void Update() {
        var xInput = Input.GetAxis("Horizontal");
        var yInput = Input.GetAxis("Vertical");
        onControlInputted.Invoke(new Vector2(xInput, yInput));

        var shootInput = Input.GetButton("Fire1");
        if (shootInput) {
            onShootInputted.Invoke();
        }
    }
}
