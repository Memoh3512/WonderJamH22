using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public void StartGame()
    {
        LevelLoader.instance.LoadScene("GameplayScene", TransitionTypes.Leaves);
        SoundPlayer.instance.SetMusic(Songs.Village,1.5f, TransitionBehavior.Stop);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
