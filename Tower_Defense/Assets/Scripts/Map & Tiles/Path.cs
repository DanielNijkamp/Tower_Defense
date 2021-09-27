using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;
    GameObject currentWayPoint;

    public Waypoint getPathStart()
    {
        return _waypoints[0];
    }
    public Waypoint getPathEnd()
    {
        return _waypoints[_waypoints.Length - 1];
    }
    public Waypoint getNextWayPoint(Waypoint currentWayPoint)
    {
        for (int i = 0; i < _waypoints.Length; i++)
        {
            if (_waypoints[i] == currentWayPoint)
            {
                return _waypoints[i + 1];
            }
        }
        return null;
    }
}
