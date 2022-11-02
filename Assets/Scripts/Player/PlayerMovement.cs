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
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer(){
        Vector2 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x + (_speed * Time.deltaTime * _moveInput.x),-_screenBounds.x + (_renderer.bounds.size.x / 2f), _screenBounds.x - (_renderer.bounds.size.x / 2f)) ;
        transform.position = playerPos;


    }

    void OnMove(InputValue value){
        _moveInput = value.Get<Vector2>();
    }
}
