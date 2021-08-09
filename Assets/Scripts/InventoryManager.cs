using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public GameObject infoBox;
    public GameObject[] items;

    private string[] names = { "Fatia de Pão", "Pão", "Faca de Pão", "Papel", "Caneta", "Marca-Texto", "Urso de Pelúcia", "Tesouro", "Certificado de Tempo Livre" };
    static int[] itemQtd = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

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
        for (int i=0; i<9; i++)
        {
            items[i].GetComponentsInChildren<Text>()[3].text = $"(x{itemQtd[i]})"; // shows the smount

            if (itemQtd[i] == 0)
            {
                string iconHex;
                if(i==5)
                    iconHex = "#FFD70070";
                else
                    iconHex = "#4D4D4D70";

                if (ColorUtility.TryParseHtmlString(iconHex, out Color iconColor))
                {
                    items[i].GetComponentsInChildren<SpriteRenderer>()[2].color = iconColor;
                }

                if (ColorUtility.TryParseHtmlString("#D1D1D170", out Color nameColor))
                {
                    items[i].GetComponentsInChildren<Text>()[0].color = nameColor;
                    items[i].GetComponentsInChildren<Text>()[3].color = nameColor;
                }
            }

            else
            {
                if (i==5)
                    items[i].GetComponentsInChildren<SpriteRenderer>()[2].color = new Color(255, 215, 0, 255);
                else
                    items[i].GetComponentsInChildren<SpriteRenderer>()[2].color = Color.white;

                items[i].GetComponentsInChildren<Text>()[0].color = Color.white;
                items[i].GetComponentsInChildren<Text>()[3].color = Color.white;
            }
        }
    }
}
