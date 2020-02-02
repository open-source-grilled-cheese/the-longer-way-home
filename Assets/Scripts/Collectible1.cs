using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible1 : MonoBehaviour {
    private Collider2D cd;
    private Collider2D othercd;
    // Start is called before the first frame update
    void Start()
    {
        cd = gameObject.GetComponent<Collider2D>();
        othercd = GameObject.Find("Car").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update() {
        if (cd.IsTouching(othercd)) {
            gameObject.GetComponent<Renderer>().enabled = false;
            GameObject.Find("Car").GetComponent<PlayerMovement>().isJump = true;
            GameObject.Find("Car").GetComponent<PlayerMovement>().jumpForce = 1300;

        }
        
    }

    void FixedUpdate()
    {
    }
}
