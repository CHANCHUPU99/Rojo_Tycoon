using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class TeamSelection : MonoBehaviour
{
    public int[] array = new int[9];
    public string[] studentsNames;
    int temp;
    // Start is called before the first frame update
    void Start()
    {
        WriteOnJSON("StudentZero","Erick","Studious",10);

        CreateTwoTeams();
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


    void CreateTwoTeams()
    {
        
        
        
        for (int i = 0; i < studentsNames.Length; i++)
        {

             int n = Random.Range(0, studentsNames.Length);
            if (!array.Contains(n))
            {
                    array[i] = n;
                    Debug.Log(array[i]);
            }
            
        }

       
        /*int n = Random.Range(0, studentsNames.Length);

        int r = Random.Range(0, studentsNames.Length);
        if (r==n)
        {
            int r1= Random.Range(0, studentsNames.Length);
        }
        //sacar 4 valores del array y hacer un while hasta que no se repita ningun valor 

        /*for(int i = 0; i < studentsNames.Length; i++)
        {
            n=Random.Range(i+1, studentsNames.Length);   
        }
        Debug.Log(n);*/
    }

}
