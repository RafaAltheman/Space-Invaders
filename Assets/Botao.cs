using UnityEngine;
using UnityEngine.SceneManagement;

public class Botao : MonoBehaviour
{
    public void VoltarParaInicio()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.vidas = 3;
            GameManager.instance.pontuacao = 0;
            GameManager.instance.AtualizarUI();
        }

        SceneManager.LoadScene("SampleScene");
    }
}