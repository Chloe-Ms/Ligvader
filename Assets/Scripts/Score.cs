using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    private static Score _instance;
    [SerializeField]
    FloatSO _score;
    
    [SerializeField] TextMeshProUGUI _scoreText;

    public static Score Instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);

        _instance = this;
    }

    private void Start()
    {
        _score.Value = 0;
    }

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
