using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("hallway scene");
    }

    public void QuitGame()
    {
        Debug.Log("You quit the game");
        Application.Quit();

    }
}
