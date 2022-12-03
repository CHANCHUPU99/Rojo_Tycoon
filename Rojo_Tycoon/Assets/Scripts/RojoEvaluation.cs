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

    float valorReprobatorio = .7f;

    public string[] evaluationPossibilities;
    public TextMeshProUGUI evaluationText;
    public TextMeshProUGUI evaluationTextTwo;

    public GameObject BlackScreenImage;


    // Start is called before the first frame update
    void Start()
    {
       ReadOnJSON();

        teamOneSlider.interactable = false;
        teamTwoSlider.interactable = false;

        RojoFinalEvaluation();
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


    void RojoFinalEvaluation()
    {
        
        if(porcentajeTeamOne < valorReprobatorio && porcentajeTeamTwo < valorReprobatorio)
        {
            print("Ambos Equipos reprobaron.");
            evaluationTextTwo.text = evaluationPossibilities[3];
        }
        else if(porcentajeTeamOne < valorReprobatorio || porcentajeTeamTwo < valorReprobatorio)
        {
            print("Un equipo reprobo.");
            evaluationTextTwo.text = evaluationPossibilities[4];
            if (porcentajeTeamOne > valorReprobatorio)
            {
                //print("Equipo Uno aprobo");
                evaluationTextTwo.text = evaluationPossibilities[5];
            }
            else if (porcentajeTeamTwo > valorReprobatorio)
            {
                //print("Equipo Dos aprobo");
                evaluationTextTwo.text = evaluationPossibilities[6];
            }
        }
        else
        {
            {
                print("Ambos equipos aprobaron");
                evaluationTextTwo.text = evaluationPossibilities[7];
            }
        }


        if((porcentajeTeamOne) < (porcentajeTeamTwo))
        {
            print("Gano Team Two");
            evaluationText.text = evaluationPossibilities[0];
        }
        else if((porcentajeTeamOne) > (porcentajeTeamTwo))
        {
            print("Gano Team One");
            evaluationText.text = evaluationPossibilities[1];
        }
        else if((porcentajeTeamOne) == (porcentajeTeamTwo))
        {
            print("Empate de equipos");
            evaluationText.text = evaluationPossibilities[2];
        }

        StartCoroutine(EnableBlackScreen());
    }

    IEnumerator EnableBlackScreen()
    {
        yield return new WaitForSeconds(5f);
        BlackScreenImage.SetActive(true);
    }
}


