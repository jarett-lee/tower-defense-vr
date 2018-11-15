using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    public float DistanceToGoal {
        get
        {
            Vector3 dir = target.position - transform.position;
            int waypointsLeft = Waypoints.points.Length - waypointIndex;
            float _distanceToGoal = 10000f * waypointsLeft + dir.magnitude;

            return _distanceToGoal;
        }
    }

	void Start () {
        target = Waypoints.points[0];
	}
	
	void Update () {
        Vector3 dir = target.position - transform.position;
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
