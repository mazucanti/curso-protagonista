using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatSystem : MonoBehaviour
{
    public enum CombatState { START, PLAYER_SEL, ENEMY_SEL, ACT, WON, LOST};
    public int enemyId;
    
    public GameObject payerPref;
    public GameObject enemyPref;
    public GameObject dialog;
    public GameObject hud;

    public Text diagName;
    public Text diagText;
    public GameObject continueButton;
    public GameObject yesButton;
    public GameObject noButton;

    public GameObject Inventory;

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

        dialog.GetComponent<DialogueManager>().animator.SetBool("isOpen", true);
        playerUnit = playerGO.GetComponent<CombatUnit>();
        enemyUnit = enemyGO.GetComponent<CombatUnit>();
        diagName.text = $"{enemyUnit.name} LVL{enemyUnit.lvl} HP: {enemyUnit.hea}";
        diagText.text = "Eu te desafio!";
        continueButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);


    }

    public void PlayerAttack(){
        var itemMod = Inventory.GetComponent<InventoryManager>().GetAttack();
        var dmg = setDamage(itemMod);
        
    }

    int setDamage(int itemMod){
        var atk = playerUnit.atk;
        var dmg = 0;
        switch (itemMod)
        {
            case 0:
                dmg = -atk;
                break;
            case 2:
                dmg = atk + 5;
                break;
            case 3:
                dmg = atk + 1;
                break;
            case 4:
                dmg = atk + 2;
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
