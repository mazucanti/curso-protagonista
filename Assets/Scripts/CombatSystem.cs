using System.Collections;
using System.Collections.Generic;
using static System.Random;
using UnityEngine;
using UnityEngine.UI;

public class CombatSystem : MonoBehaviour
{
    public enum CombatState { START, PLAYER_TURN, ENEMY_TURN, WON, LOST, ESCAPED};

    public GameObject shop;

    public GameObject sceneManager;

    public static int playerHP;
    public int enemyHP;

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
    public GameObject combatHud;
    public GameObject atkButton;
    public GameObject defButton;
    public GameObject runButton;

    public GameObject Inventory;

    public CombatState state;

    System.Random r = new System.Random();
    CombatUnit playerUnit;
    CombatUnit enemyUnit;
    // Start is called before the first frame update
    void Start()
    {
        state = CombatState.START;
        SetupCombat(0);
        
    }

    void Update(){
        comName.text = $"Seu HP: {playerHP}";
        diagName.text = $"Oponente: LV{enemyUnit.lvl} HP: {enemyHP}";
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
        
        diagText.text = "Eu te desafio!\nMe transformarei em uma vil criatura!";
        continueButton.SetActive(true);
        yesButton.SetActive(false);
        noButton.SetActive(false);

    }

    public void SetState(CombatState currentState){
        state = currentState;
    }

    public void OnContinue(){
        switch (state)
        {
            case CombatState.START:
                SetState(CombatState.PLAYER_TURN);
                SetupHUD();
                break;
            case CombatState.ENEMY_TURN:
                if (playerHP <= 0){
                    SetState(CombatState.LOST);
                    diagText.text = "Você perdeu!";
                }
                else{
                    SetState(CombatState.PLAYER_TURN);
                    SetupHUD();
                }
                break;
            case CombatState.WON:
                SetupDialog();
                shop.GetComponent<ShopManager>().combatReward(100);
                diagText.text = $"Você ganhou a batalha, recebeu $100";
                sceneManager.GetComponent<LoadScenes>().LoadRoom();
                break;
            case CombatState.LOST:
                sceneManager.GetComponent<LoadScenes>().LoadRoom();
                break;
            case CombatState.ESCAPED:
                sceneManager.GetComponent<LoadScenes>().LoadRoom();
                break;
        }
    }

    void SetupHUD(){
        dialog.GetComponent<Animator>().SetBool("isOpen", false);
        continueButton.SetActive(false);
        combatHud.GetComponent<Animator>().SetBool("isOpen", true);
        atkButton.SetActive(true);
        defButton.SetActive(true);
        runButton.SetActive(true);
    }

    void SetupDialog(){
        combatHud.GetComponent<Animator>().SetBool("isOpen", false);
        atkButton.SetActive(false);
        defButton.SetActive(false);
        runButton.SetActive(false);
        dialog.GetComponent<Animator>().SetBool("isOpen", true);
        continueButton.SetActive(true);
    }

    void EnemyAttack(){
        var dmg = setDamage(100, enemyUnit, playerUnit);
        playerHP = playerHP - dmg;
    }

    public void OnAttack(){
        if (state == CombatState.PLAYER_TURN){
            SetupDialog();
            PlayerAttack();
            if (enemyHP <= 0){
                SetState(CombatState.WON);
            }
            else{
                SetState(CombatState.ENEMY_TURN);
            }
        }
    }

    public void OnDefense(){
        if (state == CombatState.PLAYER_TURN){
            SetupDialog();
            var itemId = Inventory.GetComponent<InventoryManager>().GetDefense();
            SetState(CombatState.ENEMY_TURN);
            var dmg = setDamage(100, enemyUnit, playerUnit);
            PlayerDefense(itemId, dmg);
        }
    }

    public void OnRun(){
        if (state == CombatState.PLAYER_TURN){
            SetState(CombatState.ESCAPED);
            
            var escape = r.Next(playerUnit.agi) - r.Next(enemyUnit.agi);
            if (escape > 0){
                SetupDialog();
                diagText.text = "Você escapou!";
            }
            else{
                diagText.text = "Você falhou em escapar!";
                SetState(CombatState.ENEMY_TURN);
            }
        }
    }

    void PlayerAttack(){
        
        var hit_miss = r.Next(playerUnit.acc) -  r.Next(enemyUnit.agi) + 3;
        if (hit_miss >= 0){
            var itemId = Inventory.GetComponent<InventoryManager>().GetAttack();
            var dmg = setDamage(itemId, playerUnit, enemyUnit);
            enemyHP = enemyHP - dmg;
            diagText.text = $"Você ataca o oponente e dá {dmg} de dano!";
        }
        else if (hit_miss == enemyUnit.def){
            diagText.text = "O inimigo defendeu seu ataque!";
        }
        else{
            diagText.text = "Você errou!";
        }    
    }

    void PlayerDefense(int itemId, int dmg){
        dmg = dmg - playerUnit.def;
        if (dmg <= 0){
            dmg = 1;
        }
        if(itemId == 0){
            diagText.text = "Você come a fatia de pão, ganhando 5 HP!";
            playerHP = playerHP + 5;
        }
        else if (itemId == 1){
            diagText.text = "Você tentou engolir o pão inteiro e agora está com azia";
            playerHP = playerHP - 1;
        }

        else{
            diagText.text = $"Você recebeu {dmg} de dano!";
        }
    }
    

    //public void PlayerDefense(itemId){

   // }

    int setDamage(int itemId, CombatUnit source, CombatUnit target){
        var atk = source.atk;
        var def = target.def;
        var dmg = 0;
        switch (itemId)
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
        dmg = dmg * source.lvl;
        return dmg;
    }
}
