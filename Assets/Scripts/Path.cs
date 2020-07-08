using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Path : MonoBehaviour
{
    private List<Transform> waypoints = null;

    public List<Transform> getWaypoints() {
        if (waypoints == null || waypoints.Count == 0) {
            waypoints = gameObject.transform
              .Cast<Transform>()
              .ToList();
        }
        return waypoints;
    }
}
