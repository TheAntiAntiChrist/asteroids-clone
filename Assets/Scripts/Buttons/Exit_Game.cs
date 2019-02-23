using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit_Game : MonoBehaviour
{

    public GameObject ExitGameButton;

    void Start()
    {

        Button button = ExitGameButton.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
