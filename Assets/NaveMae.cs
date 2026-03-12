using UnityEngine;

public class NaveMae : MonoBehaviour
{
    public float speed = 2f;
    public float limiteEsquerdo = -4.5f;
    public float limiteDireito = 4.5f;

    public int vidaMaxima = 5;
    public int pontosPorDestruir = 100;

    public GameObject tiroNaveMaePrefab;
    public Transform pontoTiro;
    public float shootInterval = 2.5f;
    public int maxBulletsOnScreen = 2;

    private int vidaAtual;
    private int direcao = 1;
    private float shootTimer = 0f;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    void Update()
    {
        Mover();
        ControlarTiro();
    }

    void Mover()
    {
        transform.Translate(Vector2.right * direcao * speed * Time.deltaTime);

        if (transform.position.x >= limiteDireito)
        {
            direcao = -1;
        }
        else if (transform.position.x <= limiteEsquerdo)
        {
            direcao = 1;
        }
    }

    void ControlarTiro()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Atirar();
            shootTimer = 0f;
        }
    }

    void Atirar()
    {
        if (tiroNaveMaePrefab == null || pontoTiro == null)
            return;

        TiroNaveMae[] tirosDaNaveMae = FindObjectsByType<TiroNaveMae>(FindObjectsSortMode.None);

        if (tirosDaNaveMae.Length >= maxBulletsOnScreen)
            return;

        Instantiate(tiroNaveMaePrefab, pontoTiro.position, Quaternion.identity);
    }

    public void LevarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.AdicionarPontos(pontosPorDestruir);
        }

        Destroy(gameObject);
    }
}