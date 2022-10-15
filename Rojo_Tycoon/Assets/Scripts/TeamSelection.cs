using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;

public class TeamSelection : MonoBehaviour
{
   
    public Students[] teamOne;
    public Students[] teamTwo;
    public Students[] teamThree;

    public Students[] students;

    // Start is called before the first frame update
    void Start()
    {
        //WriteOnJSONArray();
        ReadJsonArray();
        ShuffleStudents(students);
        CreateThreeTeams();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void WriteOnJSON(string fileName,string name,string personality,int responsibility, int labor, int creativity)
    //{
    //    string path = Application.streamingAssetsPath + "/" + fileName + ".json";

    //    Students students = new Students(name, personality, responsibility, labor, creativity);

    //    string json = JsonUtility.ToJson(students, true);

    //    //WriteFile(json, path);

    //    //print(json);
    //    File.WriteAllText(path, json);
    //}

    void WriteOnJSONArray()
    {
        {
            string path = Application.streamingAssetsPath + "/" + "StudentsObjectArray.json";
            Students[] students = new Students[8];

            students[0] = new Students("Luis", "Creativo, pero no le sabe", 50, 50, 90);
            students[1] = new Students("Eric", "Creativo, pero lo intenta", 70, 70, 90);
            students[2] = new Students("Javier", "Creativo, pero muy procastinador", 20, 40, 100);
            students[3] = new Students("Maria", "Se esfuerza por entender", 80, 80, 50);
            students[4] = new Students("Fernanda", "Trabaja duro y es dedicada", 70, 90, 50);
            students[5] = new Students("Camila", "Le sabe, pero es muy introvertida", 80, 70, 60);
            students[6] = new Students("Santiago", "Le sabe y es trabajador", 90, 100, 70);
            students[7] = new Students("Diego", "Le sabe y es lider", 100, 90, 70);

            string json = JsonHelper.ToJson(students, true);
            File.WriteAllText(path, json);
            print(json);
        }

    }

    void ReadJsonArray()
    {
        string path = Application.streamingAssetsPath + "/" + "StudentsObjectArray.json";
        string json = File.ReadAllText(path);

        Students[] studentsObjects = JsonHelper.FromJson<Students>(json);

        //foreach (Students credentials in studentsObjects)
        //{
        //    print(credentials.name);
        //    print(credentials.responsibilityLevel);
        //}

        students = studentsObjects;

    }

    //void CallCard(int i)
    //{

    //    string Imagepath = Application.streamingAssetsPath + "/" + card[i].pathImage;

    //    byte[] imageBytes = File.ReadAllBytes(Imagepath);

    //    Texture2D texture2D = new Texture2D(2, 2);

    //    texture2D.LoadImage(imageBytes);

    //    rawImage.texture = texture2D;

    //    //textName.text = cardName.name;
    //    //textDescription.text = cardName.description;
    //    //textAttack.text = cardName.attack.ToString();
    //    //textType.text = cardName.number.ToString();
    //}
    void ShuffleStudents(Students[] studentNames)
    {
        for (int t = 0; t < studentNames.Length; t++)
        {
            Students tmp = studentNames[t];
            int r = UnityEngine.Random.Range(t, studentNames.Length);
            studentNames[t] = studentNames[r];
            studentNames[r] = tmp;
        }
    }

    void CreateTwoTeams()
    {
        teamOne = new Students[4];
        teamTwo = new Students[4];

        for (int i = 0; i < 4; i++)
        {
            teamOne[i] = students[i];
            Debug.Log(students[i].name + " is team one");
        }

        for (int i = 4; i < students.Length; i++)
        {
            teamTwo[i - 4] = students[i];
            Debug.Log(students[i].name + " is team two");
        }

    }

    void CreateThreeTeams()
    {
        teamOne = new Students[3];
        teamTwo = new Students[3];
        teamThree = new Students[2];

        for (int i = 0; i < 3; i++)
        {
            teamOne[i] = students[i];
            Debug.Log(students[i].name + " is team one");
        }

        for (int i = 3; i < students.Length - 2; i++)
        {
            teamTwo[i - 3] = students[i];
            Debug.Log(students[i].name + " is team two");
        }

        for (int i = 6; i < students.Length; i++)
        {
            teamThree[i - 6] = students[i];
            Debug.Log(students[i].name + " is team three");
        }
    }


}
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }