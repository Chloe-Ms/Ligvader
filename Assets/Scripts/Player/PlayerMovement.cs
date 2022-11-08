using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _moveInput;
    private Vector2 _screenBounds;
    private Renderer _renderer;
    private Vector2 _spawnPosition;
    private bool _canMoveVertically = false;
    void Reset(){
        _speed = 5f;
    }

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _spawnPosition = transform.position;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer(){
        Vector2 playerPos = transform.position;
        if (_canMoveVertically)
        {
            playerPos.x = Mathf.Clamp(playerPos.x + (_speed * Time.deltaTime * _moveInput.x), -_screenBounds.x + (_renderer.bounds.size.x / 2f), _screenBounds.x - (_renderer.bounds.size.x / 2f));
        } else
        {

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
}
