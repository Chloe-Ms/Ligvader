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
    [SerializeField] private GameObject _shield,_moduleShield;
    [SerializeField] Score _scoreScript;
    List<BonusType> _bonuses;
    [SerializeField] int _pointsDoubleBonus = 1000;
    [SerializeField] Animator _animatorLaser;
    //YELLOW
    private float _durationY;
    private float _currentDurationY;
    private bool _isActiveY = false;
    //GREEN
    private float _durationG;
    private float _currentDurationG;
    private bool _isActiveG = false;
    [SerializeField] GameObject _laser, _moduleLaser;
    private float _durationLeftActivation;
    private bool _isStartingLaser = false;
    [SerializeField] private float _timeBeforeStartLaser;


    void Start()
    {
        _bonuses = new List<BonusType>();
        foreach(BonusType bonus in Enum.GetValues(typeof(BonusType)))
        {
            AddBonus(bonus);
        }
    }

    public void ApplyRedBonus(float sizeMultiplier)
    {
        if (_bonuses.Contains(BonusType.RED))
        {
            _bonuses.Remove(BonusType.RED);
            _attackScript.MultiplyProjectileSize(sizeMultiplier);
            _attackScript.AddRedBonus();
            //_attackScript.GetComponent<SpriteRenderer>().color = Color.red;
        } else
        {
            Debug.Log("rouge déjà fait");
            _scoreScript.AddAmountToScore(_pointsDoubleBonus);
        }
    }

    public void ApplyBlackBonus()
    {
        if (_bonuses.Contains(BonusType.BLACK))
        {
            _bonuses.Remove(BonusType.BLACK);
            _movementScript.SetCanMoveVertically(true);
            //_attackScript.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            Debug.Log("noir déjà fait");
            _scoreScript.AddAmountToScore(_pointsDoubleBonus);
            
        }
    }

    public void ApplyBlueBonus()
    {
        if (_bonuses.Contains(BonusType.BLUE))
        {
            _bonuses.Remove(BonusType.BLUE);
            _attackScript.AddBlueBonus();
            //_attackScript.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            Debug.Log("bleu déjà fait");
            _scoreScript.AddAmountToScore(_pointsDoubleBonus);
        }
    }

    public void ApplyYellowBonus(float duration)
    {
        if (_bonuses.Contains(BonusType.YELLOW))
        {
            _bonuses.Remove(BonusType.YELLOW);
            _durationY = duration;
            StartTimerBonusY();
            //_attackScript.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            Debug.Log("jaune déjà fait");
            _scoreScript.AddAmountToScore(_pointsDoubleBonus);
        }
    }

    public void ApplyGreenBonus(float multiplier,float duration)
    {
        if (_bonuses.Contains(BonusType.GREEN))
        {
            _bonuses.Remove(BonusType.GREEN);
            _durationG = duration;
            _attackScript.IsLaserActive = true;

            StartTimerBonusG();
            _movementScript.ChangeSpeed(multiplier);
            //_attackScript.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            Debug.Log("vert déjà fait");
            _scoreScript.AddAmountToScore(_pointsDoubleBonus);
        }
    }
    public void ClearBonuses()
    {
        foreach (BonusType bonus in Enum.GetValues(typeof(BonusType)))
        {
            AddBonus(bonus);
        }
        //RED && BLUE
        _attackScript.ResetOutputProjectile();
        //BLACK
        _movementScript.ResetMovementVertically();
        //YELLOW
        EndTimerBonusY();
        //GREEN
        EndTimerBonusG();
        //AUGMENTER LA VITESSE
        _movementScript.ChangeSpeed(1f);
    }

    public void StartTimerBonusY()
    {
        _currentDurationY = 0f;
        _isActiveY = true;
        StartCoroutine(ActivateShield());
    }

    IEnumerator ActivateShield()
    {
        _moduleShield.SetActive(true);
        yield return new WaitForSeconds(1f);
        _shield.SetActive(true);
    }

    public void StartTimerBonusG()
    {
        _attackScript.IsLaserActive = true; //Player can't shoot when the laser is loading
        _isStartingLaser = true; //Start timer for loading the laser
        _durationLeftActivation = 0f; //Reset timer
        _moduleLaser.SetActive(true);
    }
    public void EndTimerBonusY()
    {
        _isActiveY = false;
        _shield.SetActive(false);
        _moduleShield.SetActive(false);
        AddBonus(BonusType.YELLOW);
        
    }

    public void EndTimerBonusG()
    {
        _isStartingLaser = false; //Laser is not starting
        _isActiveG = false; //Laser is not attacking
        _laser.SetActive(false); //Laser is not visible
        _moduleLaser.SetActive(false);
        _attackScript.IsLaserActive = false; //Not attacking anymore
        _currentDurationG = 0f;
        AddBonus(BonusType.GREEN);
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

        if (_isStartingLaser)
        {
            _durationLeftActivation += Time.deltaTime;
            if (_durationLeftActivation > _timeBeforeStartLaser)
            {
                _isStartingLaser = false; //Stop timer loading the laser
                _isActiveG = true; //Start timer laser
                _laser.SetActive(true); //Activate the gameObject
                _currentDurationG = 0f; //Reset timer laser attack
            }
        }
        if (_isActiveG)
        {
            _animatorLaser.SetTrigger("LaserAttack");
            _currentDurationG += Time.deltaTime;
            if (_currentDurationG > _durationG)
            {
                EndTimerBonusG();
            }
        }
    }
}
