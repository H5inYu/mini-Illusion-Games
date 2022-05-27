using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TusiBallManager : MonoBehaviour
{
    public Object prefab;
    List<GameObject> balls = new List<GameObject>();
    float newAngle = 0f;
    float shootingSpeed = 6f;
    public GameObject parent;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballCreate(newAngle);
        }
        if (Input.GetKeyDown(KeyCode.Space) && balls.Count > 0)
        {
            shootBall();

        }
    }
    private void ballCreate(float angle)
    {
        GameObject newGameObject = Instantiate(prefab) as GameObject;
        //newGameObject.transform.SetParent(transform);
        BallMovement ballmovement = newGameObject.GetComponent<BallMovement>();
        ballmovement.target = gameObject;
        ballmovement.projectLineAngle = angle;
        if (balls.Count == 0)
        {
            ballmovement.counter = angle;
        }
        else
        {
            BallMovement lastBallmovement = balls[balls.Count - 1].GetComponent<BallMovement>();
            ballmovement.counter = lastBallmovement.counter - 0.01f;
        }
        balls.Add(newGameObject);
        newAngle += 0.5f;
    }
    private void shootBall()
    {
        GameObject shootingBall = balls[balls.Count - 1];
        shootingBall.GetComponent<BallMovement>().isShooting = true;
        shootingBall.GetComponent<BallMovement>().ShootDirection = transform.forward.normalized;
        balls.RemoveAt(balls.Count - 1);
    }
}
