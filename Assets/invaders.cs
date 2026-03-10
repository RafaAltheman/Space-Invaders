using UnityEngine;

public class invaders : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    public float waitTime = 1.0f;
    public float speed = 2.0f;

    public float dropAmount = 0.5f;
    private int changeCount = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Vector2 vel = rb2d.linearVelocity;
        vel.x = speed;
        rb2d.linearVelocity = vel;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
        }
    }

    void ChangeState()
    {
        Vector2 vel = rb2d.linearVelocity;
        vel.x *= -1;
        rb2d.linearVelocity = vel;

        changeCount++;

        if (changeCount % 2 == 0)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - dropAmount,
                transform.position.z
            );
        }
    }

    public void AumentarVelocidade(float incremento)
    {
        speed += incremento;

        Vector2 vel = rb2d.linearVelocity;
        vel.x = Mathf.Sign(vel.x) * speed;
        rb2d.linearVelocity = vel;

        waitTime = Mathf.Max(0.2f, waitTime - 0.05f);
    }
}