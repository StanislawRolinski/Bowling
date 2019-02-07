using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 ballVelocity;

    public bool inPlay = false;

    private Vector3 ballStartPos;
    private Rigidbody rigidBody;
    private AudioSource ballSound;
   



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        ballStartPos = transform.position;
        
        }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        ballSound = GetComponent<AudioSource>();
        ballSound.Play();
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;

    }



   
}
