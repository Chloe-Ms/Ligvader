using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] PlayerBonus _plBonus;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            _plBonus.EndTimerBonusY();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            _plBonus.EndTimerBonusY();
            Destroy(collision.gameObject); //Enemy is destroyed when it collides with the shield
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            _plBonus.EndTimerBonusY();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            _plBonus.EndTimerBonusY();
            Destroy(collision.gameObject); //Enemy is destroyed when it collides with the shield
        }
    }
}
