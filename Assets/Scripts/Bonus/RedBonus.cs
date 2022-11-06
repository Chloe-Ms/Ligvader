using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBonus : Bonus
{
    public override void ApplyBonus(PlayerBonus plBonus)
    {
        plBonus.ApplyRedBonus();
    }

}
