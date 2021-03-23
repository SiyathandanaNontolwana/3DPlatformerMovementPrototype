using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { NEUTRAL, PLAYER, ENEMY }

public class BattleHandler : MonoBehaviour
{
    GameState currentTurnState;


    //PLAYER STATS
    public int playerHealth = 0;
    public int playerDefence = 0;
    public int playerAccuracy = 0;
    public int playerMinDamage = 0;
    public int playerMaxDamage = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTurnState = GameState.NEUTRAL;
    }

    // Update is called once per frame
    void Update()
    {
        turnStateTracker();
    }

    //KEEP TRACK OF GAME STATES
    private void turnStateTracker()
    {
        switch (currentTurnState)
        {
            case (GameState.NEUTRAL):
                //SWITCH TO PLAYER STATE
                currentTurnState = GameState.PLAYER; //Game will switch from neutral to player. In future iteration, I will have speed to determine initiative.
                break;

            case (GameState.PLAYER):
                //DO PLAYER ACTION
                playerAction();
                break;

            case (GameState.ENEMY):
                //DO ENEMY ACTION
                enemyAction();
                break;
        }
            
    }

    private void playerAction()
    {
        //PLAYER ACTIONS CODED HERE AND CALLED IN SWITCH STATEMENT
    }

    private void enemyAction()
    {
        //ENEMY ACTIONS CODED HERE AND CALLED IN SWITCH STATEMENT
    }
}
