using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int _score = 0;
    
    [SerializeField] TextMeshProUGUI _scoreText;
   void Start()
    {
        
    }

    void Update()
    {
        if (_scoreText != null)
        {
            _scoreText.text = _score+"";
        }
    }

    public void AddAmountToScore(int amount)
    {
        _score += amount;
    }
}
