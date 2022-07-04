using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PName;
    public void StartGame(int sceneIndex)
    {
        Time.timeScale = 1;
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
