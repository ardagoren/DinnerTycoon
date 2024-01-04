using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    Button thisButton;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ShopClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShopClicked()
    {
        panel.SetActive(true);
        gameObject.SetActive(false);
    }
}
