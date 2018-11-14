using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    float _distanceToGoal;
    public float DistanceToGoal {
        get
        {
            return _distanceToGoal;
        }
    }

	void Start () {
        target = Waypoints.points[0];

        Vector3 dir = target.position - transform.position;
        _distanceToGoal = dir.magnitude;
	}
	
	void Update () {
        Vector3 dir = target.position - transform.position;
        int waypointsLeft = Waypoints.points.Length - waypointIndex;
        _distanceToGoal = 10000f * waypointsLeft + dir.magnitude;

        Vector3 move = dir.normalized * speed * Time.deltaTime;
        transform.Translate(move, Space.World);

        if (dir.magnitude <= move.magnitude)
        {
            GetNextWaypoint();
        }
	}

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
