using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Instantiate : MonoBehaviour
{
    public GameObject[] buttons;
    public TMP_Text text;
    public TMP_Text text2;  
    int randomNumber;   
    int randomNumberTwo;
    public GeneralProgression progression;

    public ActivitiesManager[] activitiesManager;
    public ActivitiesManager[] activitiesManagerTwo;

    public GameObject buttonOne;
    public GameObject buttonTwo;

    [HideInInspector]
    public int numberOfChanges;

    [HideInInspector]
    public int activitiesLeftPerTeam = 5;
    int ActualTeam = 1;
    [HideInInspector]
    public bool isTeamTwo = false;

    public TeamSelection teamSelection;

    public TimeManager timeManager;

    void Start()
    {
        RandomActivity();
    }

    private void Update()
    {
        if(activitiesLeftPerTeam <= 0)
        {
            isTeamTwo = !isTeamTwo;
            ChangeTeam(isTeamTwo);
            print("cambio equipo");
            activitiesLeftPerTeam = 4;
        }
    }

    public void RandomActivity()
    {
        randomNumber = Random.Range(0, activitiesManager.Length);
        text.text = activitiesManager[randomNumber].activity;
        randomNumberTwo = Random.Range(0, activitiesManagerTwo.Length);
        text2.text = activitiesManagerTwo[randomNumberTwo].activity;

        buttonOne.SetActive(true);
        buttonTwo.SetActive(true);

        activitiesLeftPerTeam--;

        StartCoroutine(SlowBoolForTeamNames());
        
    }

    // Corrutina para alentar la función de ShowTeamNames
    IEnumerator SlowBoolForTeamNames()
    {

        yield return new WaitForSeconds(.1f*Time.deltaTime);
        teamSelection.ShowTeamNames(isTeamTwo);
    }

    public void TurnOffButton()
    {
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false); 
    }
    public void AddProgressButtonOne()
    {
        print("boton uno");
       if(isTeamTwo == false)
       {
            ActualTeam = 1;
       }
       else
       {
           ActualTeam = 2;
       }
       progression.RefreshSlider(activitiesManager[randomNumber].progressValue, ActualTeam);
       TurnOffButton();
    }

    public void AddProgressButtonTwo()
    {
        print("boton dos");
        if (isTeamTwo == false)
        {
            ActualTeam = 1;
        }
        else
        {
            ActualTeam = 2;
        }
        progression.RefreshSlider(activitiesManagerTwo[randomNumberTwo].progressValue, ActualTeam);
        TurnOffButton();
    }

    void ChangeTeam(bool isTeamTwo)
    {
        progression.ReadOnJSON(isTeamTwo);

        numberOfChanges++;

        timeManager.CheckChangeTeam(numberOfChanges);
    }
}
