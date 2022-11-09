using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBonus : Bonus
{
    [SerializeField] float _speedReductionGreenBonus;
    public override void ApplyBonus(PlayerBonus plBonus)
    {
        plBonus.ApplyGreenBonus(_speedReductionGreenBonus);
    }
}
