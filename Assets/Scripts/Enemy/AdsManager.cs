using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("rewardedVideo", options);
        }

    }






    void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ads Completed Sucessfully");
                break;
            case ShowResult.Skipped:
                Debug.Log("You Skipped the Ad");
                break;
            case ShowResult.Failed:
                Debug.Log("AD FAILED");
                break;


        }
    }


}
