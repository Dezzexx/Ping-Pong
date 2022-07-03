using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;
using System.ComponentModel;

public class MainManager : MonoBehaviour
{
    public Text BestScoreText;
    public Text LeftScoreText;

    private void Start()
    {
        BestScoreText.text = $"BestScore({BestScore.Instance.BestScoreName}): {BestScore.Instance.Score.text}";
    }

    private void Update()
    {
        BestScoreText.text = $"BestScore({BestScore.Instance.BestScoreName}): {BestScore.Instance.Score.text}";
    }

    public void BackToMenu(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
