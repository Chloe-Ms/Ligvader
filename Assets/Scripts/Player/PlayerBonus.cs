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
    [SerializeField] PlayerMovement _movementScript;
    [SerializeField] private GameObject _shield;
    List<BonusType> _bonuses;
    //YELLOW
    private float _durationY;
    private float _currentDurationY;
    private bool _isActiveY = false;
    //GREEN
    private float _durationG;
    private float _currentDurationG;
    private bool _isActiveG = false;

    void Start()
    {
        _bonuses = new List<BonusType>();
        foreach(BonusType bonus in Enum.GetValues(typeof(BonusType)))
        {
            _bonuses.Add(bonus);
        }
    }

    public void ApplyRedBonus(float sizeMultiplier)
    {
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

    public void ApplyBlackBonus()
    {
        if (_bonuses.Contains(BonusType.BLACK))
        {
            _bonuses.Remove(BonusType.BLACK);
            _movementScript.SetCanMoveVertically(true);
            _attackScript.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            Debug.Log("noir déjà fait");
        }
    }

    public void ApplyBlueBonus()
    {
        if (_bonuses.Contains(BonusType.BLUE))
        {
            _bonuses.Remove(BonusType.BLUE);
            _attackScript.AddBlueBonus();
            _attackScript.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            Debug.Log("bleu déjà fait");
        }
    }

    public void ApplyYellowBonus(float duration)
    {
        if (_bonuses.Contains(BonusType.YELLOW))
        {
            
            _bonuses.Remove(BonusType.YELLOW);
            _durationY = duration;
            StartTimerBonusY();
            _attackScript.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            Debug.Log("jaune déjà fait");
        }
    }

    public void ApplyGreenBonus()
    {
        if (_bonuses.Contains(BonusType.GREEN))
        {
            _bonuses.Remove(BonusType.GREEN);

            _attackScript.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            Debug.Log("vert déjà fait");
        }
    }
    public void ClearBonuses()
    {
        foreach (BonusType bonus in Enum.GetValues(typeof(BonusType)))
        {
            _bonuses.Add(bonus);
        }
        //RED && BLUE
        _attackScript.ResetOutputProjectile();
        //BLACK
        _movementScript.ResetMovementVertically();
        //YELLOW
        EndTimerBonusY();
        //GREEN
        EndTimerBonusG();
    }

    public void StartTimerBonusY()
    {
        _currentDurationY = 0f;
        _isActiveY = true;
        _shield.SetActive(true);
    }

    public void StartTimerBonusG()
    {
        _currentDurationG = 0f;
        _isActiveG = true;
    }
    public void EndTimerBonusY()
    {
        _isActiveY = false;
        _shield.SetActive(false);
        _bonuses.Add(BonusType.YELLOW);
    }

    public void EndTimerBonusG()
    {
        _isActiveG = false;
        _bonuses.Add(BonusType.GREEN);
    }

    #region LIST BONUS
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
    public int GetSizeBonusEnum()
    {
        Array values = Enum.GetValues(typeof(BonusType));
        return values.Length;
    }
    #endregion

    private void Update()
    {
        if (_isActiveY)
        {
            if (_currentDurationY < _durationY)
            {
                _currentDurationY += Time.deltaTime;
            }
            else
            {
                EndTimerBonusY();
            }
        }
        if (_isActiveG)
        {
            if (_currentDurationG < _durationG)
            {
                _currentDurationG += Time.deltaTime;
            }
            else
            {
                EndTimerBonusG();
            }
        }
    }
}
