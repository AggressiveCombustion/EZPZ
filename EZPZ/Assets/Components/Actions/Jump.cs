using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : GameplayComponent
{
    bool onGround = false;
    float jumpElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DoJump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
        onGround = false;
        jumpElapsed = 0;
    }

    protected override void UpdateButton()
    {
        jumpElapsed += Time.deltaTime;

        if (Input.GetKeyDown(GetKeyFromButtonType(key)) && onGround && active && jumpElapsed > timeBetween)
        {
            DoJump();
        }
    }

    protected override void UpdateConstant()
    {
        jumpElapsed += Time.deltaTime;

        if (onGround && active && jumpElapsed > timeBetween)
            DoJump();
    }

    protected override void UpdateOneShot()
    {
        if(onGround && active && !completed && jumpElapsed > timeBetween)
        {
            DoJump();
            completed = true;
        }
    }

    void OnCollisionStay2D()
    {
        onGround = true;
    }

}
