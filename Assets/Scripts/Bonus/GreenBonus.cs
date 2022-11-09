using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBonus : Bonus
{
    public override void ApplyBonus(PlayerBonus plBonus)
    {
        plBonus.ApplyGreenBonus();
    }
}
