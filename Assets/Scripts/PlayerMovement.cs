using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Camera gameCamera;
    public LayerMask terrainMask;
    public Rigidbody2D rigidBody;
    public CircleCollider2D wheel1;
    public CircleCollider2D wheel2;
    public GameObject bottom;
    public GameObject top;
    public GameObject left;
    public GameObject right;
    public float power;
    public float spinPower;
    public float maxVelocity;
    public float maxSpin;
    public float stickyForce;
    public float jumpForce;
    public float liftForce;
    public float ejectForce;
    public float groundThreshold;
    public bool isSticky; //change when it gets sticky treads
    public bool isJump; // change when it can jump

    private Rigidbody2D rB;
    private BoxCollider2D coll;
    private float dToGround;
    private RaycastHit2D wheel1Hit;
    private RaycastHit2D wheel2Hit;
    private float distanceToGround;
    private bool invertedControls = false;
    private bool willJump = false;
    private bool willLeft = false;
    private bool willRight = false;
    private bool willSpinLeft = false;
    private bool willSpinRight = false;
    private bool willBrake = false;
    private bool willStick = false;
    


    // Start is called before the first frame update
    void Start() {
        rB = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        // rB.maxAngularVelocity = maxSpin;
    }

    void FixedUpdate() {
        if(willRight) {
            rigidBody.AddForce(transform.right * power);
            willRight = false;
        } else if(willLeft) {
            rigidBody.AddForce(transform.right * power * -1);
            willLeft = false;
        }

        if(willSpinLeft) {
            rigidBody.AddTorque(((invertedControls) ? -1 : 1) * spinPower);
            willSpinLeft = false;
        } else if(willSpinRight) {
            rigidBody.AddTorque(((invertedControls) ? 1 : -1) * spinPower);
            willSpinRight = false;
        } else if(willBrake) {
            rB.velocity = new Vector2(rB.velocity.x*0.9f, rB.velocity.y*1f);
            willBrake = false;
        }

        if(willStick) {
            rB.AddForce(transform.up * -1 * stickyForce);
            willStick = false;
        }

        if(willJump) {
            rB.AddForce(transform.up * jumpForce);
            willJump = false;
        }

    }

    // Update is called once per frame
    void Update() {
        // Debug.Log(jumpForce);

        // acceleration & deceleration
        if(Input.GetKey("d") && grounded() && rB.velocity.magnitude > -maxVelocity) {
            willRight = true;
        } else if(Input.GetKey("a") && grounded() && rB.velocity.magnitude  < maxVelocity) {
            willLeft = true;
        }

        // midair spinning
        if(Input.GetKey("d") && !grounded()) {
            willSpinRight = true;
        } else if(Input.GetKey("a") && !grounded()) {
            willSpinLeft = true;
        } else if(grounded()) {
            willBrake = true;
            // Debug.Log("decelerating...");
        }

        // let's use the midpoint between the wheels to measure the distance to the ground
        // new Vector2 betweenWheels
        // dToGround = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - coll.size.y/2*1.1f), -transform.up).distance;
        // Debug.DrawLine(transform.position,new Vector2(transform.position.x, transform.position.y - coll.size.y/2*2f), Color.red);
        // Debug.Log(dToGround);
        // "sticky treads" functionality
        if(Input.GetKey("f") && grounded() && isSticky) {
            willStick = true;
        }

        // jumping
        if(Input.GetKeyDown("space") && grounded() && isJump) {
            willJump = true;
        }

        // wall climbing force
        // check if car is pushed up against something
        // wheel 1 check
        // wheel1Hit = Physics2D.Raycast(left.transform.position, -left.transform.right);
        // Debug.DrawRay(left.transform.position, -left.transform.right, Color.green);
        // wheel2Hit = Physics2D.Raycast(right.transform.position, right.transform.right);
        // Debug.DrawRay(right.transform.position, right.transform.right, Color.green);
        // if((wheel1Hit.distance < 0.05f)) {
        // //     // Debug.Log(wheel1Hit.distance);
        //     rB.AddForceAtPosition(transform.up * liftForce, left.transform.position);
        //                                                             // in collider.size, x represents width
        //                                                             // since we're trying to get the left side of the box here
        // } else if(wheel2Hit.distance < 0.05f) {
        //     rB.AddForceAtPosition(transform.up * liftForce, right.transform.position);
        // }
        
        // clamping angular velocity to maximum value
        if(rB.angularVelocity > maxVelocity) {
            rB.angularVelocity = maxVelocity;
        } else if(rB.angularVelocity < -maxVelocity) {
            rB.angularVelocity = -maxVelocity;
        }

        // make camera follow vehicle
        gameCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -99);

        // Debug.Log(rB.velocity.x);

        //if it does not have sticky treads, check if it's on a wall
        RaycastHit2D groundRay = Physics2D.Raycast(bottom.transform.position, -bottom.transform.up);
        // Debug.DrawRay(bottom.transform.position, -bottom.transform.up, Color.blue);
        // Debug.DrawRay(top.transform.position, top.transform.up, Color.blue);
        // Debug.Log(groundRay.distance);
        if (!isSticky) {
            // Debug.Log(transform.localEulerAngles.z);
            //if(fullyGrounded() && transform.localEulerAngles.z >= 90 && transform.localEulerAngles.z <=270) //if it's on a wall
            if (groundRay.distance < groundThreshold && ((transform.localEulerAngles.z >= 85 && transform.localEulerAngles.z <=95) || (transform.localEulerAngles.z <= 275 && transform.localEulerAngles.z >= 265))) //if it's on a wall
            {
                rB.AddForce(transform.up * ejectForce);
                // Debug.Log("on wall");
            }
        }

        if(Input.GetKeyDown("p")) {
            invertedControls = !invertedControls;
        }

        float localXVel = transform.InverseTransformDirection(rB.velocity).x;
        if(localXVel < -2 && transform.localScale.x < 0) {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        } if(localXVel > 2 && transform.localScale.x > 0) {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    bool wheel1Grounded() {
        return wheel1.IsTouchingLayers(terrainMask);
    }
    bool wheel2Grounded() {
        return wheel2.IsTouchingLayers(terrainMask);
    }

    bool fullyGrounded() {
        return wheel1Grounded() & wheel2Grounded();
    }

    bool grounded() {
        return wheel1Grounded() | wheel2Grounded();
    }
}
