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
    float porcentaje = 0f;

    void Awake()
    {
        progressSlider = GetComponent<Slider>();    
    }
    public void Start()
    {
        ReadOnJSON();
    }
    void Update()
    {
       

        
    }           
    public void RefreshSlider(float actualValue)
    {
        
        float addValue=0f;
        addValue = actualValue / maxValue;
        porcentaje+=addValue;
        progressSlider.value = porcentaje;
        value.text = Mathf.Round( porcentaje*100) + "%";
        WriteOnJSON(porcentaje);
        Debug.Log(addValue);
    }


    public void WriteOnJSON(float progress)
    {
        string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
        Teams teams = new Teams(progress);
        string json = JsonUtility.ToJson(teams, true);
        File.WriteAllText(path, json);

    }

    void ReadOnJSON()
    {
        string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
        string json = File.ReadAllText(path);
        Teams teams = JsonUtility.FromJson<Teams>(json);
        porcentaje = teams.progress;
        progressSlider.value = porcentaje;
        value.text = Mathf.Round(porcentaje * 100) + "%";
    }

}
