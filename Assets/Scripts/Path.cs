using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> getWaypoints() {
        return gameObject.transform
            .Cast<Transform>()
            .ToList();
    }
}
