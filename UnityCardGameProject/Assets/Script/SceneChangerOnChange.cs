using UnityEngine;
using UnityEngine.SceneManagement; // 씬 이동을 위해 필수!

public class SceneChangerOnChange : MonoBehaviour
{
    [Header("클릭 시 이동할 씬 이름")]
    [SerializeField] private string nextSceneName = "Main"; // 이동할 씬의 정확한 이름

    void Update()
    {
        // 마우스 왼쪽 버튼을 누르거나, 모바일 화면을 터치했을 때 전체 감지
        if (Input.GetMouseButtonDown(0))
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        Debug.Log(nextSceneName + " 씬으로 이동합니다.");

        // 지정한 이름의 씬을 로드합니다.
        SceneManager.LoadScene(nextSceneName);
    }
}