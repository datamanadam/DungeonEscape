using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private Player player;
    private int healthBeforeFalling;

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<Player>();
        healthBeforeFalling = player.Health;
        print(player.Health);

        for (int x=0; x< healthBeforeFalling; x++)
        {
            print(player.Health);
            player.Damage();
        }

    }

}
