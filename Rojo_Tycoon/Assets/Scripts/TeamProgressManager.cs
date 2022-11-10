using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TeamProgressManager : MonoBehaviour
{
    Students[] teamOne;
    Students[] teamTwo;
    
    void Start()
    {
        ReadTwoTeamsJsonArray();
    }

    void ReadTwoTeamsJsonArray()
    {
        int teamOneProductivity = 0;
        int teamTwoProductivity = 0;
        int studentGeneralStatus;

        string path = Application.streamingAssetsPath + "/" + "teamOneOfTwo.json";
        string pathTwo = Application.streamingAssetsPath + "/" + "teamTwoOfTwo.json";
        string json = File.ReadAllText(path);
        string jsonTwo = File.ReadAllText(pathTwo);

        teamOne = JsonHelper.FromJson<Students>(json);
        teamTwo = JsonHelper.FromJson<Students>(jsonTwo);

        foreach (Students student in teamOne)
        {
            studentGeneralStatus = (student.responsibilityLevel + student.labor + student.creativity);
            teamOneProductivity += studentGeneralStatus;
            teamOneProductivity /= 4;
            studentGeneralStatus = 0;
        }

        foreach (Students student in teamTwo)
        {
            studentGeneralStatus = (student.responsibilityLevel + student.labor + student.creativity);
            teamTwoProductivity += studentGeneralStatus;
            teamTwoProductivity /= 4;
            studentGeneralStatus = 0;
        }

        //print("Team one Total Productivity: " + teamOneProductivity);
        //print("Team two Total Productivity: " + teamTwoProductivity);
    }
}
