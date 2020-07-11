using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    private int attackPower = 1;

    [SerializeField]
    private bool destroyOnCollision = true;

    [SerializeField]
    private bool canAttack = true;

    private void OnCollisionEnter2D(Collision2D collider) {
        Damagable damagable = collider.gameObject.GetComponent<Damagable>();
        if (damagable != null && canAttack) {
            damagable.takeDamage(attackPower);
            if (destroyOnCollision) {
                Destroy(gameObject);
            }
        }
    }

    public void setCanAttack(bool canAttack) {
        this.canAttack = canAttack;
    }
}
