using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBonus : Bonus
{
    [SerializeField] private float _timeBeforeStart;
    [SerializeField] private float _damagesBySecond;
    [SerializeField] private float _duration = 5f;

    public override void ApplyBonus(PlayerBonus plBonus)
    {
        plBonus.ApplyGreenBonus(_duration, _damagesBySecond,_timeBeforeStart);
    }
}
