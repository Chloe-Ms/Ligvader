using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _timeToReload;
    private bool _canShoot = true;
    [SerializeField] private Transform[] _spawnsTransform;

    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Animator _animatorCanon;
    [SerializeField] private Projectile _bigProjectilePrefab;
    private int _nbOutputProjectile;
    private bool _isOutputInside = true;
    private Vector3 _projectileSize;
    private Vector3 _currentProjectileSize;
    private bool _isLaserActive = false;
    private bool _inMenu = false;
    public bool IsLaserActive
    {
        set { _isLaserActive = value; }
    }

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
        if (_canShoot && _spawnsTransform.Length > 0 && !_inMenu)
        {
            if ((_nbOutputProjectile == 3 && _isOutputInside) || _nbOutputProjectile == 5)
            { //Red bonus, bigger size
                _animatorCanon.SetTrigger("Attack");
            }
            _canShoot = false;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot(){
        if (_spawnsTransform.Length >= _nbOutputProjectile) //If number of outputs is bigger than number of transform
        {
            if (!_isLaserActive)
            {
                Instantiate(_projectilePrefab, _spawnsTransform[0].position, Quaternion.identity);
            }
            if ((_nbOutputProjectile == 3 && _isOutputInside) || _nbOutputProjectile == 5)
                { //Red bonus, bigger size
                    Instantiate(_bigProjectilePrefab, _spawnsTransform[1].position, Quaternion.identity);
                    Instantiate(_bigProjectilePrefab, _spawnsTransform[2].position, Quaternion.identity);
                }

                if ((_nbOutputProjectile == 3 && !_isOutputInside) || _nbOutputProjectile == 5) //Blue bonus, same size
                {
                    Instantiate(_projectilePrefab, _spawnsTransform[3].position, Quaternion.identity);
                    Instantiate(_projectilePrefab, _spawnsTransform[4].position, Quaternion.identity);
                }
            yield return new WaitForSeconds(_timeToReload);
            _canShoot = true;
        }

    }

    public void MultiplyProjectileSize(float newProjectileSize)
    {
        _currentProjectileSize = _projectileSize * newProjectileSize;
    }

    public void AddRedBonus()
    {
        if (_nbOutputProjectile <= 5)
        {
            _nbOutputProjectile += 2;
            if (_nbOutputProjectile == 3)
            {
                _isOutputInside = true;
            }
        }
    }

    public void AddBlueBonus()
    {
        if (_nbOutputProjectile <= 5)
        {
            _nbOutputProjectile += 2;
            if (_nbOutputProjectile == 3)
            {
                _isOutputInside = false;
            }
        }
    }

    public void ResetOutputProjectile()
    {
        _nbOutputProjectile = 1;
    }
    public void SetInMenu(bool isInMenu)
    {
        _inMenu = isInMenu;
    }
}
