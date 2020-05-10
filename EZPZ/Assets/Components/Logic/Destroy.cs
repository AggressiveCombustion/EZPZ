using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : GameplayComponent
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void UpdateButton()
    {
        if(Input.GetKey(GetKeyFromButtonType(key)))
        {
            DestroyTarget();
        }
    }

    protected override void UpdateConstant()
    {
        DestroyTarget();
    }

    protected override void UpdateOneShot()
    {
        if(active && !completed)
        {
            DestroyTarget();
            completed = true;
        }
    }

    public void DestroyTarget()
    {
        if (target == null)
            return;
        Destroy(target);
    }
}
