using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public int lastStandingCount = -1;
    public Text text;
    public float distanceToRise = 40f;
    public GameObject pinSet;

    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
       
    }

    // Update is called once per frame
    void Update()
    {
        text.text = CountStanding().ToString();
        if (ballEnteredBox)
        {
            CheckStanding();
        }

    }

    void CheckStanding()
    {
        int currentStanding = CountStanding();
        if(currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;

        if((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }

    }

    void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1;
        ballEnteredBox = false;
        text.color = Color.green;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;
        if(thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            text.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;
        if (thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }

    int CountStanding()
    {
        int pinsStanding = 0;
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pinsStanding++;
            }
        }
        return pinsStanding;
    }

    void RisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
    }

    void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Instantiate(pinSet, new Vector3(0, 0.5f, 1829), Quaternion.identity);
    }
}
