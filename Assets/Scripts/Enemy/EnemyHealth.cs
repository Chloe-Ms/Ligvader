
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _points;
    [SerializeField] float _health;
    public float CurrentHealth
    {
        get { return _health; }
        set {
            _health = value;
            if (_health < 0)
            {
                _health = 0;
            }
        }
    }
    [SerializeField] float _chanceToDropBonus;
    [SerializeField] GameObject[] _bonusPrefabs;
    PlayerBonus _bonusScript;
    Score _scoreScript;
    bool _isInLaser = false;
    float _damageFromPlayer = 0f;

    private void Reset()
    {
        _health = 1f;
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
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (_health <= 0f)
        {

            _scoreScript.AddAmountToScore(_points);
            DropBonus();

            if (transform.parent != null && transform.parent.tag == "MobileEnemyPattern")
            {
                Destroy(transform.parent.gameObject);
            }
            //Cas avec le shield
            else if (transform.parent != null && transform.parent.transform.parent != null && transform.parent.transform.parent.tag == "StaticEnemyPattern"
                && transform.parent.tag == "ShieldEnemy")
            {
                if (transform.parent.transform.parent.childCount == 1)
                {
                    Debug.Log("AA");
                    Destroy(transform.parent.transform.parent.gameObject);
                    LoaderEnemies.Instance.LoadNewStaticEnemies();
                } else
                {
                    Debug.Log("BB");
                    Destroy(transform.parent.gameObject);
                }
            }
            else if (transform.parent != null && transform.parent.tag == "StaticEnemyPattern" && transform.parent.childCount == 1)
            {
                Debug.Log("CC");
                Destroy(transform.parent.gameObject);
                LoaderEnemies.Instance.LoadNewStaticEnemies();
            } else
            {
                Debug.Log("DD");
                Destroy(gameObject);
            }
            
        }
    }

    void DropBonus()
    {
        bool canDrop = Random.Range(0, 1) <= _chanceToDropBonus;
        if (canDrop && _bonusPrefabs.Length > 0 && _bonusScript.GetBonusesSize() > 0)
        {
            int indexBonus;
            //indexBonus = 4;
            do
            {
                indexBonus = Random.Range(0, _bonusPrefabs.Length);
            } while (!_bonusScript.ContainsBonus(_bonusScript.GetBonusInEnumAt(indexBonus)));

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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerProjectile")
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    public void TakeContinuousDamage(float damagesPerSec)
    {
        _isInLaser = true;
        _damageFromPlayer = damagesPerSec;
    }

    public void StopContinuousDamage()
    {
        _isInLaser = false;
    }

    private void Update()
    {
        if (_isInLaser)
        {
            _health -= _damageFromPlayer * Time.deltaTime;
            CheckDeath();
        }
    }
}
