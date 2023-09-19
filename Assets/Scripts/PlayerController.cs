using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 20f;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    private float _movement;

    void Update()
    {
        _movement = Input.GetAxisRaw("Horizontal") * _movementSpeed;
    }

    private void FixedUpdate()
    {
        _playerRigidbody.MovePosition(_playerRigidbody.position + new Vector2(_movement * Time.fixedDeltaTime, 0f));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.LoseLife();
        }
    }
}
