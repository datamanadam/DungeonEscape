using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }



    public override void Init()
    {
        base.Init();
        Health = base.health;

    }

    public override void Movement()
    {
        base.Movement();
        float distance = Vector3.Distance(player.transform.localPosition, transform.position);

        Vector3 direction = player.transform.localPosition - transform.localPosition;
        //Debug.Log("side: " + direction.x);

        if (animator.GetBool("InCombat") == true)
        {
            if (direction.x >= 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
    }

    public void Damage()
    {
        Health--;
        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("InCombat", true);

        if (Health < 1)
        {
            Destroy(gameObject);
        }

    }
}
