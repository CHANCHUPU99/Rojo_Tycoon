using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    bool teamDecisionsMade;
    int daysLeft;

    public Instantiate instantiate;
    public TMP_Text daysText;

    // 10 days

    private void Start()
    {
        daysLeft = 10;
        daysText.text = daysLeft.ToString();
    }

 

    public void CheckChangeTeam(int numberOfChanges)
    {
        if(numberOfChanges%2 == 0)
        {
            daysLeft--;
        }
        daysText.text = daysLeft.ToString();
    }
}
