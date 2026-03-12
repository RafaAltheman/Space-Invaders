using UnityEngine;

public class PlayerControls1 : MonoBehaviour
{
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;
    public float speed = 8f;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;
    private float halfWidth;
    private float moveInput;
    private bool morreu = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        halfWidth = GetComponent<Collider2D>().bounds.extents.x;
    }

    void Update()
    {
        if (morreu) return;

        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        if (morreu) return;

        float minX = leftWall.bounds.max.x + halfWidth;
        float maxX = rightWall.bounds.min.x - halfWidth;

        float newX = rb.position.x + moveInput * speed * Time.fixedDeltaTime;
        newX = Mathf.Clamp(newX, minX, maxX);

        rb.MovePosition(new Vector2(newX, rb.position.y));
    }

    void Shoot()
    {
        if (bulletPrefab == null) return;

        Vector3 spawnPos = transform.position + new Vector3(0f, 0.8f, 0f);
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }

    public void Morrer()
    {
        if (morreu) return;
        morreu = true;

        if (GameManager.instance != null)
        {
            GameManager.instance.PerderVida();
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TiroInimigo") || other.CompareTag("TiroNaveMae"))
        {
            Destroy(other.gameObject);
            Morrer();
            return;
        }

        if (other.CompareTag("Inimigo"))
        {
            Morrer();
            return;
        }
    }
}