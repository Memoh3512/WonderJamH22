using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    [SerializeField] 
    public GameObject spriteSquare;
    public GameObject textAmount;
    private int state = 0;//0 inactif,1 monte,2 attend, 3 descend
    private float speed;
    private float baseCounter = 1;
    private float counter = 0;

    private List<Notification> toDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toDisplay.Count>0 && state==0)
        {
            spriteSquare.GetComponent<SpriteRenderer>().sprite = toDisplay[0].logo;
            textAmount.GetComponent<TextMeshPro>().text = toDisplay[0].text;
            toDisplay.Remove(toDisplay[0]);
            state = 1;
        }
        
    }
    public void startNotification(Sprite ressourceSprite, int amount)
    {
        
        
        string amountStr = amount.ToString();
        if (amount > 0)
        {
            amountStr = "+" + amountStr;
        }
        
        toDisplay.Add(new Notification(ressourceSprite,amountStr));
    }
}
