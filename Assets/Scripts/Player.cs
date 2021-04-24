using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float deathTimer;
    [SerializeField]
    private GameObject blowPrefab;
    [SerializeField]
    private float blowCoolDown;

    private Rigidbody _rb;
    private int playerSpeed;
    private float localTimer;
    private float coolDownTimer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        localTimer = deathTimer;
        coolDownTimer = 0f;
        PlayerPrefs.SetFloat("deathTimer", deathTimer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && coolDownTimer <= 0f)
        {
            BlowSkill();
            coolDownTimer = blowCoolDown;
        }
        if (coolDownTimer > 0f) coolDownTimer -= Time.deltaTime;
        playerSpeed = (int)_rb.velocity.magnitude;
        UIController.instance.SetCoolDownText(((int)coolDownTimer).ToString());
        UIController.instance.SetSpeedText(playerSpeed.ToString());
        UIController.instance.SetLifeTimeText(((int)localTimer).ToString());
        if (playerSpeed <= 0)
        {
            localTimer -= Time.deltaTime;
            if (localTimer <= 0f)
            {
                UIController.instance.ActivateDeathPanel();
                Destroy(gameObject);
            }
        }
        else
        {
            localTimer = deathTimer;
        } 
    }

    private void BlowSkill()
    {
        Instantiate(blowPrefab, transform.position, Quaternion.identity);
    }

    private void Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var direction = (Vector3.right * x + Vector3.forward * z) * Time.deltaTime * moveSpeed * _rb.mass;

        _rb.AddForce(direction, ForceMode.Impulse);
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
