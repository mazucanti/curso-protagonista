using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text walletValue;
    public Text[] items;
    static int wallet = 300;
    static int[] itemQtd = { 3, 3, 3, 3, 3, 3, 3 };
    int[] itemPrices = { 15, 10, 20, 15, 10, 20, 15 };
    //string[] itemNames = { "item1", "item2", "item3" };
    


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
        if(wallet > 0 & itemQtd[itemId] > 0) 
        {
            wallet = wallet - itemPrices[itemId];
            itemQtd[itemId]--; 
            
        };
        
    }
}
