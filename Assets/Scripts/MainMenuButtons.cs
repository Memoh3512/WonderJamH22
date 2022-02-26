using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public void StartGame()
    {
        LevelLoader.instance.LoadScene("GameplayScene", TransitionTypes.Fight);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
