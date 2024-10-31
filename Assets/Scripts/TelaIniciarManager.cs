using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject[] telas;   // Lista de todas as telas na ordem de transição
    public Button botaoProximo;  // O botão que fará a transição
    private int telaAtual = 0;   // Índice da tela atual
    [SerializeField] private Button botaoJogar;

    void Start()
    {
        // Desativar todas as telas, exceto a primeira
        for (int i = 1; i < telas.Length; i++)
        {
            telas[i].SetActive(false);
        }

        // Adicionar evento ao botão "Próximo"
        botaoProximo.onClick.AddListener(TrocarParaProximaTela);
    }

    void TrocarParaProximaTela()
    {
        // Verificar se ainda há telas para trocar
        if (telaAtual < telas.Length - 1)
        {
            // Desativar a tela atual
            telas[telaAtual].SetActive(false);

            // Ir para a próxima tela
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
