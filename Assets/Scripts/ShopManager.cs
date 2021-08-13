using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text walletValue;
    public Text[] items;
    public GameObject inventory;
    public GameObject noMoneyDialogue;
    public GameObject inflationDialogue;
    public GameObject increaseCanvas;
    public GameObject increaseItemPrefab;
    private GameObject increaseItem;

    static int wallet = 200;
    static int[] itemPrices = { 100, 400, 300, 100, 500, 700, 100000 };
    static bool inflation = false;
    static int inflationCount = 1;

    private void Start()
    {
        // Increases item prices every 3 times player enters the shop. 
        if (inflationCount % 3 == 0)
        {
            inflation = true;
        }
        if (inflation)
        {
            for (int i = 0; i < 6; i++)
            {
                itemPrices[i] += 20;
            }
            inflationDialogue.GetComponent<Interactable>().StartDialogueShop();

            inflation = false;
        }
        inflationCount++;

        // Shows prices.
        for (int i = 0; i < 7; i++)
        {
            items[i].text = $"${itemPrices[i]}";
        };

    }

    void Update()
    {
        // Show wallet amount.
        walletValue.text = $"{wallet}";         
    }

    public void Buy(int itemId)
    {
        // If player has sufficient amount in wallet, decreases amount from wallet and increases item amount.
        if (wallet - itemPrices[itemId] >= 0)
        {
            wallet = wallet - itemPrices[itemId];
            inventory.GetComponent<InventoryManager>().Increase(itemId + 1);

            // Increasing animation.
            increaseItem = Instantiate(increaseItemPrefab, increaseCanvas.transform);
            increaseItem.transform.position = items[itemId].transform.position;
            increaseItem.transform.Translate(0, 0.5f, 0);

            FindObjectOfType<DialogueManagerShop>().animator.SetBool("isOpen", false);
        }

        // If player doesn't have enough money, shows vendor dialogue.
        else
        {
            noMoneyDialogue.GetComponent<Interactable>().StartDialogueShop();
        }
    }
}
