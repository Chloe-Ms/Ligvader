using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [SerializeField] private float _damagesBySecond = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.TakeContinuousDamage(_damagesBySecond);
            Debug.Log(health.CurrentHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.StopContinuousDamage();
            Debug.Log(health.CurrentHealth);
        }
    }
}
