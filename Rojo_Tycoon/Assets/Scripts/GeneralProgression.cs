using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneralProgression : MonoBehaviour
{
    Slider progressSlider;

    public float max;
    public float act;
    public TextMeshProUGUI value;

    public enum Task
    {
        Trabajar,
        Nada,
    }

    public Task tasks;    
    // Start is called before the first frame update
    void Awake()
    {
        progressSlider = GetComponent<Slider>();    
    }
    public void Start()
    {
        tasks = Task.Trabajar;
    }

    void Update()
    {
        RefreshSlider(max, act);

        
    }

    public void TaskComplete()
    {
        if(tasks==0)
        {
            act ++;
            
        }
        else if (act >=max)
        {
            Debug.Log("Has completado tu proyecto");
        }
        switch (tasks)
        {
            case Task.Trabajar:
                break;
            case Task.Nada:
                break;
        }
        
    }

    
    public void RefreshSlider(float maxValue,float actValue)
    {
        float porcentaje;
        porcentaje = actValue / maxValue;
        progressSlider.value = porcentaje;
        value.text = porcentaje*100 + "%";
    }

    

}
