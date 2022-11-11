using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [SerializeField] private float _damagesPerSecond = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.TakeContinuousDamage(_damagesPerSecond);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.StopContinuousDamage();
        }
    }
}
