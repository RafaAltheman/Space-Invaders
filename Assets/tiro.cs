using UnityEngine;

public class tiro : MonoBehaviour
{
    public float speed = 10f;
    public int pontosPorInimigo = 10;
    public int danoNaveMae = 1;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Inimigo"))
            return;

        NaveMae naveMae = other.GetComponent<NaveMae>();
        if (naveMae != null)
        {
            naveMae.LevarDano(danoNaveMae);
            Destroy(gameObject);
            return;
        }

        invaders inimigo = other.GetComponent<invaders>();
        if (inimigo != null)
        {
            GameManager.instance.AdicionarPontos(pontosPorInimigo);
            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }
    }
}