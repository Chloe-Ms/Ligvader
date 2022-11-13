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
    //private Renderer _renderer;
    private PolygonCollider2D _collider;
    private Vector2 _spawnPosition;
    private bool _canMoveVertically = false;
    private bool _inMenu = false;
    void Reset(){
        _speed = 5f;
    }

    void Awake()
    {
        //_renderer = GetComponent<Renderer>();
        _collider = GetComponent<PolygonCollider2D>();
        
    }

    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _spawnPosition = transform.position;
        _currentSpeed = _speed;
    }

    void Update()
    {
        if (!_inMenu)
        {
            MovePlayer();
        }
    }

    void MovePlayer(){
        Vector2 playerPos = transform.position;
/*        Debug.Log("COL "+_collider.bounds.size.x);
        Debug.Log("REN " + _renderer.bounds.size.x);
        playerPos.x = Mathf.Clamp(playerPos.x + (_speed * Time.deltaTime * _moveInput.x), -_screenBounds.x + (_renderer.bounds.size.x / 2f), _screenBounds.x - (_renderer.bounds.size.x / 2f));
        if (_canMoveVertically)
        {
            playerPos.y = Mathf.Clamp(playerPos.y + (_speed * Time.deltaTime * _moveInput.y), -_screenBounds.y + (_renderer.bounds.size.y / 2f), _screenBounds.y - (_renderer.bounds.size.y / 2f));
        }*/
        playerPos.x = Mathf.Clamp(playerPos.x + (_speed * Time.deltaTime * _moveInput.x), -_screenBounds.x + (_collider.bounds.size.x / 2f), _screenBounds.x - (_collider.bounds.size.x / 2f));
        if (_canMoveVertically)
        {
            playerPos.y = Mathf.Clamp(playerPos.y + (_speed * Time.deltaTime * _moveInput.y), -_screenBounds.y + (_collider.bounds.size.y / 2f), _screenBounds.y - (_collider.bounds.size.y / 2f));
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
}
