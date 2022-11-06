using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] float _speed;

    public abstract void ApplyBonus(PlayerBonus plBonus);

    void Update()
    {
        transform.position += new Vector3(0f, -_speed * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerBonus plBonus = collision.gameObject.GetComponent<PlayerBonus>();
            ApplyBonus(plBonus);
        }
    }

}