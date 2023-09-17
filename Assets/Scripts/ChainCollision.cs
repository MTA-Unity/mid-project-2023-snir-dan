using UnityEngine;

public class ChainCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ChainController.IsFired = false;

        if (other.CompareTag("Ball"))
        {
            BallController ballController = other.GetComponent<BallController>();
            ballController.Pop();
            GameManager.Instance.AddScore(ballController.ScoreValue);
        }
    }
}
