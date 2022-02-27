using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReasonOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.deathNote;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
