using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;
    //[SerializeField] PlayerBonus _playerBonus;
    [SerializeField] float _chanceToDropBonus;
    [SerializeField] GameObject[] _bonusPrefabs;

    private void Reset()
    {
        _health = 1;
    }

    void TakeDamage()
    {
        _health--;
        if (_health <= 0)
        {
            DropBonus();
            Destroy(gameObject);
        }
    }

    void DropBonus()
    {
        bool canDrop = Random.Range(0, 1) <= _chanceToDropBonus;
        if (canDrop && _bonusPrefabs.Length > 0)
        {
            int indexBonus = Random.Range(0, _bonusPrefabs.Length);
            Instantiate(_bonusPrefabs[indexBonus], transform.position, Quaternion.identity);
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
