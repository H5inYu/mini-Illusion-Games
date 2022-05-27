using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text scorePanel;
    void Start()
    {

        scorePanel.text = "0";
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collid with " + other.name);
        if (other.CompareTag("Coin") && other.GetComponent<TargetMovement>().represent.name == gameObject.GetComponent<PlayerColor>().represent.name)
        {
            Destroy(other);
            increaseScore();
        }
        else
        {
            Debug.Log(other.name);
            decreaseScore();
        }
    }
    void increaseScore()
    {
        scorePanel.text = (int.Parse(scorePanel.text) + 1).ToString();
    }
    void decreaseScore()
    {
        scorePanel.text = (int.Parse(scorePanel.text) - 1).ToString();
        if (int.Parse(scorePanel.text) == 0)
        {
            scorePanel.text = "Dead";
        }
    }
}
