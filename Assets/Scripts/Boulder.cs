using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public float minYpos; //how close the car has to be (y-pos) to trigger the fall 
    public GameObject car;
    private float force;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //check if the car is close
        if (Mathf.Abs(rb.transform.position.x - car.transform.position.x) <= 20 && Mathf.Abs(rb.transform.position.y - car.transform.position.y) <= minYpos)
            rb.constraints = RigidbodyConstraints2D.None; //it can now fall freely
    }
}
