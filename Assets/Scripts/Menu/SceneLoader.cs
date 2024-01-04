using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        if (PlayerPrefs.GetFloat("Volume") == 0)
        {
            AudioListener.volume = 0.5f;
            PlayerPrefs.SetFloat("Volume", 0.5f);
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void LoadGameScene(string sceneName)
    {
        if (sceneName == "QUIT")
        {
            Application.Quit();
        }
        else
        {
            loadingText.text = "Loading...";
            SceneManager.LoadScene(sceneName);
        }
    }
}
