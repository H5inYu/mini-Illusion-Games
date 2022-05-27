using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallBehavior : MonoBehaviour
{
    public STATE state;
    public GameObject gameManager;
    private Game gameManagerScript;
    public enum STATE
    {
        START,
        MOVE,
        STOP
    }

    private void Start()
    {
        state = STATE.START;
        gameManagerScript = gameManager.GetComponent<Game>();
    }

    private void Update()
    {

        if (state == STATE.MOVE)
        {
            if (Vector3.Magnitude(GetComponent<Rigidbody>().velocity) <= 0.05f)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                state = STATE.STOP;
                gameManagerScript.gameState = Game.GAMESTATE.ADJUST;
                if (gameManagerScript.currentPlayer == Game.PLAYER.P1)
                {
                    gameManagerScript.currentPlayer = Game.PLAYER.P2;
                }
                else
                {
                    gameManagerScript.currentPlayer = Game.PLAYER.P1;
                }
                if (gameManagerScript.GetComponent<Game>().isIllusion)
                {
                    gameManagerScript.isIllusion = false;
                }
            }
        }
    }
}
