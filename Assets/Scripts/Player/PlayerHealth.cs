using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerBonus _playerBonus;
    int _health = 1; 

    public void TakeDamage()
    {
        _health--;
        _playerBonus.ClearBonuses();
        if (_health <= 0)
        {
            Debug.Log("Player death");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
