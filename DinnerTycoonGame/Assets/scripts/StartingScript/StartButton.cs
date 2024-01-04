using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    Button thisButton;
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(StartPressed);
    }

    private void StartPressed()
    {
        SceneManager.LoadScene(1);
    }
}
