using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ActivitiesManager 
{
    public string activity;
    public int progressValue;

    public ActivitiesManager(string activity, int progressValue)
    {
        this.activity = activity;
        this.progressValue = progressValue;
    }   
}
