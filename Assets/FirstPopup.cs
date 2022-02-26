using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstPopup : MonoBehaviour
{
    public TMP_InputField kingName;

    private void Start()
    {

        if (!GameManager.firstPlay)
        {
            GameManager.playNextEvent();
            Destroy(gameObject);
        }
        
    }

    public void StartGame()
    {
        
        GameManager.startGame(kingName.text);
        Destroy(gameObject);
        
    }
}
