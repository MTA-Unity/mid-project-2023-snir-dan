using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    private readonly float _smallestBallSize = 1f;
    private readonly Vector2 _splitForce = new Vector2(4f, 4f);
    [SerializeField] private Vector2 _startForce;
    [SerializeField] private Rigidbody2D _ballRigidbody;
    public int ScoreValue { get; private set; } = 10;

    void Start()
    {
        GameManager.Instance.OnBallSpawned();
        _ballRigidbody.AddForce(_startForce, ForceMode2D.Impulse);
    }

    void OnDestroy()
    {
        GameManager.Instance.OnBallDestroyed();
    }

    public void Pop()
    {
        float ballSize = transform.localScale.x;
        if (ballSize > _smallestBallSize)
        {
            GameObject rightBall = Instantiate(_ballPrefab, _ballRigidbody.position + Vector2.right / 4f, Quaternion.identity);
            GameObject leftBall = Instantiate(_ballPrefab, _ballRigidbody.position + Vector2.left / 4f, Quaternion.identity);

            Vector3 childScale = new Vector3(ballSize - 1, ballSize - 1, 1f);
            rightBall.transform.localScale = childScale;
            leftBall.transform.localScale = childScale;
            
            Color ballColor = GetComponent<SpriteRenderer>().color;
            rightBall.GetComponent<SpriteRenderer>().color = ballColor;
            leftBall.GetComponent<SpriteRenderer>().color = ballColor;

            rightBall.GetComponent<BallController>()._startForce = _splitForce;
            leftBall.GetComponent<BallController>()._startForce = _splitForce * new Vector2(-1, 1);
        }

        Destroy(gameObject);
    }
}
