using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : GameplayComponent
{
    public GameObject target;

    bool doFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Update()
    {
        base.Update();

        if (doFollow)
            DoFollow();
        
    }

    protected override void UpdateButton()
    {
        if (Input.GetKey(GetKeyFromButtonType(key)))
            doFollow = true;
    }

    protected override void UpdateConstant()
    {
        doFollow = true;
    }

    protected override void UpdateOneShot()
    {
        if (active && !completed)
        {
            doFollow = true;
            completed = true;
        }
    }

    public void EnableFollow()
    {
        doFollow = true;
    }

    void DoFollow()
    {
        if (target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);

        if(transform.position == target.transform.position && inputType == InteractionType.OneShot)
        {
            doFollow = false;
        }
    }



}
