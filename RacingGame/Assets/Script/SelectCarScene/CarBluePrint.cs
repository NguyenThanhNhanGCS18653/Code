using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarBluePrint
{
    [SerializeField]
    private string name;
    public string MyName 
    {
        get
        {
            return name;
        }
    }

    [SerializeField]
    private int index;
    
    [SerializeField]
    private int price;
    public int MyPrice 
    {
        get
        {
            return price;
        }
    }

    [SerializeField]
    private bool isUnlocked;
    public bool MyIsUnlocked 
    {
        get
        {
            return isUnlocked;
        }
        set
        {
            isUnlocked = value;
        }
    }
}
