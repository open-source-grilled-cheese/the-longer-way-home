using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    private Collider2D cd;
    private Collider2D othercd;
    private Rigidbody2D rb;
    private int direction = 0; // 0 = right, 1 = down, 2 = left, 3 = up
    // Start is called before the first frame update
    public int rotation; // 1 = c, -1 = cc
    private float speed = 5;
    public string platformName;
    void Start()
    {
        cd = gameObject.GetComponent<Collider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        othercd = GameObject.Find (platformName).GetComponent<Collider2D>(); // put platform name here
    }

    // Update is called once per frame

    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.transform.Translate(speed * Time.deltaTime, 0, 0);

        if (!cd.IsTouching(othercd))
        {
            rb.transform.Translate(-2*speed * Time.deltaTime, 0, 0);
            rb.transform.Rotate(Vector3.forward * rotation * 90);

            direction += rotation;
        }
    }
}
