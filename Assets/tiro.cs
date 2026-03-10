using UnityEngine;

public class tiro : MonoBehaviour
{
    public float speed = 10f;
    public int pontosPorInimigo = 10;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            GameManager.instance.AdicionarPontos(pontosPorInimigo);

            invaders inimigo = other.GetComponent<invaders>();
            if (inimigo != null)
            {
                invaders[] todos = FindObjectsOfType<invaders>();

                foreach (invaders inv in todos)
                {
                    if (inv != null && inv != inimigo)
                    {
                        inv.AumentarVelocidade(0.1f);
                    }
                }
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}