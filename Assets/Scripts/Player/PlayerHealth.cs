using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerBonus _playerBonus; 
    [SerializeField] GameObject _explosionPlayer;
    int _health = 1;
    PolygonCollider2D collider;

    public int Health { get { return _health; } }

    private void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
    }

    public void TakeDamage()
    {
        GameObject go = Instantiate(_explosionPlayer, new Vector3(0f,0f,0f),Quaternion.identity);
        go.transform.SetParent(transform, false);

        if (_playerBonus != null)
        {
            //If the player has no power up
            if (_playerBonus.GetBonusesSize() == _playerBonus.GetSizeBonusEnum())
            {
                _health--;
            }
            _playerBonus.ClearBonuses();
            StartCoroutine(Invicibility());

        } else
        {
            _health--;
        }
        
        
        if (_health <= 0)
        {
            _playerBonus.Die();
            StartCoroutine(StartEndScene());
        }
    }

    IEnumerator Invicibility()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(.5f);
        collider.enabled = true;

    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("EndScene");
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
