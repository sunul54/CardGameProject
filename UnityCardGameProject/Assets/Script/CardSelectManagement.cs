using UnityEngine;

public class CardSelectManagement : MonoBehaviour
{
    public bool CardSelectPanelActive = true;
    public bool isCardSelected = false;

    public GameObject cardSelectPanel;
    public GameObject CardSelectButton;

    public int SelectedCardNum;

    public GameObject[] CardSlot = new GameObject[5];

    void Start()
    {
        isCardSelected = false;
    }

    void Update()
    {
        if (CardSelectPanelActive == true)
        {
            cardSelectPanel.SetActive(false);
        }

        // 버튼 투명도 조절
        SpriteRenderer buttonSr = CardSelectButton.GetComponent<SpriteRenderer>();

        Color buttonColor = buttonSr.color;

        if (isCardSelected)
        {
            buttonColor.a = 1f;
        }
        else
        {
            buttonColor.a = 0.5f;
        }

        buttonSr.color = buttonColor;

        // 카드 선택 상태
        if (isCardSelected == true)
        {
            Debug.Log("선택된 카드 : " + SelectedCardNum);

            for (int i = 0; i < 5; i++)
            {
                SpriteRenderer sr = CardSlot[i].GetComponent<SpriteRenderer>();

                Color color = sr.color;

                if (i != SelectedCardNum)
                {
                    color.a = 0.5f;
                }
                else
                {
                    color.a = 1f;
                }

                sr.color = color;
            }
        }
        else
        {
            Debug.Log("카드 선택 해제");

            for (int i = 0; i < 5; i++)
            {
                SpriteRenderer sr = CardSlot[i].GetComponent<SpriteRenderer>();

                Color color = sr.color;
                color.a = 1f;

                sr.color = color;
            }
        }
    }
}