using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public AnimationCurve Up, Forward;
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;

    private float startTime;

    private float journeyLength;

    /// <summary>
    /// /////////////////////////
    /// </summary>
    private int curvePosition;
    float timeElapsed;
    
    Vector3 startPosition;



    public bool canJump;

    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        canJump = false;
        //curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        //curve.preWrapMode = WrapMode.PingPong;
        //curve.postWrapMode = WrapMode.PingPong;
    }

    void Update()
    {
        //transform.position = new Vector3(transform.position.x, curve.Evaluate(Time.time), transform.position.z);
        // Distance moved equals elapsed time times speed..


        // Fraction of journey completed equals current distance divided by total distance.

        // Set our position as a fraction of the distance between the markers.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            swtch();
        }

        if (canJump)
        {
            timeElapsed += Time.deltaTime;
            float DisX = transform.position.x;

            if (DisX < endMarker.position.x)
            {
                DisX += 0.0f;
            }

            Vector3 destination = new Vector3(endMarker.position.x, startPosition.y + Up.Evaluate(timeElapsed), transform.position.z);

            //transform.position = Vector3.Lerp(transform.position, destination, 2f * Time.deltaTime);
            //transform.Translate(destination * Time.deltaTime);
            //transform.position = new Vector3(startPosition.x + Forward.Evaluate(timeElapsed), startPosition.y + Up.Evaluate(timeElapsed), transform.position.z);
            
            print(timeElapsed);
            if (timeElapsed > 1)
            {
                canJump = false;
            }
        }
    }

    void swtch() 
    {
        if (canJump)
        {
            canJump = false;
        }
        else
        {
            timeElapsed = 0;
            startPosition = transform.position;
            canJump = true;
        }
    }


    void Jump()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
    }
}
