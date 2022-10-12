using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class TeamSelection : MonoBehaviour
{
    //public int[] array = new int[9];
    public string[] studentsNames;
    public string[] teamOne;
    public string[] teamTwo;
    public string[] teamThree;

    // Start is called before the first frame update
    void Start()
    {
        WriteOnJSON("StudentZero","Erick","Studious",10);

        ShuffleStudents(studentsNames);

        CreateThreeTeams();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WriteOnJSON(string fileName,string name,string personality,int responsibility)
    {
        string path = Application.streamingAssetsPath + "/" + fileName + ".json";

        Students students = new Students(name, personality, responsibility);

        string json = JsonUtility.ToJson(students, true);

        //WriteFile(json, path);

        //print(json);
        File.WriteAllText(path, json);
    }


    void ShuffleStudents(string []names)
    {
        for (int t = 0; t < names.Length; t++)
        {
            string tmp = names[t];
            int r = Random.Range(t, names.Length);
            names[t] = names[r];
            names[r] = tmp;
        }
    }

    void CreateTwoTeams()
    {
        for (int i = 0; i < 5; i++)
        {
            teamOne[i] = studentsNames[i];
        }

        for (int i = 5; i < studentsNames.Length; i++)
        {
            teamTwo[i - 5] = studentsNames[i];
        }

    }

    void CreateThreeTeams()
    {
        for (int i = 0; i < 3; i++)
        {
            teamOne[i] = studentsNames[i];
        }

        for (int i = 3; i < studentsNames.Length-3; i++)
        {
            teamTwo[i - 3] = studentsNames[i];
        }

        for (int i = 6; i < studentsNames.Length; i++)
        {
            teamThree[i - 6] = studentsNames[i];
        }
    }

}
