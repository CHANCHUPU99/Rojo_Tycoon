using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class TimeManager : MonoBehaviour
{
    bool teamDecisionsMade;
    

    public Instantiate instantiate;
    public TMP_Text daysText;

    public Image noticeImage;
    public Slider slider;
    public Button button;
    public Button button2;
    public TMP_Text text;
    public TMP_Text textTeams;


    public DaysLeft daysLeftScript;
    // 10 days
    DaysLeft _daysLeft;
    private void Awake()
    {
        ReadOnDaysLeftJSON();
    }

    private void Start()
    {
        
        //_daysLeft.daysLeft = 10;
        daysText.text = _daysLeft.daysLeft.ToString();
    }

    public void CheckChangeTeam(int numberOfChanges)
    {
        if(numberOfChanges%2 == 0)
        {
            daysLeftScript.daysLeft--;
            WriteDaysLeftJSON(daysLeftScript.daysLeft);
        }
        daysText.text = daysLeftScript.daysLeft.ToString();
        if (_daysLeft.daysLeft <= 0)
        {
            StartCoroutine(EvaluationNotice());
            WriteDaysLeftJSON(daysLeftScript.daysLeft);
            slider.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            textTeams.gameObject.SetActive(false);
        }
    }

    void GoToEvaluation()
    {
        SceneManager.LoadScene("RojoEvaluation");   
    }

    IEnumerator EvaluationNotice()
    {
        yield return new WaitForSeconds(2f);
        noticeImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        GoToEvaluation();
    }

    void WriteDaysLeftJSON(int daysLeft)
    {
        string path = Application.streamingAssetsPath + "/" + "DaysLeft.json";
        DaysLeft m_daysLeft = new DaysLeft(daysLeft);
        string json = JsonUtility.ToJson(m_daysLeft, true);
        File.WriteAllText(path,json);
    }
    
    void ReadOnDaysLeftJSON()
    {
        string path = Application.streamingAssetsPath + "/" + "DaysLeft.json";
        string json = File.ReadAllText(path);
        _daysLeft = JsonUtility.FromJson<DaysLeft>(json);
        daysLeftScript.daysLeft = _daysLeft.daysLeft;
    }
}
