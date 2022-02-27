using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenuBtns : MonoBehaviour
{

    public void ToMainMenu()
    {

        GameManager.firstPlay = true;
        LevelLoader.instance.LoadScene("MainMenuScene", TransitionTypes.CrossFade);

    }

    public void QuitGame()
    {
        
        Application.Quit();
        
    }
}
