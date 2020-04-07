using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public GameObject shopPanel; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player!= null)
            {
                UIManager.UInstance.OpenShop(player.playerDiamondAmount);
            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        // 0 flame sword
        // 2 boots of light
        //3 key to castle
        Debug.Log("Button Selected" + item);

        switch (item)
        {
            case 0: // flame sword
                UIManager.UInstance.UpdateShopSelection(87);
                break;
            case 1: // flame sword
                UIManager.UInstance.UpdateShopSelection(-1);
                break;
            case 2: // flame sword
                UIManager.UInstance.UpdateShopSelection(-109);
                break;
        }

       

    }
}
