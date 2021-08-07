using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public GameObject infoBox;
    public Text[] itemInfos;

    private string[] names = { "Pão", "Fatia de Pão", "Faca de Pão", "Papel", "Caneta", "Marca-Texto", "Urso de Pelúcia", "Tesouro", "Certificado de Tempo Livre" };

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
        infoBox.GetComponentsInChildren<Text>()[1].text = itemInfos[i].text;
        infoBox.SetActive(true);
    }

    public void CloseInfo ()
    {
        infoBox.SetActive(false);
    }
}
