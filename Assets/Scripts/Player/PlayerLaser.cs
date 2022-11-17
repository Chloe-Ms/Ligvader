using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [SerializeField] private float _damagesPerSecond = 1f;
    [SerializeField] private Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.TakeContinuousDamage(_damagesPerSecond);
        }

        FeedbackLaser feedback = collision.gameObject.GetComponent<FeedbackLaser>();
        if (feedback != null && _collider != null)
        {
            feedback.StartFeedback(_collider);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.StopContinuousDamage();
        }

        FeedbackLaser feedback = collision.gameObject.GetComponent<FeedbackLaser>();
        if (feedback != null && _collider != null)
        {
            feedback.StopFeedBack();
        }
    }
}
