using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    public GameObject shopPanel; 
    private int currentItemSelected;
    private int itemCost;
    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player = other.GetComponent<Player>();
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
        UIManager.UInstance.selectionImg.enabled = true;
        switch (item)
        {
            case 0: // flame sword
                UIManager.UInstance.UpdateShopSelection(87);
                currentItemSelected = 1;
                itemCost = 200;
                break;
            case 1: // flame sword
                UIManager.UInstance.UpdateShopSelection(-1);
                currentItemSelected = 2;
                itemCost = 400;
                break;
            case 2: // flame sword
                UIManager.UInstance.UpdateShopSelection(-109);
                currentItemSelected = 3;
                itemCost = 100;
                break;
        }
    }


    public void BuyItem()
    {
        if (player.playerDiamondAmount >= itemCost)
        {
            switch (currentItemSelected)
            {
                case 1: // flame sword
                    itemCost = 200;
                    break;
                case 2: // flame sword
                    itemCost = 400;
                    break;
                case 3: // flame sword
                    itemCost = 100;
                    break;
                default:
                    Debug.Log("Please Select an item");
                    break;
            }
            //shopPanel.SetActive(false);
            //Award Item if purchased only
            player.playerDiamondAmount= player.playerDiamondAmount - itemCost;
            UIManager.UInstance.playerGemCountText.text = (player.playerDiamondAmount + "G");
            Debug.Log("Player has purchased " + currentItemSelected + " For: " + itemCost);
        }
        else
        {
            Debug.Log("Player Does not have enought Diamonds. They have " + player.playerDiamondAmount);
            shopPanel.SetActive(false);
        }
    }
}
