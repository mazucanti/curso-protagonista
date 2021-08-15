using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public GameObject infoBox;
    public GameObject[] items;

    private string[] names = { "Pão", "Faca de Pão", "Papel", "Caneta", "Marca-Texto", "Urso de Pelúcia", "Certificado de Tempo Livre" };
    static int[] itemQtd = { 0, 0, 0, 0, 0, 0, 0 };
    static int attack = 100; // not equipped
    static int defense = 100; // not equipped

    // Start is called before the first frame update
    void Start()
    {
        infoBox.SetActive(false);
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Enter ()
    {
        ShowItems();
        inventory.SetActive(true);
    }

    public void Exit()
    {
        infoBox.SetActive(false);
        inventory.SetActive(false);
    }

    public void ShowInfo (int i)
    {
        //infoBox.GetComponent<RectTransform>().localPosition = Input.mousePosition;
        infoBox.GetComponentsInChildren<Text>()[0].text = names[i];
        infoBox.GetComponentsInChildren<Text>()[1].text = items[i].GetComponentsInChildren<Text>()[2].text;
        infoBox.SetActive(true);
    }

    public void CloseInfo ()
    {
        infoBox.SetActive(false);
    }

    public void Increase (int itemId)
    {
        itemQtd[itemId]++;
    }

    public void Decrease(int itemId)
    {
        itemQtd[itemId]--;
    }

    private void ShowItems ()
    {
        for (int i=0; i<7; i++)
        {
            items[i].GetComponentsInChildren<Text>()[3].text = $"(x{itemQtd[i]})"; // shows the amount

            // If itemQtd = 0, set transparency to 70.
            if (itemQtd[i] == 0)
            {
                string iconHex;
                if(i==4)
                    iconHex = "#FFD70070"; // "marca-texto" has a different color
                else
                    iconHex = "#4D4D4D70";

                if (ColorUtility.TryParseHtmlString(iconHex, out Color iconColor))
                {
                    items[i].GetComponentsInChildren<SpriteRenderer>()[2].color = iconColor; // icon
                }

                if (ColorUtility.TryParseHtmlString("#D1D1D170", out Color textColor))
                {
                    items[i].GetComponentsInChildren<Text>()[0].color = textColor; // name
                    items[i].GetComponentsInChildren<Text>()[3].color = textColor; // qtd

                    if(i < 6)
                    {
                        items[i].GetComponentsInChildren<Text>()[4].color = textColor; // attack text
                        items[i].GetComponentsInChildren<Button>()[1].GetComponent<Image>().color = Color.white; // attack background
                        items[i].GetComponentsInChildren<Text>()[5].color = textColor; // defense text
                        items[i].GetComponentsInChildren<Button>()[2].GetComponent<Image>().color = Color.white; // defense background

                    }
                }
            }

            // If itemQtd != 0, set transparency to 255 and set color according to selected attack and defense.
            else
            {
                if (i==4)
                    items[i].GetComponentsInChildren<SpriteRenderer>()[2].color = new Color(255, 215, 0, 255); // icon (marca-texto)
                else
                    items[i].GetComponentsInChildren<SpriteRenderer>()[2].color = Color.white; // icon

                items[i].GetComponentsInChildren<Text>()[0].color = Color.white; // name
                items[i].GetComponentsInChildren<Text>()[3].color = Color.white; // qtd

                if (i < 6)
                {
                    items[i].GetComponentsInChildren<Text>()[4].color = Color.white; // attack text
                    items[i].GetComponentsInChildren<Button>()[1].GetComponent<Image>().color = Color.white; // attack background
                    items[i].GetComponentsInChildren<Text>()[5].color = Color.white; // defense text
                    items[i].GetComponentsInChildren<Button>()[2].GetComponent<Image>().color = Color.white; // defense background
                }
            }

            // Eligible items for attack and defense.
            if (i < 6)
            {

                // If item is set to "attack", set attack button color to green.
                if (attack == i)
                {
                    if (ColorUtility.TryParseHtmlString("#90FF8F", out Color backColor))
                    {
                        items[i].GetComponentsInChildren<Button>()[1].GetComponent<Image>().color = backColor; // button background
                    }

                    if (ColorUtility.TryParseHtmlString("#60C058FF", out Color textColor))
                    {
                        items[i].GetComponentsInChildren<Text>()[4].color = textColor; // button text
                    }
                }

                // If item is set to "defense", set defense button color to green.
                if (defense == i)
                {
                    if (ColorUtility.TryParseHtmlString("#90FF8F", out Color backColor))
                    {
                        items[i].GetComponentsInChildren<Button>()[2].GetComponent<Image>().color = backColor; // button background
                    }

                    if (ColorUtility.TryParseHtmlString("#60C058FF", out Color textColor))
                    {
                        items[i].GetComponentsInChildren<Text>()[5].color = textColor; // button text
                    }
                }
            }

        }
    }

    public void Attack (int itemId)
    {
        if (attack == itemId)
        {
            attack = 100; // unequip
            itemQtd[itemId]++;
        }

        else if (itemQtd[itemId] != 0)
        {
            if (attack != 100)
                itemQtd[attack]++;

            attack = itemId; // equip
            itemQtd[itemId]--;
        }

        ShowItems();
    }

    public void Defense (int itemId)
    {
        if (defense == itemId)
        {
            defense = 100; // unequip
            itemQtd[itemId]++;
        }

        else if (itemQtd[itemId] != 0)
        {
            if (defense != 100)
                itemQtd[defense]++;

            defense = itemId; // equip
            itemQtd[itemId]--;
        }

        ShowItems();
    }
}
