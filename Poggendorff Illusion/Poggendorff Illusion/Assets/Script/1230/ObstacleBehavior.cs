using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public GameObject GM;
    public float obstacleFromBall;
    public GameObject line1;
    public GameObject line2;
    public float lineWidth;
    public float offset;
    private Color RealLineColor;
    private Color InterveneLineColor;
    private Vector3 lineOffset;
    public void ChangeColor()
    {
        RealLineColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        InterveneLineColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        offset = offset * (Random.Range(0, 2) * 2 - 1);

    }
    public void move(Vector3 cursorPosition, Vector3 whiteBallPosition)
    {
        GetComponent<MeshRenderer>().enabled = true;
        Vector3 direction = (whiteBallPosition - cursorPosition);
        direction.y = 0;
        direction = direction.normalized;
        transform.position = whiteBallPosition + direction * obstacleFromBall;
        transform.LookAt(whiteBallPosition);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 150, transform.eulerAngles.z);

        // light from obstacle to whiteBall
        LineRenderer ObstacleToWhiteBallLine = GetComponent<LineRenderer>();
        ObstacleToWhiteBallLine.SetPosition(0, transform.position);
        ObstacleToWhiteBallLine.SetPosition(1, whiteBallPosition);
        ObstacleToWhiteBallLine.startWidth = lineWidth;
        ObstacleToWhiteBallLine.endWidth = lineWidth;
        ObstacleToWhiteBallLine.material = new Material(Shader.Find("Sprites/Default"));


        // RealLine
        Vector3 TargetPoint = transform.position + direction * 4;
        LineRenderer RealLine = line1.GetComponent<LineRenderer>();
        RealLine.SetPosition(0, transform.position);
        RealLine.SetPosition(1, TargetPoint);
        RealLine.startWidth = lineWidth;
        RealLine.endWidth = lineWidth;
        RealLine.material = new Material(Shader.Find("Sprites/Default"));
        RealLine.material.color = RealLineColor;

        // InterveneLine
        lineOffset = transform.forward * offset;
        LineRenderer InterveneLine = line2.GetComponent<LineRenderer>();
        InterveneLine.SetPosition(0, transform.position + lineOffset);
        InterveneLine.SetPosition(1, TargetPoint + lineOffset);
        InterveneLine.startWidth = lineWidth;
        InterveneLine.endWidth = lineWidth;
        InterveneLine.material = new Material(Shader.Find("Sprites/Default"));
        InterveneLine.material.color = InterveneLineColor;

    }
    public void EnterHittingAnimation()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }


}
