using UnityEngine;
using UnityEngine.SceneManagement;

public class MethodScreenClickEvent : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Notebook Clicked!"); // Ŭ�� �̺�Ʈ �߻� Ȯ�ο� �α�

        // ȭ�� ��ȯ �Ǵ� �ٸ� ������ ���⿡ ����
        // ���� ���, �ٸ� Scene���� ��ȯ�ϴ� ���:
        SceneManager.LoadScene("Method 1"); // "YourSceneName"�� ��ȯ�� Scene�� �̸����� �����ؾ� �մϴ�.
    }
}