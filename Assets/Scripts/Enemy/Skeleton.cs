using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        Debug.Log("Skeleton:Damage()");
        Health--;
        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("InCombat", true);

        if (Health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
            animator.SetTrigger("Death");
            Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamondPrefab.gems = gems;
        }
    }
}
