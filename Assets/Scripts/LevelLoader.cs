﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TransitionTypes
{
    
    CrossFade, Fight, Leaves
    
}

public class LevelLoader : MonoBehaviour
{

    //transition times for every transition
    public float CrossfadeTime = 1f;
    public Animator Crossfade;
    
    public float FightTime = 0.75f;
    public Animator Fight;

    public ParticleSystem leaves;
    public float LeavesTime = 0.75f;
    //singleton
    public static LevelLoader instance;

    private void Awake()
    {

        Crossfade.gameObject.SetActive(false);
        Fight.gameObject.SetActive(false);

        if (instance == null)
        {

            instance = this;

        }
        else
        {
            
            Debug.Log("There is already an instance of LevelLoader in the game, destroying this!");
            Destroy(gameObject);
            
        }
        
    }

    private void Start()
    {
        
        //SoundPlayer.instance.SetMusic(Songs.ADRENALINE);
        
    }

    public void LoadScene(string scene, TransitionTypes transition)
    {

        float time = 0f;
        Animator transitionObj = Crossfade;

        switch (transition)
        {
            
            case TransitionTypes.CrossFade:

                time = CrossfadeTime;
                transitionObj = Crossfade;
                StartCoroutine(TransitionRoutine(scene, transitionObj, time));
                
                break;
            case TransitionTypes.Fight:

                time = FightTime;
                transitionObj = Fight;
                StartCoroutine(TransitionRoutine(scene, transitionObj, time));
                
                break;
            case TransitionTypes.Leaves:

                time = FightTime;
                StartCoroutine(TransitionRoutine(scene, leaves, time));
                break;
            

        }

    }
    
    IEnumerator TransitionRoutine(string scene, ParticleSystem transition, float transitionTime)
    {

        transition.Play();
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);

    }

    IEnumerator TransitionRoutine(string scene, Animator transition, float transitionTime)
    {
        
        transition.gameObject.SetActive(true);
        
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);

    }
    
}
