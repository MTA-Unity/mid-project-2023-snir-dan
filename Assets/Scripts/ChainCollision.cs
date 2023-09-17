using UnityEngine;

public class ChainCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ChainController.IsFired = false;

        if (other.CompareTag("Ball"))
        {
            other.GetComponent<BallController>().Split();
        }
        
        // if (other.tag.Contains("Ball") && !_isColliding)
        // {
        //     Debug.Log("A ball has been hit");
        //     _isColliding = true;
        //     ScoreManager.Instance.AddBallHitScore(other.tag);

        //     // Check for winning condition - One ball in scene without nextBall
        //     var ball = other.GetComponent<Ball>();
        //     bool hasWon = GameManager.Instance.HasWonLevel(ball.HasNextBall());
            
        //     ball.Split();
        //     if (hasWon)
        //     {
        //         GameManager.Instance.ClearLevelWon();
        //     }
        // }
    }
}
