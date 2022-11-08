
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _points;
    [SerializeField] int _health;
    [SerializeField] float _chanceToDropBonus;
    [SerializeField] GameObject[] _bonusPrefabs;
    PlayerBonus _bonusScript;
    Score _scoreScript;

    private void Reset()
    {
        _health = 1;
    }

    private void Start()
    {
        _bonusScript = GameObject.Find("Player").GetComponent<PlayerBonus>();
        _scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();
    }

    void OnValidate()
    {
        if (_points < 0) _points = 0;
    }

    public void TakeDamage()
    {
        _health--;
        if (_health <= 0)
        {
            if (_scoreScript != null)
            {
                _scoreScript.AddAmountToScore(_points);
            }
            DropBonus();
            Destroy(gameObject);
        }
    }

    void DropBonus()
    {
        if (_scoreScript != null)
        {
            bool canDrop = Random.Range(0, 1) <= _chanceToDropBonus;
            if (canDrop && _bonusPrefabs.Length > 0 && _bonusScript.GetBonusesSize() > 0)
            {
                int indexBonus;
                do
                {
                    indexBonus = Random.Range(0, _bonusPrefabs.Length);
                } while (!_bonusScript.ContainsBonus(_bonusScript.GetBonusInEnumAt(indexBonus)));

                Instantiate(_bonusPrefabs[indexBonus], transform.position, Quaternion.identity);
            }
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
