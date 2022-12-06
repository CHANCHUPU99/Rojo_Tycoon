using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrefabInstantiation : MonoBehaviour
{
    public TMP_Text[] nameText;
    public TMP_Text[] PersonalityText;

    public GameObject prefab;
    public GameObject parentPrefab;

    public Transform[] CardPositionOne;
    public Transform[] CardPositionTwo;

    public List<GameObject> prefabListOne;
    public List<GameObject> prefabListTwo;

    //public TeamSelection teamSelection;

    // Start is called before the first frame update
    public void InstantiateID()
    {
        prefabListOne = new List<GameObject>();
        for (int i = 0; i < CardPositionOne.Length; i++)
        {
            //GameObject m_Instance = Instantiate(prefab, CardPositionOne[i].position, Quaternion.identity,
            //parentPrefab.transform) as GameObject;

            prefabListOne.Add(Instantiate(prefab, CardPositionOne[i].position, Quaternion.identity,
            parentPrefab.transform) as GameObject);

            print("Se instanció un prefab");

            //nameText[0].text = "Se instanció un prefab";
        }

        for(int i= 0; i < prefabListOne.Count; i++)
        {
            prefabListOne[i].GetComponent<CardObjectText>().nameText.text = TeamSelection.instance.teamOne[i].name;
            prefabListOne[i].GetComponent<CardObjectText>().descriptionText.text = TeamSelection.instance.teamOne[i].personality;

        }

        prefabListTwo = new List<GameObject>();
        for (int i = 0; i < CardPositionTwo.Length; i++)
        {
            prefabListTwo.Add(Instantiate(prefab, CardPositionTwo[i].position, Quaternion.identity,
            parentPrefab.transform) as GameObject);
        }

        for (int i = 0; i < prefabListTwo.Count; i++)
        {
            prefabListTwo[i].GetComponent<CardObjectText>().nameText.text = TeamSelection.instance.teamTwo[i].name;
            prefabListTwo[i].GetComponent<CardObjectText>().descriptionText.text = TeamSelection.instance.teamTwo[i].personality;

        }

    }

}
