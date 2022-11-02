using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;
    private Vector2 _screenBounds;
    private Renderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update() {
        transform.position += _direction * _speed * Time.deltaTime;

        //If the projectile is outside of the screen, it's destroyed
        if (transform.position.y - (_renderer.bounds.size.y/2f) > _screenBounds.y){
            Destroy(gameObject);
        }   
    }
}
