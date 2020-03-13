using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private bool canAttack = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit!= null)
        {
            if (canAttack)
            {
                hit.Damage();
                //Debug.Log("HIT" + other.name);
                canAttack = false;
                StartCoroutine(RestCanAttack());
            }
        }

        IEnumerator RestCanAttack()
        {
            yield return new WaitForSeconds(0.5f);
            canAttack = true;
        }


    }

}
