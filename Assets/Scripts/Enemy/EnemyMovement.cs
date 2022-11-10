using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool _verticalMovement;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _padding = 2f;
    [SerializeField] private float _rowDifference = 0.25f;
    private Vector3 _direction = Vector3.right;

    void Update()
    {
        if (_verticalMovement)
        {
            Vector2 playerPos = transform.position;
            playerPos.y = playerPos.y - _speed * Time.deltaTime;
            transform.position = playerPos;
        } else
        {
            this.transform.position += _direction * _speed * Time.deltaTime;

            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

            foreach (Transform invader in transform)
            {
                if(_direction == Vector3.right && invader.position.x >= (rightEdge.x - _padding))
                {
                    AdvanceRow();
                } else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + _padding))
                {
                    AdvanceRow();
                }
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= _rowDifference;
        this.transform.position = position;
    }
}
