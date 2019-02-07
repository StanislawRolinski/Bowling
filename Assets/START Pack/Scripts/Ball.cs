using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 ballVelocity;

    public bool inPlay = false;
    private Rigidbody rigidBody;
    private AudioSource ballSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
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

    }



   
}
