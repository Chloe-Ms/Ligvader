using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;

    private void Reset()
    {
        _health = 1;
    }

    void TakeDamage()
    {
        _health--;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "PlayerProjectile")
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
