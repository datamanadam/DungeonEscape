﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager UInstance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UI manager is Null!");
            }
            return _instance;
        }
    }

    public Text playerGemCountText;
    public Image selectionImg;
    public Text gemCountText;
    public Image[] playerHealthBars;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        //loop through lives
        for(int i = 0; i <= livesRemaining; i++)
        {
            if(i == livesRemaining)
            {
                playerHealthBars[i].enabled = false;
            }
            else { }
        }

    }



}
