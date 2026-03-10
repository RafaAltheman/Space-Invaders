using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    public float speed = 6f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControls1 player = other.GetComponent<PlayerControls1>();
            if (player != null)
            {
                player.Morrer();
            }

            Destroy(gameObject);
        }
    }
}