using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    [SerializeField] int _healthShield = 3;
    [SerializeField] GameObject _impactPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "PlayerProjectile")
        {
            if (_healthShield > 1f)
            {
                Instantiate(_impactPrefab, collision.transform.position, Quaternion.identity);
            }
            TakeDamage();
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            if (_healthShield > 1f)
            {
                Instantiate(_impactPrefab, collision.transform.position, Quaternion.identity);
            }
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage()
    {
        _healthShield--;
        if (_healthShield <= 0)
        {
            Destroy(gameObject);
        }
    }
}
