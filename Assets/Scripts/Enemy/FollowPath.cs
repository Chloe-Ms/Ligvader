using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    //Walk speed of the enemy 
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks to the next one
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start()
    {
        // Set position of Enemy as position of the first waypoint
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[waypointIndex].transform.position;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (waypoints.Length > 0)
        {
            Move();
        }
    }

    private void Move()
    {
        // Move Enemy from current waypoint to the next one
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

        // If Enemy reaches position of waypoint he walked towards then waypointIndex is increased by 1
        // and Enemy starts to walk to the next waypoint
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            // If the enemy reaches the last waypoint, he comes back to the first one 
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }
}