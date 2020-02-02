using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandWorm : MonoBehaviour
{
    private float timer = 0;
    private float secWait = 3;
    private float secMove = 2;
    public float distance = 16;
    public float delay;
    public float startingDirection = -1;
    private float direction; // 1 = up, -1 = down
    public bool moving = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        timer = Time.time - delay;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        direction = startingDirection;
        sr.flipY = (direction == 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving){
            rb.transform.Translate(0, direction*distance/secMove*Time.deltaTime, 0);
            if (Time.time > timer + secMove) {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                moving = false;
                timer = Time.time;
                direction *= -1;
                sr.flipY = !sr.flipY;
            }


        }
        else {
             if(Time.time > timer + secWait) {
                 rb.constraints = RigidbodyConstraints2D.None;
                 rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                 moving = true;
                 timer = Time.time;

             }
        }
    }

    public float GetDirection()
    {
        return direction;
    }

}
