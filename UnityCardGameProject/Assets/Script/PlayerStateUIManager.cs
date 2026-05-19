using UnityEngine;
using UnityEngine.UI; // Image 컴포넌트를 제어하기 위해 추가
using TMPro;

public class PlayerStateUIManager : MonoBehaviour
{
    public GameManager gameManager;

    [Header("텍스트 UI")]
    public TextMeshProUGUI PlayerHpText;
    public TextMeshProUGUI PlayerSpText;

    [Header("게이지 바 이미지 UI")]
    public Image PlayerHpBarImage; // HP 막대 이미지 연결
    public Image PlayerSpBarImage; // SP 막대 이미지 연결

    [Header("실제 데이터 (현재값 / 최대값)")]
    public int CurrantPlayerHp = 50;
    public int MaxPlayerHp = 50;
    public int CurrantPlayerSp = 50;
    public int MaxPlayerSp = 50;

    [Header("연출 속도")]
    [SerializeField] private float decreaseSpeed = 20f; // 초당 줄어드는 속도

    // 화면 연출용 내부 변수 (소수점 연산용)
    private float displayHp;
    private float displaySp;

    void Start()
    {
        // 시작할 때 실제 값으로 초기화
        displayHp = CurrantPlayerHp;
        displaySp = CurrantPlayerSp;

        UpdateUiTextAndBars();
    }

    void Update()
    {
        // 1. HP 부드럽게 이동
        if (!Mathf.Approximately(displayHp, CurrantPlayerHp))
        {
            displayHp = Mathf.MoveTowards(displayHp, CurrantPlayerHp, decreaseSpeed * Time.deltaTime);
        }

        // 2. SP 부드럽게 이동
        if (!Mathf.Approximately(displaySp, CurrantPlayerSp))
        {
            displaySp = Mathf.MoveTowards(displaySp, CurrantPlayerSp, decreaseSpeed * Time.deltaTime);
        }

        // 3. UI 텍스트 및 게이지 바 동시 갱신
        UpdateUiTextAndBars();
    }

    // UI 전체를 갱신하는 함수
    void UpdateUiTextAndBars()
    {
        // --- 텍스트 UI 업데이트 (올림 처리하여 정수로 표시) ---
        int hpToDisplay = Mathf.CeilToInt(displayHp);
        int spToDisplay = Mathf.CeilToInt(displaySp);

        if (PlayerHpText != null) PlayerHpText.text = $"{hpToDisplay} / {MaxPlayerHp}";
        if (PlayerSpText != null) PlayerSpText.text = $"{spToDisplay} / {MaxPlayerSp}";

        // --- 게이지 바 이미지 업데이트 (0.0 ~ 1.0 비율 연산) ---
        // 최대값이 0이 되어 나누기 오류(NaN)가 나는 것을 방지합니다.
        if (MaxPlayerHp > 0 && PlayerHpBarImage != null)
        {
            // 부드럽게 변하고 있는 displayHp를 최대값으로 나눈 비율을 fillAmount에 넣습니다.
            PlayerHpBarImage.fillAmount = displayHp / MaxPlayerHp;
        }

        if (MaxPlayerSp > 0 && PlayerSpBarImage != null)
        {
            PlayerSpBarImage.fillAmount = displaySp / MaxPlayerSp;
        }
    }
}