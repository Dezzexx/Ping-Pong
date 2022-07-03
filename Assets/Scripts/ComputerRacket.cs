using UnityEngine;

public class ComputerRacket : Racket
{
    [SerializeField] Transform ball;
    protected override void Movement()
    {
        float distance = Mathf.Abs(ball.position.y - transform.position.y);
        if (distance > 1)
        {
            if (ball.position.y > transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * moveSpeed;
            }

            if (ball.position.y < transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * moveSpeed;
            }
        }
    }
}