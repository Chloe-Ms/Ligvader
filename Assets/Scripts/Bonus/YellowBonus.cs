using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBonus : Bonus
{
    
    [SerializeField] private float _duration = 20f;

    private void Reset()
    {
        _duration = 20f;
    }

    public override void ApplyBonus(PlayerBonus plBonus)
    {
        plBonus.ApplyYellowBonus(_duration);
    }
}
