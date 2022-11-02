using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _timeToReload;
    private bool _canShoot = true;

    [SerializeField] private Projectile _projectilePrefab;

    void Reset() {
        _timeToReload = 0.4f;
    }

    void OnFire(){
        if (_canShoot){
            _canShoot = false;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot(){
        Instantiate(_projectilePrefab, transform.position,Quaternion.identity);
        yield return new WaitForSeconds(_timeToReload);
        _canShoot = true;
    }
}
