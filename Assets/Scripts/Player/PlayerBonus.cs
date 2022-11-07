using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BonusType
{
    BLUE,
    RED,
    BLACK,
    GREEN,
    YELLOW
}
public class PlayerBonus : MonoBehaviour
{
    [SerializeField] PlayerAttack _attackScript;
    List<BonusType> _bonuses;
    

    void Start()
    {
        _bonuses = new List<BonusType>();
        foreach(BonusType bonus in Enum.GetValues(typeof(BonusType)))
        {
            _bonuses.Add(bonus);
        }
        Debug.Log("count " + _bonuses.Count);
    }

    public void ApplyRedBonus(float sizeMultiplier)
    {
        /*foreach (var bonus in _bonuses)
        {
            Debug.Log(bonus);
        }
        Debug.Log(_bonuses.Contains(BonusType.RED));*/
        if (_bonuses.Contains(BonusType.RED))
        {
            _bonuses.Remove(BonusType.RED);
            _attackScript.MultiplyProjectileSize(sizeMultiplier);
            _attackScript.AddRedBonus();
            _attackScript.GetComponent<SpriteRenderer>().color = Color.red;
        } else
        {
            Debug.Log("rouge déjà fait");
        }
    }

    public void ClearBonuses()
    {
        foreach (BonusType bonus in _bonuses)
        {
            _bonuses.Add(bonus);
        }
        //RED && BLUE
        _attackScript.ResetOutputProjectile();
    }

    public void ApplyBlueBonus()
    {
        /*foreach (var bonus in _bonuses)
        {
            Debug.Log(bonus);
        }
        Debug.Log(_bonuses.Contains(BonusType.BLUE));*/
        if (_bonuses.Contains(BonusType.BLUE))
        {
            _bonuses.Remove(BonusType.BLUE);
            _attackScript.AddBlueBonus();
            _attackScript.GetComponent<SpriteRenderer>().color = Color.blue;
        } else
        {
            Debug.Log("bleu déjà fait");
        }
    }

    public int GetBonusesSize()
    {
        return _bonuses.Count;
    }

    public BonusType GetBonusAt(int index)
    {
        return _bonuses[index];
    }

    public void AddBonus(BonusType type)
    {
        if (!_bonuses.Contains(type)) //We had the bonus if it isn't in the list already
        {
            _bonuses.Add(type);
        }
    }

    public bool ContainsBonus(BonusType type)
    {
        return _bonuses.Contains(type);
    }

    public BonusType GetBonusInEnumAt(int index)
    {
        Array values = Enum.GetValues(typeof(BonusType));
        return (BonusType) values.GetValue(index);
    }
}
