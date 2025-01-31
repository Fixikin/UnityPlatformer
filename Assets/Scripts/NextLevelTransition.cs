using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string nextLevelName;

    //когда ГГ сталкивается с дверью - загружается следующая сцена (уровень)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SaveSystem.SaveLevel(GetLevelIndex(nextLevelName));
            SceneManager.LoadScene(nextLevelName);
        }
    }

    private int GetLevelIndex(string levelName)
    {
        if (levelName.StartsWith("Level"))
        {
            string number = levelName.Replace("Level", "");
            return int.Parse(number);
        }
        return 1;
    }
}
