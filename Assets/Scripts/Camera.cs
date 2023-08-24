using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ballPosition;
    Vector3 gap;
    // Start is called before the first frame update
    void Start()
    {
        gap = transform.position - ballPosition.position;
    }

    // Update is called once per frame
    void Update()
    {   
        if(BallMovementScript.didItFall == false)
        { 
        transform.position = ballPosition.position + gap;
        }
    }
}
