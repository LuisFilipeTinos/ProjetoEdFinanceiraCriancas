using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Refer�ncias aos elementos do Canvas
    public GameObject botaoVoltar;
    public GameObject telaCreditos;
    public GameObject fundo;
    public GameObject botaoJogar;
    public GameObject botaoCreditos;
    public GameObject botaoSair;

    void Start()
    {
        // Inicialmente, mostra o menu principal e esconde a tela de cr�ditos e o bot�o de voltar
        MostrarMenuPrincipal();
    }

    // Fun��o para exibir o menu principal
    void MostrarMenuPrincipal()
    {
        botaoVoltar.SetActive(false); // Esconde o bot�o "Voltar"
        telaCreditos.SetActive(false); // Esconde a tela de cr�ditos
        fundo.SetActive(true); // Garante que o fundo permanece ativo
        botaoJogar.SetActive(true); // Mostra o bot�o "Jogar"
        botaoCreditos.SetActive(true); // Mostra o bot�o "Cr�ditos"
        botaoSair.SetActive(true); // Mostra o bot�o "Sair"
        Debug.Log("Menu Principal Mostrado");
    }

    // Fun��o para o bot�o "JOGAR"
    public void Jogar()
    {
        Debug.Log("Bot�o Jogar pressionado");
        // Carrega a cena chamada "Tela Inicial"
        SceneManager.LoadScene("Tela Inicial - Tutorial");
    }

    // Fun��o para o bot�o "CR�DITOS"
    public void MostrarCreditos()
    {
        Debug.Log("Bot�o Cr�ditos pressionado");
        // Exibe a tela de cr�ditos e o bot�o de voltar, e esconde os bot�es do menu principal
        botaoVoltar.SetActive(true); // Mostra o bot�o "Voltar"
        telaCreditos.SetActive(true); // Mostra a tela de cr�ditos
        botaoJogar.SetActive(false); // Esconde o bot�o "Jogar"
        botaoCreditos.SetActive(false); // Esconde o bot�o "Cr�ditos"
        botaoSair.SetActive(false); // Esconde o bot�o "Sair"
    }

    // Fun��o para o bot�o "VOLTAR" no painel de cr�ditos
    public void VoltarParaMenu()
    {
        Debug.Log("Bot�o Voltar pressionado");
        // Volta para o menu principal
        MostrarMenuPrincipal();
    }

    // Fun��o para o bot�o "SAIR"
    public void SairDoJogo()
    {
        Debug.Log("Bot�o Sair pressionado");
        // Sai do jogo (s� funciona em builds, n�o no editor)
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para o jogo no editor
#endif
    }
}
