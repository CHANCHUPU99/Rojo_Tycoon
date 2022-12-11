using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class GeneralProgression : MonoBehaviour
{
    const float limitePorcentaje = 1.0f;

    string encryptedJsonTeamOne;
    string encryptedJsonTeamTwo;

    Slider progressSlider;
    public float max;    
    public TextMeshProUGUI value;
    float maxValue = 100f;
    float porcentajeUno = 0f;
    float porcentajeDos = 0f;
    public TMP_Text teamOneText;
    public TMP_Text teamTwoText;

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
        //string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
        //Teams teams = new Teams(progressTeamOne);
        //string json = JsonUtility.ToJson(teams, true);
        //File.WriteAllText(path, json);

        //string pathTwo = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
        //Teams teamsTwo = new Teams(progressTeamTwo);
        //string jsonTwo = JsonUtility.ToJson(teamsTwo, true);
        //File.WriteAllText(pathTwo, jsonTwo);

        EncryptJson.instance.WriteOnJSON(progressTeamOne, progressTeamTwo);

        //print("Se llamo escribir json");
    }

    public void ReadOnJSON(bool isTeamTwo)
    {
        //Debug.LogError("isTeamTwo on GP: " + isTeamTwo);
        if(isTeamTwo == false)
        {

            EncryptJson.instance.ReadJson();
            /*string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
            string json = File.ReadAllText(path);
            Teams teams = JsonUtility.FromJson<Teams>(json);*/
            ShowDataFromJson(EncryptJson.instance.teamOne);

            //encryptedJsonTeamOne = EncryptJson.instance.EncryptJsonFile(json);
            //print(encryptedJsonTeamOne);
            
            
            Debug.Log("Se leyó equipo uno");

            //string path2 = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
            //string json2 = File.ReadAllText(path2);
            //Teams team2 = JsonUtility.FromJson<Teams>(json2);
            porcentajeDos = EncryptJson.instance.teamTwo.progress;

            //encryptedJsonTeamTwo = EncryptJson.instance.EncryptJsonFile(json2);
        }
        else
        {
            EncryptJson.instance.ReadJson();


            /*string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
            string json = File.ReadAllText(path);
            Teams teams = JsonUtility.FromJson<Teams>(json);*/

            //porcentajeDos = teams.progress;
            //progressSlider.value = porcentajeDos;
            //value.text = Mathf.Round(porcentajeDos * 100) + "%";
            //Debug.Log("Se leyó equipo Dos");
            //ShowDataFromJsonTeamTwo(teams);

            ShowDataFromJsonTeamTwo(EncryptJson.instance.teamTwo);

            Debug.Log("Se leyó equipo Dos");

            //encryptedJsonTeamTwo = EncryptJson.instance.EncryptJsonFile(json);
        }
    }

    void ProgressSliderTeamOne(float actualValue)
    {
        float addValue = 0f;
        addValue = actualValue / maxValue;

        if (porcentajeUno < limitePorcentaje)
        {
            porcentajeUno += addValue;
            if(porcentajeUno > limitePorcentaje)
            {
                porcentajeUno = limitePorcentaje;
            }
            progressSlider.value = porcentajeUno;
            value.text = Mathf.Round(porcentajeUno * 100) + "%";
            //WriteOnJSON(porcentajeUno, porcentajeDos);
            
        }
        else
        {
            porcentajeUno = limitePorcentaje;
            progressSlider.value = 1f;
            value.text = Mathf.Round(limitePorcentaje * 100) + "%";
            //WriteOnJSON(porcentajeUno, porcentajeDos);
        }

        WriteOnJSON(porcentajeUno, porcentajeDos);
        Debug.Log("Se guardo en json: " + addValue);

        
    }

    void ProgressSliderTeamTwo(float actualValue)
    { 
        float addValue = 0f;
        addValue = actualValue / maxValue;
        ////print("Valor antes: " + porcentajeDos);
        //porcentajeDos += addValue;
        ////print("Valor Despues suma: " + porcentajeDos);
        //progressSlider.value = porcentajeDos;
        //value.text = Mathf.Round(porcentajeDos * 100) + "%";
        //WriteOnJSON(porcentajeUno, porcentajeDos);
        ////print("Valor en Json: " + porcentajeDos);
       

        if (porcentajeDos < limitePorcentaje)
        {
            porcentajeDos += addValue;
            if (porcentajeDos > limitePorcentaje)
            {
                porcentajeDos = limitePorcentaje;
            }
            progressSlider.value = porcentajeDos;
            value.text = Mathf.Round(porcentajeDos * 100) + "%";
        }
        else
        {
            porcentajeDos = limitePorcentaje;
            progressSlider.value = 1f;
            value.text = Mathf.Round(limitePorcentaje * 100) + "%";
        }

        WriteOnJSON(porcentajeUno, porcentajeDos);
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

    void ShowDataFromJson(Teams teams)
    {
        porcentajeUno = teams.progress;
        if (porcentajeUno < limitePorcentaje)
        {
            progressSlider.value = porcentajeUno;
            value.text = Mathf.Round(porcentajeUno * 100) + "%";
        }
        else
        {
            porcentajeUno = limitePorcentaje;
            progressSlider.value = limitePorcentaje;
            value.text = Mathf.Round(limitePorcentaje * 100) + "%";
        }
    }

    void ShowDataFromJsonTeamTwo(Teams teams)
    {
        porcentajeDos = teams.progress;
        if (porcentajeDos < limitePorcentaje)
        {
            progressSlider.value = porcentajeDos;
            value.text = Mathf.Round(porcentajeDos * 100) + "%";
        }
        else
        {
            porcentajeDos = limitePorcentaje;
            progressSlider.value = limitePorcentaje;
            value.text = Mathf.Round(limitePorcentaje * 100) + "%";
        }
    }

}
