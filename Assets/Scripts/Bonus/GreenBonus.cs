using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBonus : Bonus
{
    [SerializeField] float _speedReductionGreenBonus;
    [SerializeField] float _duration = 5f;
    public override void ApplyBonus(PlayerBonus plBonus)
    {
        plBonus.ApplyGreenBonus(_speedReductionGreenBonus,_duration);
    }
}
