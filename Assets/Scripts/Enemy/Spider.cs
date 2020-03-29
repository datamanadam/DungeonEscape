﻿using System.Collections;
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
            isDead = true;
            animator.SetTrigger("Death");
            animator.SetTrigger("Death");
            Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamondPrefab.gems = gems;
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
