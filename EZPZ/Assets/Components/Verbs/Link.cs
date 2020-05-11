using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : GameplayComponent
{
    public bool unlink = false;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void UpdateButton()
    {
        if (Input.GetKey(GetKeyFromButtonType(key)))
        {
            Activate();
        }
    }

    protected override void UpdateConstant()
    {
        Activate();
    }

    protected override void UpdateOneShot()
    {
        if(!completed)
        {
            Activate();
            completed = true;
        }
    }

    public void Activate()
    {
        if (unlink)
            DoUnlink();
        else
            DoLink();
    }

    public void DoLink()
    {
        transform.parent = target.transform;
    }

    public void DoUnlink()
    {
        if(transform.parent == target)
        {
            transform.parent = null;
        }
    }
}
