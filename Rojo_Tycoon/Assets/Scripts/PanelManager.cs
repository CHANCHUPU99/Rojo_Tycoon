using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{

    public GameObject buttonToDisable;
    public GameObject panelTwoTeams;
    public GameObject panelThreeTeams;

    public void ShowPanel(bool twoTeams)
    {
        if (twoTeams)
        {
            buttonToDisable.SetActive(false);
            panelTwoTeams.SetActive(true);
            panelThreeTeams.SetActive(false);
        }
        else
        {
            buttonToDisable.SetActive(false);
            panelThreeTeams.SetActive(true);
            panelTwoTeams.SetActive(false);
        }
    }
}
