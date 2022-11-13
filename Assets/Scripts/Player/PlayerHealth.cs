using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerBonus _playerBonus;
    int _health = 1; 

    public void TakeDamage()
    {
        if (_playerBonus != null)
        {
            //If the player has no power up
            if (_playerBonus.GetBonusesSize() == _playerBonus.GetSizeBonusEnum())
            {
                
                _health--;
                
            }
            _playerBonus.ClearBonuses();
        } else
        {
            _health--;
        }
        
        
        if (_health <= 0)
        {
            Debug.Log("Player death");
            SceneManager.LoadScene("EndScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("MAIN "+ _playerBonus.ContainsBonus(BonusType.BLUE));
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }
    }
}
