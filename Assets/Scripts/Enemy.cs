using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public int health = 100;
    public int value = 50;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; // Get dir to next waypoint

        // normalized because same speed everytime
        // Time.deltaTime because framerate varies
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return; //fixed error because Destroy delay
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }


    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

}
