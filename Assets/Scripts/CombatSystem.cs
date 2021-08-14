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
    public Transform enemyPos;

    Unit playerUnit;
    Unit enemyUnit;
    // Start is called before the first frame update
    void Start()
    {
        CombatState = CombatState.START;
        SetupCombat(0);
        
    }

    // Update is called once per frame
    void SetupCombat(int enemyId)
    {
        GameObject playerGO = Instantiate(payerPref);
        GameObject enemyGO = Instantiate(enemyPref, enemyPos);

    }
}
