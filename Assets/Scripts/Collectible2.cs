using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible2 : MonoBehaviour
{
    private Collider2D cd;
    private Collider2D othercd;
    // Start is called before the first frame update
    void Start()
    {
        cd = gameObject.GetComponent<Collider2D>();
        othercd = GameObject.Find("Car").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (cd.IsTouching(othercd))
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            GameObject.Find("Car").GetComponent<PlayerMovement>().isSticky = true;

        }
    }
}
