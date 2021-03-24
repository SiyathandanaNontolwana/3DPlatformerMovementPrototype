using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameState { START, PLAYER, ENEMY, WIN, LOSS }

public class BattleSystem : MonoBehaviour
{

    public GameState currentState;

    public GameObject playerPrefab, enemyPrefab;

    Unit playerUnit, enemyUnit;

    public BattleHUD playerHUD, enemyHUD; 

    void Start()
    {
        currentState = GameState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        GameObject playerGameObject = Instantiate(playerPrefab, new Vector3(-6.5f, -2f, 0f), Quaternion.identity);
        playerUnit = playerGameObject.GetComponent<Unit>();

        GameObject enemyGameObject = Instantiate(enemyPrefab, new Vector3(6.5f, -2f, 0f), Quaternion.identity);
        enemyUnit = enemyGameObject.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        currentState = GameState.PLAYER;
        PlayerTurn();
    }

    void PlayerTurn()
    {

    }

    IEnumerator PlayerAttack()
    {
        //Deal damage to enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.setHP(enemyUnit.currentHP);

        yield return new WaitForSeconds(1f);

        //Check if enemy is dead
        if(isDead)
        {
            //End battle
            currentState = GameState.WIN;
            EndGame();
        }
        else
        {
            //Enemy turn
            currentState = GameState.ENEMY;
            StartCoroutine(EnemyTurn());
        }
    }

    void EndGame()
    {
        if(currentState == GameState.WIN)
        {
            Debug.Log("You Win");
        }
        else if(currentState == GameState.LOSS)
        {
            Debug.Log("You Lost");
        }

    }

    IEnumerator EnemyTurn()
    {

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.setHP(playerUnit.currentHP);

        if(isDead)
        {
            currentState = GameState.LOSS;
            EndGame();
        }
        else
        {
            currentState = GameState.PLAYER;
            PlayerTurn();
        }


    }

    public void AttackButton()
    {
        if (currentState != GameState.PLAYER)
        {
            return;
        }
        else
            StartCoroutine(PlayerAttack());
    }

}
