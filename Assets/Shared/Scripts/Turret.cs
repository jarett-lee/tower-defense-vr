using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCooldown = 0f;
    public int damage = 30;

    [Header("Unity Setup Fields")]

    public string enemyTag = "enemy";

    public LineRenderer lineRenderer;
    private Color laserStartColor;
    private Color laserEndColor;
    public float laserFadeDuration = 0.1f;
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        laserStartColor = lineRenderer.startColor;
        laserEndColor = lineRenderer.endColor;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestEnemyDistanceToGoal = float.PositiveInfinity;
        GameObject enemyClosestToGoal = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            bool inRange = distanceToEnemy < range;
            float enemyDistanceToGoal = enemy.GetComponent<EnemyMovement>().DistanceToGoal;
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
            targetEnemy = enemyClosestToGoal.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            lineRenderer.enabled = false;
            return;
        }

        // TODO improve target locking script
        transform.LookAt(target.position);

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        if (lineRenderer.enabled)
        {
            FadeLaserBeam();
        }

        fireCooldown -= Time.deltaTime;
    }

    void ResetLaserBeam()
    {
        lineRenderer.startColor = laserStartColor;
        lineRenderer.endColor = laserEndColor;
    }

    void FadeLaserBeam()
    {
        Color c = lineRenderer.startColor;
        float alpha = c.a;
        alpha -= Time.deltaTime / laserFadeDuration;
        c.a = alpha;
        lineRenderer.startColor = c;

        c = lineRenderer.endColor;
        alpha = c.a;
        alpha -= Time.deltaTime / laserFadeDuration;
        c.a = alpha;
        lineRenderer.endColor = c;
    }

    void Shoot()
    {
        if (target == null)
        {
            return;
        }

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        ResetLaserBeam();
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
    }
}
