using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public void StartGame(int sceneIndex) => SceneManager.LoadScene(sceneIndex);

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

    public void BackToMenu(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
