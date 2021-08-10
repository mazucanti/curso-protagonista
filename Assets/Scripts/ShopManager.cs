using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text walletValue;
    public Text[] items;
    public GameObject inventory;

    static int wallet = 300;
    static int[] itemQtd = { 3, 3, 3, 3, 3, 3, 3 };
    int[] itemPrices = { 15, 10, 20, 15, 10, 20, 15 };
    


    // Update is called once per frame
    void Update()
    {
        walletValue.text = $"{wallet}";
        for(int i = 0; i < 7; i++)
        {
            items[i].text = $"({itemQtd[i]}): ${itemPrices[i]}";
        };
         
    }

    public void Buy(int itemId)
    {
        if(itemQtd[itemId] > 0) 
        {
            if (wallet - itemPrices[itemId] > 0)
            {
                wallet = wallet - itemPrices[itemId];
                itemQtd[itemId]--;
                inventory.GetComponent<InventoryManager>().Increase(itemId + 1);
            }
            else
            {
                // implementar diálogo vendedor
            }
        }
        
    }
}
