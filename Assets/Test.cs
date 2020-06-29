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

        //Vector3 positionOffset = Curve.Evaluate(LerpRatio) * LerpOffset;

        // transform.position = Vector3.Lerp(start.position, end.position, LerpRatio) + positionOffset;

        transform.position = Vector3.Lerp(start.position, end.position, LerpRatio);
        transform.rotation = Quaternion.Lerp(start.rotation, end.rotation, LerpRatio);

    }
}
