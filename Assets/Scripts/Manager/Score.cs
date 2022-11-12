using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField]
    FloatSO _score;
    
    [SerializeField] TextMeshProUGUI _scoreText;

    void Update()
    {
        if (_scoreText != null)
        {
            _scoreText.text = _score.Value+ "";
        }
    }

    public void AddAmountToScore(int amount)
    {
        _score.Value += amount;
    }
}
