using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenClickEvent : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Screen Clicked!"); // Ŭ�� �̺�Ʈ �߻� Ȯ�ο� �α�

        // ȭ�� ��ȯ �Ǵ� �ٸ� ������ ���⿡ ����
        // ���� ���, �ٸ� Scene���� ��ȯ�ϴ� ���:
        SceneManager.LoadScene("Method"); // "YourSceneName"�� ��ȯ�� Scene�� �̸����� �����ؾ� �մϴ�.
    }
}
