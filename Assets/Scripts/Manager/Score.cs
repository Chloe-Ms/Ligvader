using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] FloatSO _score;
    [SerializeField] FloatSO _highscore;

    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _highscoreText;

    void Update()
    {
        if (_scoreText != null)
        {
            _scoreText.text = _score.Value+ "";
        }
        if (_highscoreText != null)
        {
            _highscoreText.text = _highscore.Value + "";
        }
    }

    public void AddAmountToScore(int amount)
    {
        if (amount >= 0)
        _score.Value += amount;
    }

    public void RemoveAmountToScore(int amount)
    {
        if (amount >= 0)
            _score.Value -= amount;
    }
}
