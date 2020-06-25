using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform start, end;
    public AnimationCurve Curve;
    public Vector3 LerpOffset;
    public float LerpTime, _timer;


    void Start()
    {
        //LerpTime = 3f;
        _timer = 0;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > LerpTime)
        {
            _timer = LerpTime;
        }

        float LerpRatio = _timer / LerpTime;

        Vector3 positionOffset = Curve.Evaluate(LerpRatio) * LerpOffset;

        transform.position = Vector3.Lerp(start.position, end.position, LerpRatio) + positionOffset;
        transform.rotation = Quaternion.Lerp(transform.rotation, end.rotation, 2.8f * Time.deltaTime);
    }

    //void swtch() 
    //{
    //    if (canJump)
    //    {
    //        canJump = false;
    //    }
    //    else
    //    {
    //        timeElapsed = 0;
    //        startPosition = transform.position;
    //        canJump = true;
    //    }
    //}


    //void Jump()
    //{
    //    float distCovered = (Time.time - startTime) * speed;
    //    float fractionOfJourney = distCovered / journeyLength;
    //    transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
    //}
}
