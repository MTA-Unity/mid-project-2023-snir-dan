using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    private readonly float _smallestBallSize = 1f;

    private readonly Vector2 _splitForce = new Vector2(4f, 4f);

    [SerializeField] private Vector2 _startForce;
    [SerializeField] private Rigidbody2D _ballRigidbody;
    public float BallSize { get { return transform.localScale.x; } }

    void Start()
    {
        _ballRigidbody.AddForce(_startForce, ForceMode2D.Impulse);
    }

    public void Split()
    {
        if (BallSize > _smallestBallSize)
        {
            var rightBall = Instantiate(_ballPrefab, _ballRigidbody.position + Vector2.right / 4f, Quaternion.identity);
            var leftBall = Instantiate(_ballPrefab, _ballRigidbody.position + Vector2.left / 4f, Quaternion.identity);

            rightBall.transform.localScale = new Vector3(BallSize - 1, BallSize - 1, 1f);
            leftBall.transform.localScale = new Vector3(BallSize - 1, BallSize - 1, 1f);
            
            rightBall.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            leftBall.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;

            rightBall.GetComponent<BallController>().SetStartForce(_splitForce);
            leftBall.GetComponent<BallController>().SetStartForce(_splitForce * new Vector2(-1, 1));

        }

        Destroy(gameObject);
    }

    public void SetStartForce(Vector2 force)
    {
        _startForce = force;
    }
}
