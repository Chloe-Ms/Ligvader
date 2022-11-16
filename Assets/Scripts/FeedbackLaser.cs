using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackLaser : MonoBehaviour
{
    [SerializeField] private GameObject _feedback;
    private Collider2D _laserCollider = null;
    [SerializeField] private Collider2D _enemyCollider;

    void MoveFeedback()
    {
        if (_laserCollider != null && _enemyCollider != null && _feedback != null)
        {
            Vector2 pos;
            pos.x = Mathf.Clamp(_laserCollider.gameObject.transform.position.x,_enemyCollider.bounds.min.x, _enemyCollider.bounds.max.x);
            pos.y = _enemyCollider.bounds.min.y;
            _feedback.transform.position = pos;
        }
    }

    public void StartFeedback(Collider2D _collider)
    {
        _laserCollider = _collider;
        _feedback.SetActive(true);
        MoveFeedback();
    }

    public void StopFeedBack()
    {
        _feedback.SetActive(false);
        _laserCollider = null;
    }

    private void Update()
    {
        MoveFeedback();
    }
}
