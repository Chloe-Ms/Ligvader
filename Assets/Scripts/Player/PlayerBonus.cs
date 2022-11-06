using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonus : MonoBehaviour
{
    List<Bonus> _bonuses;
    [SerializeField] float _sizeMultiplier;

    void Start()
    {
        _bonuses = new List<Bonus>();
    }

    public void ApplyRedBonus()
    {

    }

    void ClearBonuses()
    {
        _bonuses.Clear();
    }
}
