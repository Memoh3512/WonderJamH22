using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public void StartGame()
    {
        LevelLoader.instance.LoadScene("GameplayScene", TransitionTypes.Leaves);
        SoundPlayer.instance.SetMusic(Songs.Village,1.5f, TransitionBehavior.Continue);
        SoundPlayer.instance.SetMusic(Songs.Night,1f, TransitionBehavior.Continue);
        SoundPlayer.instance.SetMusic(Songs.Village,1f, TransitionBehavior.Continue);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayBtnSnd()
    {
        
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Menu button"));
        
    }

}
