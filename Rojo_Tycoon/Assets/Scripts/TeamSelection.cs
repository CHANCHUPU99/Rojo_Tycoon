using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class TeamSelection : MonoBehaviour
{
    public static TeamSelection instance;
    public PrefabInstantiation ID_Prefab;
    public Students[] teamOne;
    public Students[] teamTwo;
    //public Students[] teamThree;

    public Students[] students;

    public TMP_Text studentsNames;
    //public Text studentsNames;
    string actualName;
    int indice;

    public TMP_Text ActualTeamText;
    string ActualTeam = "Team One";

    public TMP_Text nameText;
    public TMP_Text personalityText;

    //public GeneralProgression generalProgression;

    bool isTeamtwo;

    public Button startGameButton;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //instance = this;
        DisabledStartButton();
        indice = 0;
        //WriteOnJSONArray();
        ReadJsonArray();
        ShuffleStudents(students);
        //ShowTeamNames(isTeamtwo);
        
        //ReadOnJSONArrayTeamTwo();
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

            students[0] = new Students("Luis", "Creativo, pero no le sabe", 50, 50, 90,0);
            students[1] = new Students("Eric", "Creativo, pero lo intenta", 70, 70, 90, 0);
            students[2] = new Students("Javier", "Creativo, pero muy procastinador", 20, 40, 100,0);
            students[3] = new Students("Maria", "Se esfuerza por entender", 80, 80, 50, 0);
            students[4] = new Students("Fernanda", "Trabaja duro y es dedicada", 70, 90, 50, 0);
            students[5] = new Students("Camila", "Le sabe, pero es muy introvertida", 80, 70, 60, 0);
            students[6] = new Students("Santiago", "Le sabe y es trabajador", 90, 100, 70, 0);
            students[7] = new Students("Diego", "Le sabe y es lider", 100, 90, 70, 0);

            string json = JsonHelper.ToJson(students, true);
            File.WriteAllText(path, json);
            print(json);
        }
    }

    void WriteTwoTeamsOnJSON(Students[] teamOne, Students[] teamTwo)
    {
        string pathOne = Application.streamingAssetsPath + "/" + "teamOneOfTwo.json";
        Students[] team_One = teamOne;

        string json = JsonHelper.ToJson(team_One, true);
        File.WriteAllText(pathOne, json);

        string pathTwo = Application.streamingAssetsPath + "/" + "teamTwoOfTwo.json";
        Students[] team_Two = teamTwo;

        string jsonTwo = JsonHelper.ToJson(team_Two, true);
        File.WriteAllText(pathTwo, jsonTwo);
    }

    //void WriteThreeTeamsOnJSON(Students[] teamOne, Students[] teamTwo, Students [] teamThree)
    //{
    //    string pathOne = Application.streamingAssetsPath + "/" + "teamOneOfThree.json";
    //    Students[] team_One = teamOne;

    //    string json = JsonHelper.ToJson(team_One, true);
    //    File.WriteAllText(pathOne, json);

    //    string pathTwo = Application.streamingAssetsPath + "/" + "teamTwoOfThree.json";
    //    Students[] team_Two = teamTwo;

    //    string jsonTwo = JsonHelper.ToJson(team_Two, true);
    //    File.WriteAllText(pathTwo, jsonTwo);

    //    string pathThree = Application.streamingAssetsPath + "/" + "teamThreeOfThree.json";
    //    Students[] team_Three = teamThree;

    //    string jsonThree = JsonHelper.ToJson(team_Three, true);
    //    File.WriteAllText(pathThree, jsonThree);
    //}

    void ReadJsonArray()
    {
        string path = Application.streamingAssetsPath + "/" + "StudentsObjectArray.json";
        string json = File.ReadAllText(path);

        Students[] m_studentsObjects = JsonHelper.FromJson<Students>(json);

        //foreach (Students credentials in studentsObjects)
        //{
        //    print(credentials.name);
        //    print(credentials.responsibilityLevel);
        //}

        students = m_studentsObjects;

    }

    public void ShowTeamNames(bool isTeamTwo)
    {
        
        //print("isTeamTwo condition :" + instantiate.isTeamTwo);
        //Debug.LogWarning("isTeamTwo condition :" + isTeamTwo);
        if (!isTeamTwo)
        {
            //"teamOneOfTwo.json"
            string path = Application.streamingAssetsPath + "/" + "teamOneOfTwo.json";
            string json = File.ReadAllText(path);

            Students[] teamNames = JsonHelper.FromJson<Students>(json);

            ActualTeam = "Team One";
            ActualTeamText.text = ActualTeam;

            if (indice < teamNames.Length)
            {
                studentsNames.text = teamNames[indice].name;

                //print(indice);
                //print(teamNames[indice].name);
                
                indice++;
                //if(indice >= teamNames.Length)
                //{
                //    instantiate.activitiesLeftPerTeam = 0;
                //    indice = 0;

                //}
                if (indice >= teamNames.Length)
                {
                    indice = 0;
                }
            }
       
        }
        else
        {
            string path = Application.streamingAssetsPath + "/" + "teamTwoOfTwo.json";
            string json = File.ReadAllText(path);

            Students[] teamNames = JsonHelper.FromJson<Students>(json);

            ActualTeam = "Teams Two";
            ActualTeamText.text = ActualTeam;

            if (indice < teamNames.Length)
            {
                studentsNames.text = teamNames[indice].name;

                //print(teamNames[indice].name);
                //print(indice);

                indice++;

                //if (indice >= teamNames.Length)
                //{
                //    instantiate.activitiesLeftPerTeam = 0;
                //    indice = 0;
                //}
                if (indice >= teamNames.Length)
                {
                    indice = 0;
                }
            }
          
            
        } 
    }
   
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

    public void CreateTwoTeams()
    {
        teamOne = new Students[4];
        teamTwo = new Students[4];

        for (int i = 0; i < teamOne.Length; i++)
        {
            teamOne[i] = students[i];
            Debug.Log(students[i].name + " is team one");
        }

        for (int i = 4; i < students.Length; i++)
        {
            teamTwo[i - 4] = students[i];
            Debug.Log(students[i].name + " is team two");
        }
        WriteTwoTeamsOnJSON(teamOne, teamTwo);
        //ShowTeamCards();

        EnabledStartButton();
    }

    //void ShowTeamCards()
    //{
    //    studentsNames.text = teamOne[0].name;
    //    personalityText.text = teamOne[0].personality;
    //}
    public void DisabledStartButton()
    {
        startGameButton.interactable = false;
        //startGameButton.canvasRenderer.SetAlpha(100f);
    }

    public void EnabledStartButton()
    {
        startGameButton.interactable = true;
        //startGameButton.canvasRenderer.SetAlpha(100f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    //    public void CreateThreeTeams()
    //    {
    //        teamOne = new Students[3];
    //        teamTwo = new Students[3];
    //        teamThree = new Students[2];

    //        for (int i = 0; i < 3; i++)
    //        {
    //            teamOne[i] = students[i];
    //            //Debug.Log(students[i].name + " is team one");
    //        }

    //        for (int i = 3; i < students.Length - 2; i++)
    //        {
    //            teamTwo[i - 3] = students[i];
    //            //Debug.Log(students[i].name + " is team two");
    //        }

    //        for (int i = 6; i < students.Length; i++)
    //        {
    //            teamThree[i - 6] = students[i];
    //            //Debug.Log(students[i].name + " is team three");
    //        }

    //        WriteThreeTeamsOnJSON(teamOne, teamTwo, teamThree);
    //    }

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