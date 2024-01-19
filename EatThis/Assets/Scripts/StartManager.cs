using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void StartStory() {
        SceneManager.LoadScene("StoryScene");
    }
    public void StartGame() {
        PlayerPrefs.SetInt("isMultimode", 0);
        SceneManager.LoadScene("MainScene");
    }
    public void StartmultiGame() {
        PlayerPrefs.SetInt("isMultimode", 1);
        SceneManager.LoadScene("NetworkScene");
    }
}
