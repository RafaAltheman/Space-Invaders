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
    }

    void Start()
    {
        AtualizarUI();
    }

    public void PerderVida()
    {
        vidas--;

        if (vidas < 0)
            vidas = 0;

        AtualizarUI();

        if (vidas <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("DefeatScene");
        }
        else
        {
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
}