using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [SerializeField] private float _timeBeforeStart;
    [SerializeField] private float _damagesBySecond;
    [SerializeField] private float _duration = 5f;
    private float _durationLeftActivation;
    private float _durationLeft;
    private bool _isLaserActive = false;
    private bool _isStartingLaser = false;
     

    void StartLaser()
    {
        _durationLeftActivation = 0f;
        _isStartingLaser = true;
    }

    void StopLaser()
    {
        _durationLeftActivation = 0f;
        _isStartingLaser = false;
        _isLaserActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (_isStartingLaser)
        {
            _durationLeftActivation += Time.deltaTime;
            if(_durationLeftActivation > _timeBeforeStart)
            {
                _isLaserActive = true;
                _isStartingLaser = false;
            }
        }
        if (_isLaserActive)
        {
            _durationLeft += Time.deltaTime;
            if (_durationLeft > _duration)
            {
                _durationLeft = 0f;
                _isLaserActive = false;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _durationLeft = 0f;
        EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
        if (health != null)
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
