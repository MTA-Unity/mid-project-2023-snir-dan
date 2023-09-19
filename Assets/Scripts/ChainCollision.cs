using UnityEngine;

public class ChainCollision : MonoBehaviour
{
    private bool _inCollision;
    void OnTriggerEnter2D(Collider2D other)
    {
        ChainController.IsFired = false;

        if (other.CompareTag("Ball") && !_inCollision)
        {
            _inCollision = true;
            BallController ballController = other.GetComponent<BallController>();
            ballController.Pop();
            GameManager.Instance.AddScore(ballController.ScoreValue);
        }
    }

    void Update()
    {
        _inCollision = false;
    }
}
