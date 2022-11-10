using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class RojoEvaluation : MonoBehaviour
{
    public Slider teamOneSlider;
    public Slider teamTwoSlider;

    float porcentajeTeamOne;
    float porcentajeTeamTwo;

    public TMP_Text textTeamOne;
    public TMP_Text textTeamTwo;

    // Start is called before the first frame update
    void Start()
    {
       // ReadOnJSON();
    }

    public void ReadOnJSON()
    {        
        string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
        string json = File.ReadAllText(path);
        Teams teams = JsonUtility.FromJson<Teams>(json);
        porcentajeTeamOne = teams.progress;
        teamOneSlider.value = porcentajeTeamOne;
        textTeamOne.text = Mathf.Round(porcentajeTeamOne * 100) + "%";
           
        string pathTwo = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
        string jsonTwo = File.ReadAllText(pathTwo);
        Teams teamsTwo = JsonUtility.FromJson<Teams>(jsonTwo);
        porcentajeTeamTwo = teamsTwo.progress;
        teamTwoSlider.value = porcentajeTeamTwo;
        textTeamTwo.text = Mathf.Round(porcentajeTeamTwo * 100) + "%";
        
    }
}
