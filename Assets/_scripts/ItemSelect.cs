using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject itemSelectPanel;

    public GameObject[] item; // 0 =dog, 1=book, 2=vitamins, 3=knife

    public bool hasDog;
    public bool hasBook;
    public bool hasKnife;
    public bool hasVitamins;
    // Start is called before the first frame update
    void Start()
    {
        gameUI.SetActive(false);
        ShowItemPanel();
        hasBook = false;
        hasDog = false;
        hasKnife = false;
        hasVitamins = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowItemPanel()
    {
        itemSelectPanel.SetActive(true);
    }
    public void HideItemPanel()
    {
        itemSelectPanel.SetActive(false);
        gameUI.SetActive(true);
    }

    public void ChooseDog()
    {
        hasDog = true;
        item[0].SetActive(true);
    }

    public void ChooseBook()
    {
        hasBook = true;
        item[1].SetActive(true);
    }

    public void ChooseVitamins()
    {
        hasVitamins = true;
        item[2].SetActive(true);
    }

    public void ChooseKnife()
    {
        hasKnife = true;
        item[3].SetActive(true);
    }

}
