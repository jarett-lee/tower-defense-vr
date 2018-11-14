using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    public float range = 15f;

    public string enemyTag = "enemy";

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestEnemyDistanceToGoal = float.PositiveInfinity;
        GameObject enemyClosestToGoal = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            bool inRange = distanceToEnemy < range;
            float enemyDistanceToGoal = enemy.GetComponent<Enemy>().DistanceToGoal;
            bool closer = shortestEnemyDistanceToGoal > enemyDistanceToGoal;
            if (inRange && closer)
            {
                shortestEnemyDistanceToGoal = enemyDistanceToGoal;
                enemyClosestToGoal = enemy;
            }
        }

        if (enemyClosestToGoal != null)
        {
            target = enemyClosestToGoal.transform;
            Debug.Log(shortestEnemyDistanceToGoal);
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        // TODO improve target locking script
        transform.LookAt(target.position);
    }
}
