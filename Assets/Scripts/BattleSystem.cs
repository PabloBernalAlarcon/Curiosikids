using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE}
public class BattleSystem : MonoBehaviour
{
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public TMP_Text dialogueText;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    private Unit playerUnit;
    private Unit enemyUnit;

    public BattleState bState;    // Start is called before the first frame update
    void Start()
    {
        bState = BattleState.START;
       StartCoroutine( SetupBattle());
    }

    IEnumerator SetupBattle()
    {
       GameObject pleyer = Instantiate(playerPrefab,playerBattleStation);
        playerUnit = pleyer.GetComponent<Unit>();
        GameObject enemi = Instantiate(enemyPrefab,enemyBattleStation);
        enemyUnit = enemi.GetComponent<Unit>();
        dialogueText.text = "A wild "+enemyUnit.unitName+" has appeared!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        bState = BattleState.PLAYERTURN;

        yield return new WaitForSeconds(5);
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action for " + playerUnit.unitName;
    }

    public void onAttackButton()
    {
        if (bState != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(5);
    }

}
