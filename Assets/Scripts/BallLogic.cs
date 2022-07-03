using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallLogic : MonoBehaviour
{
    [SerializeField] Racket LeftRacket, RightRacket;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] Text prepareTimerText;

    void Start()
    {
        StartCoroutine(Prepare(1));
    }

    IEnumerator Prepare(int timeInSec)
    {
        PrepareTimerToText(3);
        yield return new WaitForSeconds(timeInSec);
        PrepareTimerToText(2);
        yield return new WaitForSeconds(timeInSec);
        PrepareTimerToText(1);
        yield return new WaitForSeconds(timeInSec);
        prepareTimerText.gameObject.SetActive(false);

        rb.velocity = new Vector2(-1, 1) * speed;
    }

    void PrepareTimerToText(int count)
    {
        var Text = "Prepare: " + count;
        prepareTimerText.text = Text.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TagManager tagManager = collision.gameObject.GetComponent<TagManager>();

        if (tagManager == null)
        {
            return;
        }

        Tag tag = tagManager.wallTag;

        if (tag.Equals(Tag.leftWall))
        {
            RightRacket.GetScore();
        }
        if (tag.Equals(Tag.rightWall))
        {
            LeftRacket.GetScore();
        }
        if (tag.Equals(Tag.leftRacket))
        {
            BallBounceDirection(collision, 1);
        }
        if (tag.Equals(Tag.rightRacket))
        {
            BallBounceDirection(collision, -1);
        }
    }

    private void BallBounceDirection(Collision2D collision, int x)
    {
        float yBallPosition = transform.position.y;
        float yRacketPosition = collision.gameObject.transform.position.y;
        float racketHight = collision.collider.bounds.size.y;
        float y = (yBallPosition - yRacketPosition) / racketHight;
        
        rb.velocity = new Vector2(x, y) * speed;
    }
}
