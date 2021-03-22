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
        currentTurnState = GameState.PLAYER;
    }

    // Update is called once per frame
    void Update()
    {
        turnStateTracker();
    }

    private void turnStateTracker()
    {
        if (currentTurnState == GameState.PLAYER)
        {
            //IF PLAYER PLAYED CHANGE STATE TO ENEMY
        }

        else if (currentTurnState == GameState.ENEMY)
        {
            //IF ENEMY PLAYED CHANGE STATE TO PLAYER

        }
    }

    private void playerBattleTracker()
    {
        //PLAYER ACTION

    }
}
