using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TavukRecipe : MonoBehaviour
{
    Button thisButton;

    sitting_system sittingSystem;
    money money;

    public int price;
    void Start()
    {
        sittingSystem = GameObject.Find("SittingSystem").GetComponent<sitting_system>();
        money = GameObject.Find("money").GetComponent<money>();
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(RecipeAdded);
    }
    
    public void RecipeAdded()
    {
        if (money.moneyCounter >= price)
        {
            money.moneyCounter -= price;
            sittingSystem.yemekCesidi++;
            thisButton.interactable = false;
            thisButton.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Learned!";
        }
    }
}
