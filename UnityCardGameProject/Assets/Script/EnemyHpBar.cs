using UnityEngine;
using UnityEngine.UI; // Image 컴포넌트 제어용

public class EnemyHpBar : MonoBehaviour
{
    [Header("게이지 바 이미지 UI")]
    public Image EnemyHpBarImage; // 적의 HP 막대 이미지 연결

    [Header("실제 데이터 (현재값 / 최대값)")]
    public int CurrantEnemyHp = 100;
    public int MaxEnemyHp = 100;

    [Header("연출 속도")]
    [SerializeField] private float decreaseSpeed = 40f; // 줄어드는 속도

    // 화면 연출용 내부 변수 (소수점 연산용)
    private float displayHp;

    void Start()
    {
        // 시작할 때 실제 값으로 초기화
        displayHp = CurrantEnemyHp;
        UpdateHpBar();
    }

    void Update()
    {
        // 내부 연출용 float 값을 실제 데이터 값을 향해 부드럽게 이동시킵니다.
        if (!Mathf.Approximately(displayHp, CurrantEnemyHp))
        {
            displayHp = Mathf.MoveTowards(displayHp, CurrantEnemyHp, decreaseSpeed * Time.deltaTime);

            // 값이 변할 때만 HP 바를 갱신합니다.
            UpdateHpBar();
        }
    }

    // HP 바 이미지 갱신 함수
    void UpdateHpBar()
    {
        if (MaxEnemyHp > 0 && EnemyHpBarImage != null)
        {
            // 0.0 ~ 1.0 비율로 fillAmount 조절
            EnemyHpBarImage.fillAmount = displayHp / MaxEnemyHp;
        }
    }
}