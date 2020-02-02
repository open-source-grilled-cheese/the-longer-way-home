using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Behavior : MonoBehaviour
{
    //Declare rigidbodt component
    private Rigidbody2D rb;
    private int direction;
    Vector2 force = new Vector2(1, 1);

    // Start is called before the first frame update
    void Start()
    {
        //Get Rigidbody component
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    //Physics Updates
    private void FixedUpdate()
    {

        rb.AddForce(force);
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(1,0,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
