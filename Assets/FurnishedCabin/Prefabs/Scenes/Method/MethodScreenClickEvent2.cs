using UnityEngine;
using UnityEngine.SceneManagement;

public class MethodScreenClickEvent2 : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Notebook Clicked!"); // Ŭ�� �̺�Ʈ �߻� Ȯ�ο� �α�

        // ȭ�� ��ȯ �Ǵ� �ٸ� ������ ���⿡ ����
        // ���� ���, �ٸ� Scene���� ��ȯ�ϴ� ���:
        SceneManager.LoadScene("presub"); // "YourSceneName"�� ��ȯ�� Scene�� �̸����� �����ؾ� �մϴ�.
    }
}