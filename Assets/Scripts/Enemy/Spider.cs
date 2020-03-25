using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamageable
{

    public GameObject acidEffectPrefab;
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public override void Update()
    {
        
    }

    public void Damage()
    {
        Health--;
        if (Health <1)
        {
            Destroy(gameObject);
        }
    }

    public override void Movement()
    {
        //Sit Still
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab,transform.position,Quaternion.identity);
    }


}
