using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    [SerializeField] EnemyHealth _health;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "PlayerProjectile")
        {
            _health.TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
