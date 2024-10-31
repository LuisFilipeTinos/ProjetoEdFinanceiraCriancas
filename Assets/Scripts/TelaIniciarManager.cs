using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject[] telas;   // Lista de todas as telas na ordem de transi��o
    public Button botaoProximo;  // O bot�o que far� a transi��o
    private int telaAtual = 0;   // �ndice da tela atual
    [SerializeField] private Button botaoJogar;

    void Start()
    {
        // Desativar todas as telas, exceto a primeira
        for (int i = 1; i < telas.Length; i++)
        {
            telas[i].SetActive(false);
        }

        // Adicionar evento ao bot�o "Pr�ximo"
        botaoProximo.onClick.AddListener(TrocarParaProximaTela);
    }

    void TrocarParaProximaTela()
    {
        // Verificar se ainda h� telas para trocar
        if (telaAtual < telas.Length - 1)
        {
            // Desativar a tela atual
            telas[telaAtual].SetActive(false);

            // Ir para a pr�xima tela
            telaAtual++;
            telas[telaAtual].SetActive(true);

            // Desativar
            if (telaAtual == 6)
            {
                botaoProximo.gameObject.SetActive(false);
            }
        }
    }
    
    public void IniciarJogo()
    {
        SceneManager.LoadScene(1);
    }
}
