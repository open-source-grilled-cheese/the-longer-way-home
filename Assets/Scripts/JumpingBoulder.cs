using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBoulder : MonoBehaviour
{
    private Rigidbody2D rb;

    private float timer = 0;
    public float waitSec;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Time.time > timer + waitSec)
        {
            rb.AddForce(Vector2.up * force);
            timer = Time.time;
        }
        
    }
}
