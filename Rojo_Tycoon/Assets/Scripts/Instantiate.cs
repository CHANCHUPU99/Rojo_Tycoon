using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Instantiate : MonoBehaviour
{
    public Transform pos;
    public Transform posi;
    public GameObject[] buttons;
    public TMP_Text text;
    public TMP_Text text2;  
    int randomNumber;   
    int randomNumberTwo;
    public GeneralProgression progression;

    public ActivitiesManager[] activitiesManager;
    public ActivitiesManager[] activitiesManagerTwo;
  
    void Start()

    {
        RandomActivity();
        //InstantiateButton();
    }    

    public void RandomActivity()
    {
        randomNumber = Random.Range(0,activitiesManager.Length);
        text.text = activitiesManager[randomNumber].activity;
        

        randomNumberTwo=Random.Range(0,activitiesManagerTwo.Length);
        text2.text = activitiesManagerTwo[randomNumberTwo].activity;
    }
    public void AddProgressButtonOne()
    {
        progression.RefreshSlider(activitiesManager[randomNumber].progressValue);
        
    }

    public void AddProgressButtonTwo()
    {
        progression.RefreshSlider(activitiesManagerTwo[randomNumberTwo].progressValue);
    }

    void Update()
    {

    }
    
}
