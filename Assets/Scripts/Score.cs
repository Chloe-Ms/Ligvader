using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
   int _score = 0;
   void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddAmountToScore(int amount)
    {
        _score += amount;
    }
}
