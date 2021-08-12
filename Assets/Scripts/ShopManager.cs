using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text walletValue;
    public Text[] items;
    public GameObject inventory;

    static int wallet = 200;
    //static int[] itemQtd = { 3, 3, 3, 3, 3, 3, 3 };
    static int[] itemPrices = { 80, 380, 280, 80, 480, 680, 100000 };

    private void Start()
    {
        // Increases item prices every time player enters the shop.
        for (int i=0; i<6; i++)
        {
            itemPrices[i] += 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        walletValue.text = $"{wallet}";
        for(int i = 0; i < 7; i++)
        {
            items[i].text = $"${itemPrices[i]}";
        };
         
    }

    public void Buy(int itemId)
    {
        if (wallet - itemPrices[itemId] >= 0)
        {
            wallet = wallet - itemPrices[itemId];
            //itemQtd[itemId]--;
            inventory.GetComponent<InventoryManager>().Increase(itemId + 1);
        }
        else
        {
            // implementar diálogo vendedor
        }
    }
}
