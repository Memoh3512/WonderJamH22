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
    public float xOffset = 50f;
    
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

    public void DeleteButtons()
    {
        
        //update choices
        foreach (Button b in transform.GetComponentsInChildren<Button>())
        {
            
            Destroy(b.gameObject);
            
        }
        
    }

    private void UpdateUI()
    {

        //update text

        DeleteButtons();
        
        if (choicePrefab == null || currentCard == null) return;
        
        currentCard.checkIfChoiceBuyable();
        
        title.text = currentCard.Name;
        desc.text = currentCard.Description;

        int nb = currentCard.getNbChoices;
        float width = GetComponent<RectTransform>().sizeDelta.x * 0.65f;

        if (nb <= 0) return;

        float btnWidth = width - ((nb - 1) * btnPadding);
        btnWidth /= (float)nb;

        float startPos = -(width / 2f) + btnWidth / 2f;
        startPos += xOffset;
        
        foreach (Choice c in currentCard.getChoices)
        {

            GameObject choice = Instantiate(choicePrefab, transform);
            choice.GetComponent<RectTransform>().sizeDelta = new Vector2(btnWidth, choice.GetComponent<RectTransform>().sizeDelta.y);
            choice.GetComponent<RectTransform>().localPosition = new Vector3(startPos, -400);
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
