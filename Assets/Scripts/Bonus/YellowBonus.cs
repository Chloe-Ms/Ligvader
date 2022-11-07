using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBonus : Bonus
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private float _duration;

    private void Reset()
    {
        _duration = 20f;
    }

    public override void ApplyBonus(PlayerBonus plBonus)
    {
        throw new System.NotImplementedException();
    }
}
