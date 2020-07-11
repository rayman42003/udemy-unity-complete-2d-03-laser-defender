using System.Collections;
using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField]
    private float minShootTime = 0.2f;

    [SerializeField]
    private float maxShootTime = 0.8f;

    [SerializeField]
    private bool shooting = true;

    private IEnumerator Start() {
        do {
            yield return StartCoroutine(shoot());
        } while (shooting);
    }

    private IEnumerator shoot() {
        float waitTime = Random.Range(minShootTime, maxShootTime);
        yield return new WaitForSeconds(waitTime);
        onShootInputted.Invoke();
    }
}
