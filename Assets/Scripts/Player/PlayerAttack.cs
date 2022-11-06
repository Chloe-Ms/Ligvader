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
    private Vector3 _projectileSize;
    private Vector3 _currentProjectileSize;

    private void Start()
    {
        if (_projectilePrefab != null)
        {
            _projectileSize = _projectilePrefab.transform.localScale; //Get the normal size to resize projectiles when the bonus is lost
            _currentProjectileSize = _projectilePrefab.transform.localScale;
        }
        
    }

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
        Projectile proj = Instantiate(_projectilePrefab, _spawnsTransform[index].position,Quaternion.identity);
        proj.gameObject.transform.localScale = _currentProjectileSize;
        yield return new WaitForSeconds(_timeToReload);
        _canShoot = true;
    }

    public void MultiplyProjectileSize(float newProjectileSize)
    {
        _currentProjectileSize = _projectileSize * newProjectileSize;
    }

    public void ResetProjectileSize()
    {
        _currentProjectileSize = _projectileSize;
    }
}
