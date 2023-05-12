using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _currentSpeed;
    private Vector2 _moveInput;
    private Vector2 _screenBounds;
    private EdgeCollider2D _edgeCollider;
    private PolygonCollider2D _polygonCollider;
    private bool _hasPower = false;
    private Vector2 _spawnPosition;
    private bool _canMoveVertically = false;
    private bool _inMenu = false;

    private bool _isDead = false;

    public bool HasPower { get => _hasPower; set => _hasPower = value; }

    void Reset(){
        _speed = 5f;
    }

    void Awake()
    {
        //_renderer = GetComponent<Renderer>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _edgeCollider = GetComponent<EdgeCollider2D>();


    }

    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _spawnPosition = transform.position;
        _currentSpeed = _speed;
    }

    void Update()
    {
        if (!_inMenu && !_isDead)
        {
            MovePlayer();
        }
    }

    void MovePlayer(){
        Vector2 playerPos = transform.position;
        if (HasPower)
        {
            playerPos.x = Mathf.Clamp(playerPos.x + (_speed * Time.deltaTime * _moveInput.x), -_screenBounds.x + (_edgeCollider.bounds.size.x / 2f), _screenBounds.x - (_edgeCollider.bounds.size.x / 2f));
        } else
        {
            playerPos.x = Mathf.Clamp(playerPos.x + (_speed * Time.deltaTime * _moveInput.x), -_screenBounds.x + (_polygonCollider.bounds.size.x / 2f), _screenBounds.x - (_polygonCollider.bounds.size.x / 2f));
        }
        if (_canMoveVertically)
        {
            if (HasPower)
            {
                playerPos.y = Mathf.Clamp(playerPos.y + (_speed * Time.deltaTime * _moveInput.y), -_screenBounds.y + (_edgeCollider.bounds.size.y / 2f), _screenBounds.y - (_edgeCollider.bounds.size.y / 2f));
            }
            else
            {
                playerPos.y = Mathf.Clamp(playerPos.y + (_speed * Time.deltaTime * _moveInput.y), -_screenBounds.y + (_polygonCollider.bounds.size.y / 2f), _screenBounds.y - (_polygonCollider.bounds.size.y / 2f));

            }
        }
        transform.position = playerPos;

    }

    void OnMove(InputValue value){
        _moveInput = value.Get<Vector2>();
    }

    public void SetCanMoveVertically(bool canMoveY)
    {
        _canMoveVertically = canMoveY;
    }

    public void ResetMovementVertically()
    {
        SetCanMoveVertically(false);
        transform.position = new Vector3(transform.position.x, _spawnPosition.y, transform.position.z);
    }

    public void ChangeSpeed(float multiplier)
    {
        _currentSpeed = multiplier * _speed;
    }

    public void SetInMenu(bool isInMenu)
    {
        _inMenu = isInMenu;
    }

    public void Die()
    {
        _isDead = true;
    }
}
