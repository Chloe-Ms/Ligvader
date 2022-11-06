using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerBonus : MonoBehaviour
{
    [SerializeField] PlayerAttack _attackScript;
    //List<Bonus> _bonuses;

    void Start()
    {
        //_bonuses = new List<Bonus>();
    }

    public void ApplyRedBonus(float sizeMultiplier)
    {
        _attackScript.MultiplyProjectileSize(sizeMultiplier);
        _attackScript.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void ClearBonuses()
    {
        //_bonuses.Clear();
        //RED
        _attackScript.ResetProjectileSize();
        _attackScript.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
