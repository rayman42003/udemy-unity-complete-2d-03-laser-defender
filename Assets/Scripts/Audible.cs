using UnityEngine;

public class Audible : MonoBehaviour
{
    [SerializeField]
    private AudioClip shootSound;

    [SerializeField]
    private float shootVolume = 0.25f;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private float deathVolume = 0.75f;

    private void Start() {
        Shooter shooter = GetComponent<Shooter>();
        shooter?.registerOnShootProjectile(() => playShootSound());
        Damagable damagable = GetComponent<Damagable>();
        damagable?.registerOnKilled((score) => playDeathSound());
    }

    private void playShootSound() {
        if (shootSound != null) {
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position,
                shootVolume);
        }
    }

    private void playDeathSound() {
        if (deathSound != null) {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position,
                deathVolume);
        }
    }
}
