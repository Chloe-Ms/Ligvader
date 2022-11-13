using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    EnemyHealth _health;
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] _waypoints;

    [SerializeField]
    private bool loop;

    //Walk speed of the enemy 
    [SerializeField]
    private float _moveSpeed = 2f;

    [SerializeField] private bool _startOnLeft;
    private bool _leftToRight;

    // Index of current waypoint from which Enemy walks to the next one
    private int _waypointIndex = 0;

    public bool Loop
    {
        set { loop = value; }
        get { return loop; }
    }

    // Use this for initialization
    private void Start()
    {
        _health = GetComponent<EnemyHealth>();
        // Set position of Enemy as position of the first waypoint
        if (_waypoints.Length > 0)
        {
            transform.position = _waypoints[_waypointIndex].transform.position;
        }
        _leftToRight = _startOnLeft;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_waypoints.Length > 0)
        {
            Move();
        }
    }

    private void Move()
    {
        // Move Enemy from current waypoint to the next one
        transform.position = Vector2.MoveTowards(transform.position,
            _waypoints[_waypointIndex].transform.position,
            _moveSpeed * Time.deltaTime);

        // If Enemy reaches position of waypoint he walked towards then waypointIndex is increased by 1
        // and Enemy starts to walk to the next waypoint
        if (transform.position == _waypoints[_waypointIndex].transform.position)
        {
            // If the enemy reaches the last waypoint, he comes back to the first one 
            
            if (_leftToRight)
            {
                if (_waypointIndex + 1 == _waypoints.Length)
                {
                    if (loop)
                    {
                        _leftToRight = !_leftToRight;
                    } else
                    {
                        if (_health != null)
                        {
                            _health.DestroyEnemy();
                        }
                    }
                    
                } else
                {
                    _waypointIndex = _waypointIndex + 1;
                }
            } else
            {
                if (_waypointIndex - 1 == -1)
                {
                    if (loop)
                    {
                        _leftToRight = !_leftToRight;
                    }
                    else
                    {
                        if (_health != null)
                        {
                            _health.DestroyEnemy();
                        }
                    }
                } else
                {
                    _waypointIndex = _waypointIndex - 1;
                }
            }
        }
    }
}