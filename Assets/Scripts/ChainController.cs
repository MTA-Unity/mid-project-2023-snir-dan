using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _chainSpeed = 2f;
    public static bool IsFired;
    // Start is called before the first frame update
    void Start()
    {
        IsFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            IsFired = true;
        }

        if (IsFired)
        {
            transform.localScale += Vector3.up * (Time.deltaTime * _chainSpeed);
        }
        else
        {
            transform.position = _playerTransform.position - new Vector3(0f, _playerTransform.localScale.y / 2, 0f);
            transform.localScale = new Vector3(1f, 0f, 1f);
        }
    }
}
