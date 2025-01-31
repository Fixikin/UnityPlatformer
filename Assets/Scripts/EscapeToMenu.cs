using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; // ��� ����� �������� ����

    void Update()
    {
        // ���������, ������ �� ������� Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

    public void ReturnToMainMenu()
    {
        // ��������� ����� �������� ����
        SceneManager.LoadScene(mainMenuSceneName);
    }
}