using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{

    public GameObject StartGameButton;

    void Start()
    {

        Button button = StartGameButton.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        Debug.Log("Game loading...");
    }
}
