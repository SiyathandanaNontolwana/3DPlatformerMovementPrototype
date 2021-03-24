using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameState { START, PLAYER, ENEMY, WIN, LOSS }

public class BattleSystem : MonoBehaviour
{
    public GameState currentState;

    Unit playerUnit;
    Unit enemyUnit;


    //INFORMATION FOR INSTANTIATION
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    //HUDS

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.START;
        StartCoroutine(setUp());
    }

    IEnumerator setUp()
    {
        //BATTLE SETUP
        GameObject playerGameObject = Instantiate(playerPrefab, new Vector3(-6.5F, -2F, 0F), Quaternion.identity);
        playerUnit = playerGameObject.GetComponent<Unit>();

        GameObject enemyGameObject = Instantiate(enemyPrefab, new Vector3 (6.5F, -2F,0F), Quaternion.identity);
        enemyUnit = enemyGameObject.GetComponent<Unit>();

        playerHUD.setHUD(playerUnit);
        enemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        currentState = GameState.PLAYER;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            //End Game
            currentState = GameState.WIN;
            EndBattle();
        }

        else
        {
            //enemy turn
            currentState = GameState.ENEMY;
            StartCoroutine(EnemyTurn());
        }
    }

    void EndBattle()
    {
        if (currentState == GameState.WIN)
            Debug.Log("You win");
        else if (currentState == GameState.LOSS)
            Debug.Log("You lose");
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            currentState = GameState.LOSS;
        }
        else
        {
            currentState = GameState.PLAYER;
            PlayerTurn();
        }

    }

    void PlayerTurn()
    {

    }

    public void OnAttackButton()
    {
        if(currentState != GameState.PLAYER)
        {
            return;
        }

        StartCoroutine(PlayerAttack());

    }
}
