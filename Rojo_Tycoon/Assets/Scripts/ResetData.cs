using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ResetData : MonoBehaviour
{
    public int daysLeft = 10;

    public void ResetDaysLeftJSON()
    {
        string path = Application.streamingAssetsPath + "/" + "DaysLeft.json";
        DaysLeft m_daysLeft = new DaysLeft(daysLeft);
        string json = JsonUtility.ToJson(m_daysLeft, true);
        File.WriteAllText(path, json);

        string pathOne = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
        Teams teams = new Teams(0f);
        string jsonOne = JsonUtility.ToJson(teams, true);
        File.WriteAllText(pathOne, jsonOne);

        string pathTwo = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
        Teams teamsTwo = new Teams(0f);
        string jsonTwo = JsonUtility.ToJson(teamsTwo, true);
        File.WriteAllText(pathTwo, jsonTwo);

        SceneManager.LoadScene(1);
    }
}
