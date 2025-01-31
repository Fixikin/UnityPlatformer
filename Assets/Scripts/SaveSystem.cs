using UnityEngine;

public static class SaveSystem
{
    private const string LAST_LEVEL_KEY = "LastLevel";

    // Сохраняем текущий уровень
    public static void SaveLevel(int levelIndex)
    {
        PlayerPrefs.SetInt(LAST_LEVEL_KEY, levelIndex);
        PlayerPrefs.Save(); // Сохраняем изменения
    }

    // Загружаем последний сохранённый уровень
    public static int LoadLevel()
    {
        return PlayerPrefs.GetInt(LAST_LEVEL_KEY, 1); // 1 — уровень по умолчанию
    }
}