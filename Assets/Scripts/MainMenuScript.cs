using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public async void PlayGame()
    {
        await SceneManager.LoadSceneAsync(0);
    }
}