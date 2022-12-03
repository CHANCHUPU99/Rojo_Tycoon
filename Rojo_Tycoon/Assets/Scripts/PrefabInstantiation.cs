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

    public TeamSelection teamSelection;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CardPositionOne.Length; i++)
        {
            GameObject m_Instance = Instantiate(prefab, CardPositionOne[i].position, Quaternion.identity,
            parentPrefab.transform) as GameObject;

            print("Se instanció un prefab");

            //nameText[0].text = "Se instanció un prefab";
        }

    }

}
