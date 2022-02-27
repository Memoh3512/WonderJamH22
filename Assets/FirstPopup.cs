using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstPopup : MonoBehaviour
{
    public TMP_InputField kingName;
    public GameObject tut1;
    public GameObject tut2;

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
        string name = kingName.text.ToLower();
        name = name[0].ToString().ToUpper() + name.Substring(1);
        GameManager.startGame(name);
        tut1.SetActive(true);
        tut2.SetActive(true);
        Destroy(gameObject);
        
    }
}
