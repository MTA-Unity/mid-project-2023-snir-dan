using UnityEngine;

public class ChainController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _chainSpeed = 2f;
    public static bool IsFired;

    void Start()
    {
        IsFired = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
