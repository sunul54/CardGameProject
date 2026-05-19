using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 필수

public class ObjectClickDetector2D : MonoBehaviour
{
    public GameManager gameManager;
    public CardSelectManagement cardSelectManagement;
    // CardSlot cardSlot; // 사용하지 않는 변수라면 주석 처리하거나 삭제 가능합니다.

    [Header("Scene Settings")]
    [Tooltip("이동할 메인 게임 씬의 정확한 이름을 입력하세요.")]
    public string mainGameSceneName;

    [Tooltip("SceneChange 태그 클릭 시 이동할 씬 이름을 입력하세요.")]
    public string loadSceneName;

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
                // 1. 시작 버튼
                if (hit.collider.CompareTag("Start"))
                {
                    if (!string.IsNullOrEmpty(mainGameSceneName))
                    {
                        SceneManager.LoadScene(mainGameSceneName);
                    }
                    else
                    {
                        Debug.LogError("Main Game Scene Name이 설정되지 않았습니다!");
                    }
                }
                // 2. 정지 버튼
                else if (hit.collider.CompareTag("GameStop"))
                {
                    Application.Quit();
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false; // 에디터에서도 멈추게 설정
#endif
                }
                // 3. 카드 슬롯
                else if (hit.collider.CompareTag("CardSlot"))
                {
                    CardSlot hitCardSlot = hit.collider.gameObject.GetComponent<CardSlot>();

                    if (cardSelectManagement.isCardSelected) // 이미 카드가 선택되어 있다면
                    {
                        int temp = hitCardSlot.cardSlotNum;
                        if (temp == cardSelectManagement.SelectedCardNum) // 같은 카드 클릭 시 선택 해제
                        {
                            cardSelectManagement.isCardSelected = false;
                            cardSelectManagement.SelectedCardNum = 6; // 기본값으로 초기화
                        }
                        else // 다른 카드 클릭 시 선택 변경
                        {
                            cardSelectManagement.SelectedCardNum = temp;
                            cardSelectManagement.isCardSelected = true;
                        }
                    }
                    else // 카드가 선택되어 있지 않다면 새로 선택
                    {
                        cardSelectManagement.SelectedCardNum = hitCardSlot.cardSlotNum;
                        cardSelectManagement.isCardSelected = true;
                    }
                }
                // 4. 카드 선택 확정 버튼
                else if (hit.collider.CompareTag("CardSelectButton"))
                {
                    if (cardSelectManagement.isCardSelected)
                    {
                        int selectedIndex = cardSelectManagement.SelectedCardNum;

                        CardData selectedCard = cardSelectManagement.CardSlot[selectedIndex]
                            .GetComponent<CardSlot>()
                            .currentCard;

                        gameManager.selectedCard = selectedCard;

                        Debug.Log("최종 선택 카드 : " + gameManager.selectedCard.CardName);

                        cardSelectManagement.CardSelectPanelActive = true;
                    }
                }
                // 5. 일반 씬 전환 버튼
                else if (hit.collider.CompareTag("SceneChange"))
                {
                    if (!string.IsNullOrEmpty(loadSceneName))
                    {
                        SceneManager.LoadScene(loadSceneName);
                    }
                }
            }
        }
    }
}