using UnityEngine;

public class PlayerRacket : Racket
{

    protected override void Movement()
    {
        float moveAxesValue = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(0, moveAxesValue);
    }
}