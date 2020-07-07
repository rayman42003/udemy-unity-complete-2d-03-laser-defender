using System.Collections.Generic;
using UnityEngine;

public class Navigable : MonoBehaviour
{
    [SerializeField]
    private Path path;

    [SerializeField]
    private int currWaypointIndex = 0;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private List<Transform> waypoints;

    private void Start() {
        waypoints = path.getWaypoints();
        transform.position = waypoints[currWaypointIndex].position;
    }

    private void Update() {
        if (currWaypointIndex < waypoints.Count) {
            Vector2 currPos = transform.position;
            Vector2 waypointPos = waypoints[currWaypointIndex].position;
            if ((waypointPos - currPos).magnitude < Mathf.Epsilon) {
                currWaypointIndex++;
            } else {
                Vector2 newPos = Vector2.MoveTowards(currPos, waypointPos, moveSpeed * Time.deltaTime);
                transform.position = newPos;
            }
        }
    }
}
