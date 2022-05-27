using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStickBehavior : MonoBehaviour
{
    public GameObject gm;
    public int stickFromBall; // distance
    public bool isAnimate = false;
    private Vector3 animationBackPosition;
    private Vector3 animationFrontPosition;
    [Range(1, 10)]
    public int indicatorLength;
    [Range(0f, 1f)]
    public float indicatorWidth;
    public float pullSpeed = 1f;
    public float strikeSpeed = 10000f;

    public enum STICK_STATE
    {
        ADJUST,
        PULLBACK,
        STRIKE
    }
    public STICK_STATE stick_state = STICK_STATE.ADJUST;
    private void Start()
    {
        stick_state = STICK_STATE.ADJUST;
        GetComponent<BoxCollider>().enabled = false;

    }
    private void FixedUpdate()
    {
        if (stick_state == STICK_STATE.PULLBACK)
        {
            float step = pullSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, animationBackPosition, step);
            if (transform.position == animationBackPosition)
            {
                stick_state = STICK_STATE.STRIKE;
            }
        }
        else if (stick_state == STICK_STATE.STRIKE)
        {
            GetComponent<BoxCollider>().enabled = true;
            float step = strikeSpeed * Time.deltaTime; // calculate distance to move
            Vector3 direction = animationFrontPosition - animationBackPosition;
            //transform.position = Vector3.MoveTowards(transform.position, animationFrontPosition, step);
            GetComponent<Rigidbody>().AddForce(direction.normalized * strikeSpeed);
        }
    }
    public void setState(string state)
    {
        if (state == "ADJUST") stick_state = STICK_STATE.ADJUST;
        else if (state == "PULLBACK") stick_state = STICK_STATE.PULLBACK;
        else stick_state = STICK_STATE.STRIKE;
    }
    public void move(Vector3 cursorPosition, Vector3 whiteBallPosition)
    {
        Vector3 direction = (cursorPosition - whiteBallPosition);
        direction.y = 0;
        direction = direction.normalized;
        transform.position = whiteBallPosition + direction * stickFromBall;
        transform.LookAt(whiteBallPosition);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);
        if (!gm.GetComponent<Game>().isIllusion)
        {
            ShowPathIndicate(whiteBallPosition);
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }
    }
    public void EnterHittingAnimation(Vector3 BackPosition, Vector3 FrontPosition)
    {
        animationBackPosition = BackPosition;
        animationFrontPosition = FrontPosition;
        stick_state = STICK_STATE.PULLBACK;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("CueBall"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            stick_state = STICK_STATE.ADJUST;
            GetComponent<BoxCollider>().enabled = false;
            collision.transform.GetComponent<WhiteBallBehavior>().state = WhiteBallBehavior.STATE.MOVE;
        }
    }
    void ShowPathIndicate(Vector3 whiteBallPosition)
    {
        GetComponent<LineRenderer>().enabled = true;
        Vector3 direction = (whiteBallPosition - transform.position).normalized;
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, whiteBallPosition);
        lr.SetPosition(1, (whiteBallPosition + direction * indicatorLength));
        lr.startWidth = indicatorWidth;
        lr.endWidth = indicatorWidth;
        lr.material.color = Color.white;
    }
}
