using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandScript : MonoBehaviour
{
    Button thisButton;
    public GameObject EklenenMasa;
    public GameObject[] newSpotArray;

    sitting_system sittingSystem;
    money money;

    public int price;
    void Start()
    {
        sittingSystem = GameObject.Find("SittingSystem").GetComponent<sitting_system>();
        money = GameObject.Find("money").GetComponent<money>();
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(RestaurantExpanded);
    }

    public void RestaurantExpanded()
    {
        if (money.moneyCounter >= price)
        {
            money.moneyCounter -= price;
            EklenenMasa.SetActive(true);
            foreach(GameObject x in newSpotArray) //yeni spotlar eklendi
            {
                sittingSystem.spotListesi.Add(x);
            }
            thisButton.interactable = false;
            thisButton.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Restaurant Expanded!";
        }
    }
}
