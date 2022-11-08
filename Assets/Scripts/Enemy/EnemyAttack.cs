using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float _timeToReload;
    [Range(0f, 1f)]
    [SerializeField] float _chanceToShoot;
    bool _canAttack = true;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Transform _spawnPosition;
    void Start()
    {
        StartCoroutine(Attack());
    }


    IEnumerator Attack()
    {
        while (_canAttack)
        {
            yield return new WaitForSeconds(_timeToReload);
            Shoot();
        }
    }

    void Shoot()
    {
        bool canShoot = Random.Range(0f, 1f) <= _chanceToShoot;
        if (canShoot)
        {
            Instantiate(_projectilePrefab, _spawnPosition.position, Quaternion.Euler(0, 0, 180)); //180 no scope
        }
    }
}
