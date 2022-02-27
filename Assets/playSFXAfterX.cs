using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSFXAfterX : MonoBehaviour
{

    public float time = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sfx());
    }

    IEnumerator sfx()
    {

        yield return new WaitForSeconds(time);
        
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Fight trumpet"), 5f);
        yield return new WaitForSeconds(0.5f);
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Alatak"), 2f);
        yield return new WaitForSeconds(1.25f);
        SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_BattleCry"), 2f);
        
    }
}
