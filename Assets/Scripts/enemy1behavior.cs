using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1behavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    //moving the object based on physics frames per second
    private void FixedUpdate()
    {
        //Move along the x-axis
        gameObject.transform.Translate(Time.deltaTime*speed, 0, 0);
    }

    //if it collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed *= -1;
        gameObject.transform.Translate(Time.deltaTime*speed, 0, 0);
    }

   
}
