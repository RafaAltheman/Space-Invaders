using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int vidas = 3;
    public int pontuacao = 0;

    public TMP_Text vidasTexto;
    public TMP_Text pontuacaoTexto;

    private bool transicionandoDeCena = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        AtualizarUI();
    }

    void Update()
    {
        VerificarVitoria();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transicionandoDeCena = false;

        vidasTexto = GameObject.Find("VidasTexto")?.GetComponent<TMP_Text>();
        pontuacaoTexto = GameObject.Find("PontosTexto")?.GetComponent<TMP_Text>();

        AtualizarUI();
    }

    public void PerderVida()
    {
        if (transicionandoDeCena) return;

        vidas--;

        if (vidas < 0)
            vidas = 0;

        AtualizarUI();

        if (vidas <= 0)
        {
            transicionandoDeCena = true;
            SceneManager.LoadScene("History1");
        }
        else
        {
            transicionandoDeCena = true;
            ReiniciarFase();
        }
    }

    public void AdicionarPontos(int pontos)
    {
        pontuacao += pontos;
        AtualizarUI();
    }

    public void AtualizarUI()
    {
        if (vidasTexto != null)
            vidasTexto.text = "Vidas: " + vidas;

        if (pontuacaoTexto != null)
            pontuacaoTexto.text = "Pontos: " + pontuacao;
    }

    public void ReiniciarFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void VerificarVitoria()
    {
        if (transicionandoDeCena) return;

        string cenaAtual = SceneManager.GetActiveScene().name;

        if (cenaAtual != "SampleScene")
            return;

        GameObject[] invaders = GameObject.FindGameObjectsWithTag("Inimigo");
        GameObject naveMae = GameObject.FindGameObjectWithTag("NaveMae");

        if (invaders.Length == 0 && naveMae == null)
        {
            transicionandoDeCena = true;
            SceneManager.LoadScene("History");
        }
    }
}