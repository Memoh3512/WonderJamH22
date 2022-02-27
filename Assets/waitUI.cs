using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.firstPlay) StartCoroutine(waitCorUI());
        else GetComponent<Canvas>().enabled = true;
    }

    IEnumerator waitCorUI()
    {

        yield return new WaitForSeconds(1.35f);

        GetComponent<Canvas>().enabled = true;

    }
}
