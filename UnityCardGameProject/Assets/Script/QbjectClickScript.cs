using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectClickDetector2D : MonoBehaviour
{
    public CardSelectManagement cardSelectManagement;
    CardSlot cardSlot;
    public SceneAsset MainGame;

    void Update()
    {
        // 마우스 왼쪽 클릭
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치를 월드 좌표로 변환
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Raycast 실행
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // 오브젝트 감지
            if (hit.collider != null)
            {
                Debug.Log("클릭한 오브젝트 : " + hit.collider.gameObject.name);

                // 태그 확인
                //시작 버튼
                if (hit.collider.CompareTag("Start"))
                {
                    SceneManager.LoadScene(MainGame.name);
                }else if (hit.collider.CompareTag("GameStop")) // 정지 버튼
                {
                    Application.Quit();
                }else if(hit.collider.CompareTag("CardSlot")) //카드 슬롯
                {
                    if(cardSelectManagement.isCardSelected == true) //이미 카드가 선택되어 있다면
                    {
                        int temp = hit.collider.gameObject.GetComponent<CardSlot>().cardSlotNum; //선택된 카드 번호 임시 저장
                        if(temp == cardSelectManagement.SelectedCardNum) //선택된 카드 번호와 클릭한 카드 번호가 같다면
                        {
                            Debug.Log("같은 카드 선택");
                            cardSelectManagement.isCardSelected = false;
                            cardSelectManagement.SelectedCardNum = 6;
                        }
                        else //선택된 카드 번호와 클릭한 카드 번호가 다르다면
                        {
                            cardSelectManagement.SelectedCardNum = hit.collider.gameObject.GetComponent<CardSlot>().cardSlotNum; //카드 선택
                            cardSelectManagement.isCardSelected = true;
                        }
                            

                    }
                    else //카드가 선택되어 있지 않다면
                    {
                        cardSelectManagement.SelectedCardNum = hit.collider.gameObject.GetComponent<CardSlot>().cardSlotNum; //카드 선택
                        cardSelectManagement.isCardSelected = true;
                    }

                   


                }else if(hit.collider.CompareTag("CardSelectButton"))//카드 최종 선택 버튼
                {
                    if(cardSelectManagement.isCardSelected == true) //카드가 선택되어 있다면
                    {
                        cardSelectManagement.CardSelectPanelActive = true; //카드 선택 패널 비활성화
                    }
                }
            }
        }
    }
}