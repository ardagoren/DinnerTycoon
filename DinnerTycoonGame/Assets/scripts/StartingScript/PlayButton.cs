using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject fallingSystem;
    [SerializeField] GameObject howToPlay;
    Button thisButton;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(playPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void playPressed()
    {
        howToPlay.SetActive(true);
        panel.SetActive(false);
        fallingSystem.SetActive(false);
    }
}
