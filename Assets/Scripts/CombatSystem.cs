using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatSystem : MonoBehaviour
{
    public enum CombatState { START, PLAYER_SEL, ENEMY_SEL, ACT, WON, LOST}
    public int enemyId;
    public GameObject payerPref;
    public GameObject enemyPref;

    public Text diagName;
    public Text diagText;

    CombatUnit playerUnit;
    CombatUnit enemyUnit;
    // Start is called before the first frame update
    void Start()
    {
        var state = CombatState.START;
        SetupCombat(0);
        
    }

    // Update is called once per frame
    void SetupCombat(int enemyId)
    {
        GameObject playerGO = Instantiate(payerPref);
        GameObject enemyGO = Instantiate(enemyPref);

        playerUnit = playerGO.GetComponent<CombatUnit>();
        enemyUnit = enemyGO.GetComponent<CombatUnit>();
        diagName.text = enemyUnit.name;
        diagText.text = "Eu te desafio!";

    }
}
