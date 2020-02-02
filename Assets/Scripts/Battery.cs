using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public float life = 100;
    public float drain = 2;
    private Text textbox;
    private float drainDelay = 30; // 25 min timer
    private float timer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        textbox = gameObject.GetComponent<Text>();
        timer = Time.time;
        rb = GameObject.Find("Car").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > timer + drainDelay) {
            life -= drain;
            timer = Time.time;
        }
        textbox.text = "Battery: " + life.ToString() + "%";

        if (life <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            life = 0;
        }
    }
}
