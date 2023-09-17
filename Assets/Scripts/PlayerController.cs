using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 20f;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    private float _movement;

    // Update is called once per frame
    void Update()
    {
        _movement = Input.GetAxisRaw("Horizontal") * _movementSpeed;
    }

    private void FixedUpdate()
    {
        _playerRigidbody.MovePosition(_playerRigidbody.position + new Vector2(_movement * Time.fixedDeltaTime, 0f));
    }
}
