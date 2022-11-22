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

    public TeamProgressManager teamProgressManager;

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
                ProgressSliderTeamOne(NewProgressValue(actualValue, true));
                break;
            case 2:
                ProgressSliderTeamTwo(NewProgressValue(actualValue, false));
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

        //print("Se llamo escribir json");
    }

    public void ReadOnJSON(bool isTeamTwo)
    {
        //Debug.LogError("isTeamTwo on GP: " + isTeamTwo);
        if(isTeamTwo == false)
        {
            string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
            string json = File.ReadAllText(path);
            Teams teams = JsonUtility.FromJson<Teams>(json);
            porcentajeUno = teams.progress;
            progressSlider.value = porcentajeUno;
            value.text = Mathf.Round(porcentajeUno * 100) + "%";
            Debug.Log("Se leyó equipo uno");

            string path2 = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
            string json2 = File.ReadAllText(path2);
            Teams team2 = JsonUtility.FromJson<Teams>(json2);
            porcentajeDos = team2.progress;
        }
        else
        {
            string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
            string json = File.ReadAllText(path);
            Teams teams = JsonUtility.FromJson<Teams>(json);
            porcentajeDos = teams.progress;
            progressSlider.value = porcentajeDos;
            value.text = Mathf.Round(porcentajeDos * 100) + "%";
            Debug.Log("Se leyó equipo Dos");
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
        Debug.Log("Se guardo en json: " + addValue);
    }

    void ProgressSliderTeamTwo(float actualValue)
    { 
        float addValue = 0f;
        addValue = actualValue / maxValue;
        //print("Valor antes: " + porcentajeDos);
        porcentajeDos += addValue;
        //print("Valor Despues suma: " + porcentajeDos);
        progressSlider.value = porcentajeDos;
        value.text = Mathf.Round(porcentajeDos * 100) + "%";
        WriteOnJSON(porcentajeUno, porcentajeDos);
        //print("Valor en Json: " + porcentajeDos);
        Debug.LogWarning("Se guardo en json: " + addValue);
    }

    float NewProgressValue(float actualValue, bool TeamOne)
    {
        if(TeamOne)
        {
            float newProgressValue = actualValue* teamProgressManager.teamOneProductivity / 100f;
            return newProgressValue;
        }
        else
        {
            float newProgressValue = actualValue * teamProgressManager.teamTwoProductivity / 100f;
            return newProgressValue;
        }
    }
}
