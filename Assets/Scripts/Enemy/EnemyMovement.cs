using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool _verticalMovement;
    [SerializeField] private float _speed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        if (_verticalMovement)
        {
            Vector2 playerPos = transform.position;
            playerPos.y = playerPos.y - _speed * Time.deltaTime;
            transform.position = playerPos;

        }
    }
}
