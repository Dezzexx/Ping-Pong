using System.Collections;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedMultiplier;
    [SerializeField] float maxSpeed;

    private int hit;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Preparation());
    }

    IEnumerator Preparation()
    {
        hit = 0;
        yield return new WaitForSeconds(2);

        MoveLogic(RandomDirection());
    }

    Vector2 RandomDirection()
    {
        var direction = Random.Range(Random.Range(-1,-0.1f), Random.Range(0.1f,1));
        return new Vector2(direction, 0);
    }

    void MoveLogic(Vector2 direction)
    {
        direction = direction.normalized;

        var ballSpeed = speed + speedMultiplier * hit;
        rb.velocity = ballSpeed * direction;
    }

    void HitCounter()
    {
        var speedUp = speedMultiplier * hit;
        if (speedUp < maxSpeed)
        {
            hit++;
        }
    }
}
