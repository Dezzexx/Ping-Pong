using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField] Text BestScoreText;
    [SerializeField] Text LeftScoreText;
    [SerializeField] Text RightScoreText;
    [SerializeField] Image GameOverImage;

    [SerializeField] string endGameScore;
    
    private bool gameOver = true;

    private void Start()
    {
        if (!gameOver)
        {
            GameOverImage.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        AddInfoToScore();

        if (RightScoreText.text == endGameScore)
        {
            GameOver();
        }
    }

    void AddInfoToScore()
    {
        var currentScore = int.Parse(LeftScoreText.text);
        var bestScore = BestScore.Instance.Score;

        if(currentScore > bestScore)
        {
            BestScore.Instance.Score = currentScore;
            BestScore.Instance.BestScoreName = PlayerName.Instance.PName;
            BestScoreText.text = $"BestScore({BestScore.Instance.BestScoreName}): {BestScore.Instance.Score}";
        }

        BestScoreText.text = $"Best Score({BestScore.Instance.BestScoreName}): {BestScore.Instance.Score}";
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
        GameOverImage.gameObject.SetActive(true);
        BestScore.Instance.SaveScore();
    }

    public void BackToMenu(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
