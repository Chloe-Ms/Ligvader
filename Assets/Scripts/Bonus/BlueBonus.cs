using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBonus :Bonus
{
    public override void ApplyBonus(PlayerBonus plBonus)
    {
        plBonus.ApplyBlueBonus();
    }
}
