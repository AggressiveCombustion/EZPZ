using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInDirection : GameplayComponent
{
    public GameObject bullet;
    public Vector2 direction;
    public Vector2 offset;
    [Range(0.1f, 10)]
    float shootElapsed = 0;

    // Start is called before the first frame update
    void Start()
    { 
    }

    protected override void UpdateButton()
    {
        // we always need at least a little delay so that it doesn't spam bullets and crash
        shootElapsed += Time.deltaTime;

        if (Input.GetKey(GetKeyFromButtonType(key)) && shootElapsed > timeBetween)
        {
            DoShoot();
            shootElapsed = 0;
        }
    }

    protected override void UpdateOneShot()
    {
        if (active && !completed)
        {
            DoShoot();
        }
    }

    protected override void UpdateConstant()
    {
        // we always need at least a little delay so that it doesn't spam bullets and crash
        shootElapsed += Time.deltaTime;
        if(shootElapsed >= timeBetween)
        {
            DoShoot();
            shootElapsed = 0;
        }
        
    }

    void DoShoot()
    {
        GameObject g = Instantiate(bullet, transform.position + new Vector3(offset.x, offset.y), Quaternion.identity);

        if(g.GetComponent<Rigidbody2D>() != null)
        {
            //g.GetComponent<Rigidbody2D>().velocity = direction;
            g.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
        }
    }
}
