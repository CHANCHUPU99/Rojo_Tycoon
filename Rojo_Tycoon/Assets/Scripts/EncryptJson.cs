using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EncryptJson : MonoBehaviour
{
    public static EncryptJson instance;

    int[] character;

    string artek = "artek";
   
    int[] artCharac;

    int[] newAsciiArtek;

    string jsonFile;

    int ie = 0;

    int[] newEncryptedValue;

    string encryptedJson;

    private void Awake()
    {
        instance = this;
    }

    public string EncryptJsonFile(string GeneralProgression)
    {
        string encryptedJson = "";

        EncryptionWord();

        ConvertToAscii(GeneralProgression);

        ChangeEncryptWordLength();

        AddEncryptedValues(newAsciiArtek);

        return encryptedJson;
    }

    void ConvertToAscii(string GeneralProgression)
    {
        jsonFile = GeneralProgression;
        character = new int[jsonFile.Length];
        for (int i = 0; i < jsonFile.Length; i++)
        {
            character[i] = (int)jsonFile[i];

            //asciiValue += character[i] + "/";

            //print("ascii: " + asciiValue);
        }
        //print(asciiValue);
    }


    void ReadJson()
    {
        string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
        string json1 = File.ReadAllText(path);
        Teams teams = JsonUtility.FromJson<Teams>(json1);

        string path2 = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
        string json2 = File.ReadAllText(path2);
        Teams team2 = JsonUtility.FromJson<Teams>(json2);
    }


    public void WriteOnJSON(float progressTeamOne, float progressTeamTwo)
    {
        string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
        Teams teams = new Teams(progressTeamOne);
        string json = JsonUtility.ToJson(teams, true);
        File.WriteAllText(path, json);

        string pathTwo = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
        Teams teamsTwo = new Teams(progressTeamTwo);
        string jsonTwo = JsonUtility.ToJson(teamsTwo, true);
        File.WriteAllText(pathTwo, jsonTwo);

        EncryptJsonFile(json);

        //print("Se llamo escribir json");
    }

    

    void EncryptionWord()
    {
        artCharac = new int[artek.Length];

        for (int i = 0; i < artek.Length; i++)
        {
            artCharac[i] = (int)artek[i];

            //asciiArtek += artCharac[i] + " ";
            //print("asciiAr: " + artCharac[i]);
        }

        //print("ascii Artek: " + asciiArtek);

        //string[] splits = asciiArtek.Split(' ');
        //string[] splits2 = asciiValue.Split('/');
    }

    void ChangeEncryptWordLength()
    {
        for (int i = 0; i < character.Length; i++)
        {
            if (ie >= artCharac.Length)
            {
                ie = 0;
            }

            newAsciiArtek[i] = artCharac[ie];

            //print("position i: " + i + " NEW NUMBER: " + newAsciiArtek[i] + " array value i: " + ie);

            ie++;
        }
    }

    void AddEncryptedValues(int[] array)
    {
        newEncryptedValue = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            newEncryptedValue[i] = array[i] + character[i];



            print("new value: " + newEncryptedValue[i]);
        }

       WriteEncryptedJson();
    }

    void WriteEncryptedJson()
    {
        encryptedJson = "";

        for (int i = 0; i < newEncryptedValue.Length; i++)
            encryptedJson += newEncryptedValue[i] + " ";
        print(encryptedJson);
    }

}
