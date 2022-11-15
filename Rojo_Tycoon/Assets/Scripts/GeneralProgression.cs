using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class GeneralProgression : MonoBehaviour
{
    Slider progressSlider;
    public float max;    
    public TextMeshProUGUI value;
    float maxValue = 100f;
    float porcentajeUno = 0f;
    float porcentajeDos = 0f;


    void Awake()
    {
        progressSlider = GetComponent<Slider>();    
    }
    public void Start()
    {
        ReadOnJSON(false);
    }
          
    public void RefreshSlider(float actualValue, int ActualTeam)
    {
        switch(ActualTeam)
        {
            case 1:
                ProgressSliderTeamOne(actualValue);
                break;
            case 2:
                ProgressSliderTeamTwo(actualValue);
                break;
            default: break;
        }  
    }

    public void WriteOnJSON(float progressTeamOne, float progressTeamTwo)
    {
        string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
        Teams teams = new Teams(progressTeamOne);
        string json = JsonUtility.ToJson(teams, true);
        File.WriteAllText(path, json);

        string pathTwo = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
        Teams teamsTwo = new Teams(progressTeamTwo);
        string jsonTwo = JsonUtility.ToJson(teamsTwo, true);
        File.WriteAllText(pathTwo, jsonTwo);
    }

    public void ReadOnJSON(bool isTeamTwo)
    {
        Debug.LogError("isTeamTwo on GP: " + isTeamTwo);
        if(isTeamTwo == false)
        {
            string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
            string json = File.ReadAllText(path);
            Teams teams = JsonUtility.FromJson<Teams>(json);
            porcentajeUno = teams.progress;
            progressSlider.value = porcentajeUno;
            value.text = Mathf.Round(porcentajeUno * 100) + "%";
        }
        else
        {
            string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
            string json = File.ReadAllText(path);
            Teams teams = JsonUtility.FromJson<Teams>(json);
            porcentajeDos = teams.progress;
            progressSlider.value = porcentajeDos;
            value.text = Mathf.Round(porcentajeDos * 100) + "%";
        }
    }

    void ProgressSliderTeamOne(float actualValue)
    {
        float addValue = 0f;
        addValue = actualValue / maxValue;
        porcentajeUno += addValue;
        progressSlider.value = porcentajeUno;
        value.text = Mathf.Round(porcentajeUno * 100) + "%";
        WriteOnJSON(porcentajeUno, porcentajeDos);
        Debug.Log(addValue);
    }

    void ProgressSliderTeamTwo(float actualValue)
    {
        float addValue = 0f;
        addValue = actualValue / maxValue;
        porcentajeDos += addValue;
        progressSlider.value = porcentajeDos;
        value.text = Mathf.Round(porcentajeDos * 100) + "%";
        WriteOnJSON(porcentajeUno, porcentajeDos);
        Debug.Log(addValue);
    }

}
