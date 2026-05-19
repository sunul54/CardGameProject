using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public GameManager gameManager;
    public EnemyHpBar enemyHpBar;
    public PlayerStateUIManager playerStateUIManager;

    public GameObject buttonUI;
    public GameObject InfoTextUI;
    public TextMeshProUGUI infoText;

    [Header("타자기 속도")]
    [SerializeField] private float typingSpeed = 0.05f;

    [Header("이동할 씬 이름")]
    [SerializeField] private string nextSceneName = "MainGame";
    [SerializeField] private string gameOverSceneName = "TitleScene";

    void Start()
    {
        if (InfoTextUI != null) InfoTextUI.SetActive(false);
        if (buttonUI != null) buttonUI.SetActive(true);
    }

    public void PlayerAttack()
    {
        buttonUI.SetActive(false);
        InfoTextUI.SetActive(true);

        StartCoroutine(AttackSequenceRoutine());
    }

    IEnumerator AttackSequenceRoutine()
    {
        // ========================================================
        // 1. 플레이어의 공격 턴 (랜덤 데미지 적용)
        // ========================================================
        yield return StartCoroutine(TypeText("플레이어의 공격!"));
        yield return new WaitForSeconds(1.2f);

        // ⭐ 10부터 20까지 랜덤한 플레이어 데미지 계산 (정수형은 max 직전까지라 21로 설정)
        int playerDamage = Random.Range(10, 21);

        // 뽑힌 랜덤 데미지만큼 적 체력 차감
        enemyHpBar.CurrantEnemyHp -= playerDamage;

        if (enemyHpBar.CurrantEnemyHp < 0)
        {
            enemyHpBar.CurrantEnemyHp = 0;
        }

        // 실시간으로 바뀐 랜덤 데미지 숫자를 대사창에 반영
        string damageMessage = playerDamage + "의 피해를 주었다.";
        yield return StartCoroutine(TypeText(damageMessage));
        yield return new WaitForSeconds(1.5f);

        // [체력 조건 검사] 적이 죽었는지 확인
        if (enemyHpBar.CurrantEnemyHp <= 0)
        {
            yield return StartCoroutine(VictorySequenceRoutine());
            yield break;
        }

        // ========================================================
        // 2. 적(상대)의 공격 턴
        // ========================================================
        yield return StartCoroutine(TypeText("적의 턴입니다..."));
        yield return new WaitForSeconds(1.2f);

        yield return StartCoroutine(TypeText("적이 공격해왔다!"));
        yield return new WaitForSeconds(1.2f);

        // 적은 기존대로 5 ~ 20 랜덤 데미지
        int enemyDamage = Random.Range(5, 21);

        playerStateUIManager.CurrantPlayerHp -= enemyDamage;

        if (playerStateUIManager.CurrantPlayerHp < 0)
        {
            playerStateUIManager.CurrantPlayerHp = 0;
        }

        string enemyDamageMessage = "플레이어는 " + enemyDamage + "의 피해를 입었다.";
        yield return StartCoroutine(TypeText(enemyDamageMessage));
        yield return new WaitForSeconds(1.5f);

        // [체력 조건 검사] 플레이어가 죽었는지 확인
        if (playerStateUIManager.CurrantPlayerHp <= 0)
        {
            yield return StartCoroutine(GameOverSequenceRoutine());
            yield break;
        }

        // ========================================================
        // 3. 다시 플레이어 선택 턴으로 복구
        // ========================================================
        InfoTextUI.SetActive(false);
        buttonUI.SetActive(true);
    }

    IEnumerator VictorySequenceRoutine()
    {
        yield return StartCoroutine(TypeText("상대가 쓰러졌다!"));
        yield return new WaitForSeconds(1.5f);

        yield return StartCoroutine(TypeText("승리했다!"));
        yield return new WaitForSeconds(2.0f);

        Debug.Log(nextSceneName + " 씬으로 이동합니다.");
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator GameOverSequenceRoutine()
    {
        yield return StartCoroutine(TypeText("플레이어가 쓰러졌다..."));
        yield return new WaitForSeconds(1.5f);

        yield return StartCoroutine(TypeText("전투에서 패배했습니다."));
        yield return new WaitForSeconds(2.0f);

        Debug.Log(gameOverSceneName + " 씬으로 이동합니다.");
        SceneManager.LoadScene(gameOverSceneName);
    }

    IEnumerator TypeText(string message)
    {
        infoText.text = "";

        foreach (char letter in message.ToCharArray())
        {
            infoText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}