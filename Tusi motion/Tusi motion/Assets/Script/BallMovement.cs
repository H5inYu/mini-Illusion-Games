using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float projectLineAngle;
    Vector3 ballPosition;
    public float counter;
    private float ballSpeed = 0.01f;
    public bool isShooting = false;
    private float shootingSpeed = 50f;

    public GameObject target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public Vector3 ShootDirection;

    void Update()
    {
        if (!isShooting)
        {
            TusiMotion();
        }
        else
        {
            transform.position += ShootDirection * shootingSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, target.transform.position) > 100f)
        {
            Destroy(gameObject);
        }

    }
    void TusiMotion()
    {
        ballPosition.Set(2 * Mathf.Cos(projectLineAngle) * Mathf.Cos(counter - projectLineAngle), 0f,
            2 * Mathf.Sin(projectLineAngle) * Mathf.Cos(counter - projectLineAngle));
        transform.position = target.transform.position + ballPosition;
        counter += ballSpeed;
    }

}
