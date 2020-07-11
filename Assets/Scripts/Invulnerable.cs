using System.Collections;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    [SerializeField]
    private float duration = 1.5f;

    [SerializeField]
    private bool isInvulnerable = false;

    [SerializeField]
    private float blinkSpeed = 0.15f;

    private Damagable damagable = null;
    private Attacker attacker = null;
    private SpriteRenderer spriteRenderer = null;

    private void Start() {
        damagable = GetComponent<Damagable>();
        damagable.registerOnDamaged(() => {
            if (!isInvulnerable) {
                StartCoroutine(startInvulnerability(duration));
                StartCoroutine(disableAttack());
                StartCoroutine(blink(blinkSpeed));
            }
        });

        attacker = GetComponent<Attacker>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private IEnumerator startInvulnerability(float duration) {
        damagable.setIsInvulnerable(true);
        isInvulnerable = true;        yield return new WaitForSeconds(duration);
        damagable.setIsInvulnerable(false);
        isInvulnerable = false;
        attacker.setCanAttack(true);
    }

    private IEnumerator disableAttack() {
        yield return new WaitForEndOfFrame();
        attacker.setCanAttack(false);
    }

    private IEnumerator blink(float blinkSpeed) {
        while (isInvulnerable) {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkSpeed);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
}
