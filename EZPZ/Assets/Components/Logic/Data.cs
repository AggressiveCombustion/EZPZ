using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : GameplayComponent
{
    string[] keywords = { "speed", "delay", "time_between"};
    
    public GameplayComponent target;
    public string variableName;
    public float value;
    
    public enum TypeOfChange
    {
        set,
        add,
        subtract
    }

    public TypeOfChange typeOfChange;

    // Start is called before the first frame update
    void Start()
    {
        name = name.ToLower();
        // first, check to see if we're trying to change one of our key values (speed, direction, etc.)
        foreach (string s in keywords)
        {
            if (s == name)
            {
                return;
            }
        }

        // if not, it's a custom variable. If it's not something we've already added, create it
        if (!GameManager.instance.AlreadyHasVariable(variableName))
        {
            GameManager.instance.variables.Add(new CustomData(variableName, value));
        }
    }

    protected override void UpdateButton()
    {
    }

    protected override void UpdateConstant()
    {
    }

    protected override void UpdateOneShot()
    {
    }

    void ChooseValue()
    {
        // is what we're trying to change in our keywords?
        foreach(string s in keywords)
        {
            if(s == name)
            {
                ChooseComponentValue();
                return;
            }
        }

        CustomData d = GameManager.instance.RetrieveVariable(name);
        if (d == null)
            return;

        d.value = value;
    }

    void ChooseComponentValue()
    {
        if (target == null)
            return;

        switch(name)
        {
            case "speed":
                target.speed = ChangeValue(target.speed);
                break;

            case "delay":
                target.delay = ChangeValue(target.delay);
                break;

            case "time_between":
                target.timeBetween = ChangeValue(target.timeBetween);
                break;

            case "direction.x":
                break;

            case "direction.y":
                break;

        }
    }

    float ChangeValue(float val)
    {
        switch(typeOfChange)
        {
            case TypeOfChange.set:
                val = value;
                break;

            case TypeOfChange.add:
                val += value;
                break;

            case TypeOfChange.subtract:
                val -= value;
                break;
        }

        return val;
    }
    

}
