using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    public enum SceneName
    {
        MainMenu,
        Game,
    }

    private static SceneController _instance;

    // Singleton
    public static SceneController instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = new SceneController();
            return _instance;
        }
    }

    public void LoadScene(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public string GetSceneName()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        Debug.Log(currentSceneName);

        return currentSceneName;
    }
}