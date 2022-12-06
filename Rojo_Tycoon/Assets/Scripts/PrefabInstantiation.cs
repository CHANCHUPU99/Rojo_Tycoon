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

    public List<GameObject> prefabList;

    //public TeamSelection teamSelection;

    // Start is called before the first frame update
    public void InstantiateID()
    {
        prefabList = new List<GameObject>();
        for (int i = 0; i < CardPositionOne.Length; i++)
        {
            //GameObject m_Instance = Instantiate(prefab, CardPositionOne[i].position, Quaternion.identity,
            //parentPrefab.transform) as GameObject;

            prefabList.Add(Instantiate(prefab, CardPositionOne[i].position, Quaternion.identity,
            parentPrefab.transform) as GameObject);

            print("Se instanció un prefab");

            //nameText[0].text = "Se instanció un prefab";
        }

        for(int i= 0; i < prefabList.Count; i++)
        {
            prefabList[i].GetComponent<CardObjectText>().nameText.text = TeamSelection.instance.teamOne[i].name;
            prefabList[i].GetComponent<CardObjectText>().descriptionText.text = TeamSelection.instance.teamOne[i].personality;

        }

    }

}
