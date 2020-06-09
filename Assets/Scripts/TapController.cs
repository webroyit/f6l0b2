using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create Rigidbody2D component
[RequireComponent(typeof(Rigidbody2D))]

public class TapController : MonoBehaviour
{
    // Create events for other scripts to be used
    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;
    public static event PlayerDelegate OnPlayerScored;

    public float tapForce = 10;
    public float tiltSmooth = 5;
    public Vector3 startPos;

    Rigidbody2D rigidbody;

    // Rotation
    Quaternion downRotation;
    Quaternion forwardRotation;

    void Start()
    {
        // Access the Rigidbody2D component of the object
        rigidbody = GetComponent<Rigidbody2D>();

        // For rotation
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
    }

    void Update()
    {
        // Left click of the mouse or tap
        if(Input.GetMouseButtonDown(0))
        {
            // Forward Rotation
            transform.rotation = forwardRotation;

            // Disable gravity when clicking or tapping
            rigidbody.velocity = Vector3.zero;

            // Push the bird up
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        // Lerp is from source value to a target for certain amount of time
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "ScoreZone")
        {
            OnPlayerScored();
        }

        if(col.gameObject.tag == "DeadZone")
        {
            // Stop the bird 
            rigidbody.simulated = false;

            OnPlayerDied();
        }
    }
}
