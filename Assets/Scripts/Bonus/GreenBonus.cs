using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBonus : Bonus
{
    [SerializeField] private float _timeBeforeStart;
    [SerializeField] private float _damagesBySecond;
    [SerializeField] private float _duration = 5f;
    private float currentDuration = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public override void ApplyBonus(PlayerBonus plBonus)
    {
        plBonus.ApplyGreenBonus();
    }
}
