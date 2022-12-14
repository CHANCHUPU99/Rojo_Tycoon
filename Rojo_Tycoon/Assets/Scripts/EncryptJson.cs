using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class EncryptJson : MonoBehaviour
{
    public static EncryptJson instance;

    string newString = "";

    [HideInInspector]
    public Teams teamOne;
    [HideInInspector]
    public Teams teamTwo;

    int[] jsonInASCII;

    const string artek = "artek";

    int[] EncryptionWordInitialLength;

    int[] newEncryptionWordLength;

    string jsonFile = "";

    int ie = 0;

    int[] newEncryptedValue;
    string[] newUnencryptedValue;

    string encryptedJson;

    string unencryptedJson;

    string json1;
    string json2;

    bool isEncrypted;

    private void Awake()
    {
        instance = this;
        //WriteEncryptionStatus(false);
        print("Encryption Status" + ReadEncryptionStatus());
    }

    public string EncryptJsonFile(string JSON)
    {
        if (!ReadEncryptionStatus())
        {
            string encryptedJson = "";
            print("se va a encriptar json");
            EncryptionWord();
            //print("paso uno");
            ConvertToAscii(JSON);
            print("JSON TO ASCII: " + JSON);
            //print("paso dos");
            ChangeEncryptWordLength();
            //print("paso tres");
            print("se encript? json");
            return encryptedJson = AddEncryptedValues(newEncryptionWordLength);
        }
        else
            return JSON;
    }

    void ConvertToAscii(string json)
    {
        // se convirte el json en ASCII y se guarda en jsonFile para usar su valor en la suma del encriptado.
        //print("jsonFile: " + json);
        jsonInASCII = new int[json.Length];
        //print("jsonInASCII length: " + jsonInASCII.Length);
        for (int i = 0; i < json.Length; i++)
        {
            jsonInASCII[i] = (int)json[i];

            jsonFile += jsonInASCII[i] + " "; ;

            //print("ascii: " + asciiValue);
            //print("jsonInASCII: " + jsonInASCII[i]);
        }

        print("jsonFile in ASCII: " + jsonFile);
        //print(asciiValue);
    }


    public void ReadJson()
    {
        print("El status bool en ReadJson: " + ReadEncryptionStatus());
        if (ReadEncryptionStatus())
        {
            string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
            string json1 = File.ReadAllText(path);
            //string json = UnencryptJson(json1);
            print("AQUI TODO BIEN");
            teamOne = JsonUtility.FromJson<Teams>(UnencryptJson(json1));
            print("Se desencript? el json que estaba encriptado");

            string path2 = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
            string json2 = File.ReadAllText(path2);
            teamTwo = JsonUtility.FromJson<Teams>(UnencryptJson(json2));
            print("json 2:" + json2);
            print("Se desencript? json dos");

        }
        else
        {
            print("se ejectut? mal la lectura");
            string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
            string json1 = File.ReadAllText(path);
            teamOne = JsonUtility.FromJson<Teams>(json1);

            string path2 = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
            string json2 = File.ReadAllText(path2);
            teamTwo = JsonUtility.FromJson<Teams>(json2);
            print("Se leyo json no encriptado");
        }
    }


    public void WriteOnJSON(float progressTeamOne, float progressTeamTwo)
    {
        if (!ReadEncryptionStatus())
        {
            string pathOne = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
            teamOne = new Teams(progressTeamOne);
            json1 = JsonUtility.ToJson(teamOne, true);
            //EncryptJsonFile(jsonOne);
            File.WriteAllText(pathOne, EncryptJsonFile(json1));
            print("Se encript? equipo uno");

            string pathTwo = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
            teamTwo = new Teams(progressTeamTwo);
            json2 = JsonUtility.ToJson(teamTwo, true);
            File.WriteAllText(pathTwo, EncryptJsonFile(json2));
            print("Se encript? equipo dos");
            print(json2);

            WriteEncryptionStatus(true);
        }
        else
        {
            //print("Problema con el ciclo de escritura y lectura de json");
            //UnencryptJson(json1);
            json1 = "";
            string path = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamOne.json";
            teamOne = new Teams(progressTeamOne);
            json1 = JsonUtility.ToJson(teamOne, true);
            File.WriteAllText(path, json1);

            //UnencryptJson(json2);

            json2 = "";
            string pathTwo = Application.streamingAssetsPath + "/" + "GeneralProgressionTeamTwo.json";
            teamTwo = new Teams(progressTeamTwo);
            json2 = JsonUtility.ToJson(teamTwo, true);
            File.WriteAllText(pathTwo, json2);
            WriteEncryptionStatus(false);
            print("Se sobre-escribi? json que estaba encriptado");
        }


        //print("Se llamo escribir json");
    }



    void EncryptionWord()
    {
        EncryptionWordInitialLength = new int[artek.Length];

        for (int i = 0; i < artek.Length; i++)
        {
            EncryptionWordInitialLength[i] = (int)artek[i];

            //asciiArtek += EncryptionWordInitialLength[i] + " ";
            //print("asciiAr: " + EncryptionWordInitialLength[i]);
        }

        //print("ascii Artek: " + asciiArtek);

        //string[] splits = asciiArtek.Split(' ');
        //string[] splits2 = asciiValue.Split('/');
    }

    void ChangeEncryptWordLength()
    {
        newEncryptionWordLength = new int[jsonInASCII.Length];
        for (int i = 0; i < jsonInASCII.Length; i++)
        {
            if (ie >= EncryptionWordInitialLength.Length)
            {
                ie = 0;
            }

            newEncryptionWordLength[i] = EncryptionWordInitialLength[ie];

            //print("position i: " + i + " NEW NUMBER: " + newEncryptionWordLength[i] + " array value i: " + ie);

            ie++;
        }
    }

    string AddEncryptedValues(int[] newLengthArray)
    {
        newEncryptedValue = new int[newLengthArray.Length];
        for (int i = 0; i < newLengthArray.Length; i++)
        {
            newEncryptedValue[i] = jsonInASCII[i] + newLengthArray[i];

            //print("new value: " + newEncryptedValue[i]);
        }
        print("new encrypted value:" + newEncryptedValue);
        WriteEncryptedJson();

        return encryptedJson;
    }

    void WriteEncryptedJson()
    {
        encryptedJson = "";

        for (int i = 0; i < newEncryptedValue.Length; i++)
        {

            encryptedJson += newEncryptedValue[i] + " ";
        }
        encryptedJson = encryptedJson.Remove(encryptedJson.Length - 1, 1);
        print("Encryted json: " + encryptedJson);
        //teams.Setter(true);


        print("Se cambi? el estatus a verdadero");
    }

    string UnencryptJson(string json)
    {
        newString = string.Empty;
        EncryptionWord();

        string[] jsonArray = json.Split(" ");
        print(jsonArray[0]);

        newEncryptionWordLength = new int[0];
        newEncryptionWordLength = new int[jsonArray.Length];

        for (int i = 0; i < jsonArray.Length; i++)
        {
            if (ie >= EncryptionWordInitialLength.Length)
            {
                ie = 0;
            }

            newEncryptionWordLength[i] = EncryptionWordInitialLength[ie];

            //print("position i: " + i + " NEW NUMBER: " + newEncryptionWordLength[i] + " array value i: " + ie);

            ie++;
        }

        newUnencryptedValue = new string[jsonArray.Length];

        for (int i = 0; i < jsonArray.Length; i++)
        {
            //newUnencryptedValue[i];
            //int x = Int32.Parse(jsonArray[i]);
            //print("x: " + x);
            newString += (char)(Int32.Parse(jsonArray[i]) - newEncryptionWordLength[i]);
            print(newString);
        }
        print(newString);
        //WriteUnencryptedJson();
        print("Json was unencrypted SUCCESFULLY");
        WriteEncryptionStatus(false);
        return newString;
    }

    void WriteUnencryptedJson()
    {
        //unencryptedJson = "";

        //for (int i = 0; i < newUnencryptedValue.Length; i++)
        //    unencryptedJson += newUnencryptedValue[i] /*+ " "*/;
        print("Se desencript? el JSON: " + newString);
        //WriteEncryptionStatus(false);
        print("Se cambio el status a falso");
        //teams.Setter(false);
    }

    void WriteEncryptionStatus(bool status)
    {
        string path = Application.streamingAssetsPath + "/" + "EncryptionStatus.json";
        EncryptionStatus encryption = new EncryptionStatus(status);
        string json = JsonUtility.ToJson(encryption, true);
        File.WriteAllText(path, json);
    }


    bool ReadEncryptionStatus()
    {
        string path = Application.streamingAssetsPath + "/" + "EncryptionStatus.json";
        string json = File.ReadAllText(path);
        EncryptionStatus encryption = JsonUtility.FromJson<EncryptionStatus>(json);
        return encryption.isEncrypted;
    }

}
