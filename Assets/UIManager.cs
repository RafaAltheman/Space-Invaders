using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text vidasTexto;
    public TMP_Text pontuacaoTexto;

    void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.vidasTexto = vidasTexto;
            GameManager.instance.pontuacaoTexto = pontuacaoTexto;
            GameManager.instance.AtualizarUI();
        }
    }
}