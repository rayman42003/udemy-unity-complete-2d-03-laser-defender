using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Navigable : MonoBehaviour
{
    [SerializeField]
    private Path path;

    [SerializeField]
    private int waypointIndex = 0;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private bool isLooping = false;

    private bool reverseIndex = false;

    private UnityEvent onNavigationComplete = new UnityEvent();

    private List<Transform> waypoints {
        get { return path.getWaypoints(); }
    }

    private void Start() {
        if (path != null) {
            transform.position = waypoints[waypointIndex].position;
        }
    }

    private void Update() {
        List<Transform> test = waypoints;
        if (!pathComplete()) {
            Vector2 currPos = transform.position;
            Vector2 waypointPos = waypoints[waypointIndex].position;
            if ((waypointPos - currPos).magnitude < Mathf.Epsilon) {
                nextWaypoint();
            } else {
                Vector2 newPos = Vector2.MoveTowards(currPos, waypointPos, moveSpeed * Time.deltaTime);
                transform.position = newPos;
            }
        } else {
            if (isLooping) {
                reverseDirection();
            } else {
                onNavigationComplete.Invoke();
            }
        }
    }

    private void reverseDirection() {
        reverseIndex = !reverseIndex;
        if (reverseIndex) {
            waypointIndex = waypoints.Count - 1;
        } else {
            waypointIndex = 0;
        }
    }

    private void nextWaypoint() {
        if (reverseIndex) {
            waypointIndex--;
        } else {
            waypointIndex++;
        }
    }

    private bool pathComplete() {
        return (reverseIndex && waypointIndex < 0) ||
            (!reverseIndex && waypointIndex >= waypoints.Count);
    }

    public void registerOnNavigationComplete(UnityAction action) {
        onNavigationComplete.AddListener(action);
    }

    public void setPath(Path path) {
        this.path = path;
    }

    public void setMoveSpeed(float moveSpeed) {
        this.moveSpeed = moveSpeed;
    }

    public void setIsLooping(bool isLooping) {
        this.isLooping = isLooping;
    }
}
