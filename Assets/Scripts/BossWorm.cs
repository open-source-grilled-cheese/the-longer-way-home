using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossWorm : MonoBehaviour
{
    private Transform startPos;
    private SandWorm sw;
    private bool disappeared = false;
    private float startingDirection;
    private float startScale;
    private float startPosy;
    private bool initDis = true;
    private bool shouldGrow = false;
    private bool shift = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.GetComponent<Transform>();
        //Call component each frame
        sw = gameObject.GetComponent<SandWorm>();
        startPosy = gameObject.transform.position.y;
        startScale = startPos.localScale.y;
        startingDirection = sw.startingDirection;

        if(startingDirection == -1)
        {
            initDis = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(initDis)
        {
            Disappear();
            
        }
        //Call component each frame
        sw = gameObject.GetComponent<SandWorm>();

        //Test if sandworm has mostly completed dive
        if (startingDirection == -1 & !disappeared)
        {
            if (gameObject.transform.position.y <= startPosy - (sw.distance * .83f))
            {
                Disappear();
            }
        }
        else if(!disappeared)
        {
            if (gameObject.transform.position.y >= startPosy + (sw.distance * .85f))
            {
                Disappear();
            }
        }

        if ((sw.moving & disappeared & sw.GetDirection() != startingDirection) | shouldGrow)
        {
            if (shift)
            {
                startingDirection = -startingDirection;
                shift = false;
            }
            if (gameObject.transform.localScale.y <= startScale)
            {
                shouldGrow = true;
                gameObject.transform.localScale += new Vector3(0, .065f, 0);
            }

            else
            {
                
                shouldGrow = false;
                disappeared = false;
                
            }
        }
        
        
    }

    void Disappear()
    {

        //Decrease the 
        if (gameObject.transform.localScale.y > 0)
        {
            gameObject.transform.localScale -= new Vector3(0,.210f,0);
        }
        else
        {
            disappeared = true;
            startPosy = startPosy + startingDirection*sw.distance;
            shift = true;
            


            if (initDis)
            {
                initDis = false;
            }
        }
    }
}


