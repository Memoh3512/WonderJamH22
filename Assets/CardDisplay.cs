using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    private CardEvent currentCard;

    public GameObject choicePrefab;
    
    public TextMeshProUGUI title, desc;

    public float btnPadding = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        //SetCardEvent(new CardEvent());
        UpdateUI();
    }

    public void SetCardEvent(CardEvent card)
    {

        currentCard = card;

    }

    private void UpdateUI()
    {

        //update text

        if (choicePrefab == null || currentCard == null) return;
        
        title.text = currentCard.Name;
        desc.text = currentCard.Description;
        
        //update choices
        foreach (Button b in transform.GetComponentsInChildren<Button>())
        {
            
            Destroy(b.gameObject);
            
        }

        int nb = currentCard.getNbChoices;
        float width = GetComponent<RectTransform>().sizeDelta.x;

        if (nb <= 0) return;

        float btnWidth = width - ((nb - 1) * btnPadding);
        btnWidth /= (float)nb;

        float startPos = -(width / 2f) + btnWidth / 2f;
        
        foreach (Choice c in currentCard.getChoices)
        {

            GameObject choice = Instantiate(choicePrefab, transform);
            choice.GetComponent<RectTransform>().sizeDelta = new Vector2(btnWidth, choice.GetComponent<RectTransform>().sizeDelta.y);
            choice.GetComponent<RectTransform>().localPosition = new Vector3(startPos, -369);
            choice.GetComponentInChildren<TextMeshProUGUI>().text = c.Description;
            
            choice.GetComponent<Button>().onClick.AddListener((() => c.process()));
            
            startPos += btnPadding + (btnWidth);

        }

    }

    public void CloseEvents()
    {
        
        Destroy(gameObject);
        
    }
}
