using UnityEngine;

public class TiroNaveMae : MonoBehaviour
{
    public float speed = 7f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

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