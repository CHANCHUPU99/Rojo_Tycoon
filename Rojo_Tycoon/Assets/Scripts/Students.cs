using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Students
{
    public string name;
    public string personality;
    public int responsibilityLevel;

    public string imagePath;

    public Students(string name, string personality, int responsibility)
    {
        this.name = name;
        this.personality = personality;
        this.responsibilityLevel = responsibility;
    }
   
}
