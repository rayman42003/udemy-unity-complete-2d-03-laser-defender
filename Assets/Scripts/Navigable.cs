using System.Collections.Generic;
using UnityEngine;

public class Navigable : MonoBehaviour
{
    [SerializeField]
    private Path path;

    [SerializeField]
    private int waypointIndex = 0;

    [SerializeField]
    private float moveSpeed = 10f;

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
        if (waypointIndex < waypoints.Count) {
            Vector2 currPos = transform.position;
            Vector2 waypointPos = waypoints[waypointIndex].position;
            if ((waypointPos - currPos).magnitude < Mathf.Epsilon) {
                waypointIndex++;
            } else {
                Vector2 newPos = Vector2.MoveTowards(currPos, waypointPos, moveSpeed * Time.deltaTime);
                transform.position = newPos;
            }
        }
    }

    public void setPath(Path path) {
        this.path = path;
    }

    public void setMoveSpeed(float moveSpeed) {
        this.moveSpeed = moveSpeed;
    }
}
