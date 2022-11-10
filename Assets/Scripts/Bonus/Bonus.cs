using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] float _speed;
    private Vector2 _screenBounds;
    private Renderer _renderer;
    public abstract void ApplyBonus(PlayerBonus plBonus);

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
        transform.position += new Vector3(0f, -_speed * Time.deltaTime, 0f);
        //If the projectile is outside of the screen, it's destroyed
        if (transform.position.y + (_renderer.bounds.size.y / 2f) < -_screenBounds.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerBonus plBonus = collision.gameObject.GetComponent<PlayerBonus>();
            ApplyBonus(plBonus);
            Destroy(gameObject);
        }
    }


}