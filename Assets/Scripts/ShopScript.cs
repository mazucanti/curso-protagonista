using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public Text walletValue;
    public Text[] items;
    public int wallet = 300;
    public int[] itemQtd = { 3, 3, 2 };
    public int[] itemPrices = { 15, 10, 20 };
    public string[] itemNames = { "item1", "item2", "item3" };
    


    // Update is called once per frame
    void Update()
    {
        walletValue.text = $"Carteira {wallet}";
        for(int i = 0; i < 3; i++)
        {
            items[i].text = $"{itemNames[i]} ({itemQtd[i]}): ${itemPrices[i]}";
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
