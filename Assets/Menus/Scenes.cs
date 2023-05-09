using UnityEngine.SceneManagement;

public static class Scenes
{
    /// <summary>
    /// A Static way to change scenes
    /// </summary>
    
    public static void GoToScene(int Nr)
    {
        // TODO change scene effect, loading screen if needed
        SceneManager.LoadScene(Nr);
    }
}
