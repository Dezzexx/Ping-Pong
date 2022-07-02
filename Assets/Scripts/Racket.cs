using UnityEngine;
using UnityEngine.UI;

public abstract class Racket : MonoBehaviour
{
    public int Score { get; private set; }

    public Rigidbody2D rb;
    public float moveSpeed;
    public Text scoreText;

    void FixedUpdate() => Movement();

    protected abstract void Movement();

    public void GetScore()
    {
        Score++;
        scoreText.text = Score.ToString();
    }

}