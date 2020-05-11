using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool active = true;

    public bool x = false;
    public bool y = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoBunce()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        if(x)
        {
            rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
        }

        if(y)
        {
            rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y * -1);
        }
    }

    public void SetActive(bool setActive)
    {
        active = setActive;
    }
}
