using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatSystem : MonoBehaviour
{
    public enum CombatState { START, PLAYER_SEL, ENEMY_SEL, ACT, WON, LOST};
    public int enemyId;

    public GameObject sceneManager;

    public static int playerHP;
    public static int enemyHP;

    public int PartyLenght;
    
    public GameObject payerPref;
    public GameObject enemyPref;
    public GameObject dialog;
    public GameObject hud;

    public Text diagName;
    public Text diagText;
    public GameObject continueButton;
    public GameObject yesButton;
    public GameObject noButton;

    public Text comName;
    public GameObject CombatHud;
    public GameObject atkButton;
    public GameObject defButton;
    public GameObject runButton;

    public GameObject Inventory;

    public CombatState state;

    CombatUnit playerUnit;
    CombatUnit enemyUnit;
    // Start is called before the first frame update
    void Start()
    {
        state = CombatState.START;
        SetupCombat(0);
        
    }

    // Update is called once per frame
    void SetupCombat(int enemyId)
    {
        GameObject playerGO = Instantiate(payerPref);
        GameObject enemyGO = Instantiate(enemyPref);

        dialog.GetComponent<Animator>().SetBool("isOpen", true);
        playerUnit = playerGO.GetComponent<CombatUnit>();
        enemyUnit = enemyGO.GetComponent<CombatUnit>();

        enemyHP = enemyUnit.res * 3;
        playerHP = playerUnit.res * 5;
        
        comName.text = $"Seu HP: {playerHP}";
        diagName.text = $"{enemyUnit.name} LV{enemyUnit.lvl} HP: {enemyHP}";
        diagText.text = "Eu te desafio!";
        continueButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);


    }

    public void SetState(CombatState currentState){
        state = currentState;
    }

    public void PlayerAttack(){
        var itemMod = Inventory.GetComponent<InventoryManager>().GetAttack();
        var dmg = setDamage(itemMod);
        
    }

    int setDamage(int itemMod){
        var atk = playerUnit.atk;
        var def = enemyUnit.def;
        var dmg = 0;
        switch (itemMod)
        {
            case 0:
                dmg = -atk + def;
                break;
            case 2:
                dmg = atk + 5 - def;
                break;
            case 3:
                dmg = atk + 1 - def;
                break;
            case 4:
                dmg = atk + 2 - def;
                break;
            case 5:
                dmg = atk + 2;
                break;
            default:
                dmg = atk;
                break;
        }
        return dmg;
    }

}
