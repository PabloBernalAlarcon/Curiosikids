using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE}
public class BattleSystem : MonoBehaviour
{

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
        SetupBattle();
    }

    void SetupBattle()
    {
       GameObject pleyer = Instantiate(playerPrefab,playerBattleStation);
        playerUnit = pleyer.GetComponent<Unit>();
        GameObject enemi = Instantiate(enemyPrefab,enemyBattleStation);
        enemyUnit = enemi.GetComponent<Unit>();
        dialogueText.text = "A wild "+enemyUnit.unitName+" has appeared!";
    }

}
