using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI PName;
    public void StartGame(int sceneIndex)
    {
        PlayerName.Instance.PName = PName.text;
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        {
            EditorApplication.ExitPlaymode();
        };
#else
            Application.Quit();
#endif
    }
}
