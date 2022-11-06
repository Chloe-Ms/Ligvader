using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _timeToReload;
    private bool _canShoot = true;
    [SerializeField] private Transform[] _spawnsTransform;

    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private int _nbOutputProjectile;

    void OnValidate() {
        if (_nbOutputProjectile < 1){
            _nbOutputProjectile = 1;
        }
    }

    void Reset() {
        _timeToReload = 0.4f;
    }

    void OnFire(){
        if (_canShoot && _spawnsTransform.Length > 0){
            _canShoot = false;
            StartCoroutine(Shoot(0));
        }
    }

    IEnumerator Shoot(int index){
        Instantiate(_projectilePrefab, _spawnsTransform[index].position,Quaternion.identity);
        yield return new WaitForSeconds(_timeToReload);
        _canShoot = true;
    }
}
