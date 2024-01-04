using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseShop : MonoBehaviour
{
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject panel;

    Button thisButton;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ShopClosed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShopClosed()
    {
        panel.SetActive(false);
        shopButton.SetActive(true);
    }
}
