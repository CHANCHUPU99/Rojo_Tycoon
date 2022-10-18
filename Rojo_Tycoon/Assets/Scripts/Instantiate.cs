using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instantiate : MonoBehaviour
{
    public Transform pos;
    public Transform posi;
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()

    {
        InstantiateButton();
    }
    public void InstantiateButton()
    {
        int n = Random.Range(0, buttons.Length);
        GameObject b = Instantiate(buttons[n],pos.position, buttons[n].transform.rotation);

        int s = Random.Range(0, buttons.Length);
        GameObject c = Instantiate(buttons[s], posi.position, buttons[s].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
