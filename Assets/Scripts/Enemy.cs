using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Transform player;
    private Rigidbody _rb;
    private float randomDirectionTimer = 3f;
    private float nextChange = 0f;
    private Vector3 defaultDirection = Vector3.zero;

    private void Start()
    {
        player = FindObjectOfType<Player>()?.transform;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        FollowTarget(player);
    }

    private void FollowTarget(Transform target)
    {
        if (target)
        {
            var direction = target.position - transform.position;

            _rb.AddForce(direction.normalized * Time.deltaTime * moveSpeed * _rb.mass, ForceMode.Impulse);
        }
        else
        {
            if (Time.time > nextChange)
            {
                defaultDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                nextChange = Time.time + randomDirectionTimer;
            }
            _rb.AddForce(defaultDirection.normalized * Time.deltaTime * moveSpeed * _rb.mass, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        moveSpeed = 5f;
        _rb.useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        moveSpeed = 10f;
        _rb.useGravity = true;
    }
}
