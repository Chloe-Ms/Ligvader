using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBonus : Bonus
{
    [Range(1f, 100f)]
    [SerializeField] float _projectileSizeMultiplier;

    public override void ApplyBonus(PlayerBonus plBonus)
    {
        plBonus.ApplyRedBonus(_projectileSizeMultiplier);
    }

}
