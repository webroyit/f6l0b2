using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create Rigidbody2D component
[RequireComponent(typeof(Rigidbody2D))]

public class TapController : MonoBehaviour
{
    public float tapForce = 10;
    public float tiltSmooth = 5;
    public Vector3 startPos;

    Rigidbody2D rigidbody;

    // Rotation
    Quaternion downRotation;
    Quaternion forwardRotation;
    
}
