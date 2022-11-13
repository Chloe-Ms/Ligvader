
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _points;
    [SerializeField] float _health;
    [SerializeField] float _chanceToDropBonus;
    [SerializeField] GameObject[] _bonusPrefabs;
    FollowPath _followScript;
    PlayerBonus _bonusScript;
    Score _scoreScript;
    bool _isInLaser = false;
    float _damageFromPlayer = 0f;
    private Renderer _renderer;
    private Vector2 _screenBounds;
    [SerializeField] GameObject _explosionPrefab;
    [SerializeField] GameObject _impactPrefab;

    public float CurrentHealth
    {
        get { return _health; }
        set
        {
            _health = value;
            if (_health < 0)
            {
                _health = 0;
            }
        }
    }

    private void Reset()
    {
        _health = 1f;
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _followScript = GetComponent<FollowPath>();
    }

    private void Start()
    {
        _bonusScript = GameObject.Find("Player").GetComponent<PlayerBonus>();
        _scoreScript = GameObject.Find("ScoreManager").GetComponent<Score>();
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
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
            LoaderEnemies.Instance.CheckLoadEnemies(gameObject);
            DestroyEnemy();
        }
    }

    void DropBonus()
    {
        bool canDrop = Random.Range(0f, 1f) <= _chanceToDropBonus;
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
            if (_health > 1f)
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
            if (_health > 1f)
            {
                Instantiate(_impactPrefab, collision.transform.position, Quaternion.identity);
            }
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

        //Outside game screen (lower than the screen)
        if (transform.position.y + (_renderer.bounds.size.y / 2f) < -_screenBounds.y)
        {
            EnemyEscape();
        }
    }

    public void DestroyEnemy()
    {

        if (transform.parent != null && transform.parent.tag == "MobileEnemyPattern")
        {
            //Debug.Log("ZZ");
            Destroy(transform.parent.gameObject);
        }
        //Cas avec le shield
        else if (transform.parent != null && transform.parent.transform.parent != null && transform.parent.transform.parent.tag == "StaticEnemyPattern"
            && transform.parent.tag == "ShieldEnemy")
        {
            if (transform.parent.transform.parent.childCount == 1)
            {
                //Debug.Log("AA");
                Destroy(transform.parent.transform.parent.gameObject);
                LoaderEnemies.Instance.LoadNewStaticEnemies();
            }
            else
            {
                //Debug.Log("BB");
                Destroy(transform.parent.gameObject);
            }
        }
        else if (transform.parent != null && transform.parent.tag == "StaticEnemyPattern" && transform.parent.childCount == 1)
        {
            //Debug.Log("CC");
            Destroy(transform.parent.gameObject);
            LoaderEnemies.Instance.LoadNewStaticEnemies();
        }
        else
        {
            //Debug.Log("DD");
            Destroy(gameObject);
        }
        if (_explosionPrefab != null)
            Instantiate(_explosionPrefab,transform.position,Quaternion.identity);
    }

    public void EnemyEscape()
    {
        _scoreScript.RemoveAmountToScore(_points);
        DestroyEnemy();
    }
}
