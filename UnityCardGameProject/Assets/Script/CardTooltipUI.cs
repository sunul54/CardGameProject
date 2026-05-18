using TMPro;
using UnityEngine;

public class CardTooltipUI : MonoBehaviour
{
    public GameObject tooltipPanel;

    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI cardDescText;

    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void Show(CardData cardData)
    {
        tooltipPanel.SetActive(true);

        cardNameText.text = cardData.CardName;
        cardDescText.text = cardData.CardDesc;
    }

    public void Hide()
    {
        tooltipPanel.SetActive(false);
    }
}