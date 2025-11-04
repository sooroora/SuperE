
using UnityEngine.SceneManagement;

public static class SceneTransferManager
{
    public static void LoadScene(ESceneName sceneName)
    {
        PlayerPrefsManager.SetStringValue(ESceneTransferData.SceneName, nameof(ESceneName.GameScene));
        SceneManager.LoadScene("LoadingScene");
    }
    
}
