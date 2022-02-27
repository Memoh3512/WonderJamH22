using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSFXAfterX : MonoBehaviour
{

    public float time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sfx());
    }

    IEnumerator sfx()
    {

        yield return new WaitForSeconds(time);
        //TODO FLO sfx trompet

    }
}
