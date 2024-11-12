using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject telaCreditos;
    public GameObject BarraDia;        // Referência para a BarraDia
    public GameObject BarraDinheiro;   // Referência para a BarraDinheiro
    public GameObject BalaoFala;       // Referência para o BalaoFala

    private bool isPaused = false;
    private bool isCursorVisible = false; // Novo estado para o cursor

    void Update()
    {
        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        // Verifica se a tecla TAB foi pressionada
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleCursor();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);   // Ativa o painel de pausa
        BarraDia.SetActive(false);    // Esconde a BarraDia
        BarraDinheiro.SetActive(false); // Esconde a BarraDinheiro
        BalaoFala.SetActive(false);   // Esconde o BalaoFala
        Time.timeScale = 0f;          // Congela o tempo do jogo
        Cursor.visible = true;        // Mostra o cursor do mouse
        Cursor.lockState = CursorLockMode.None; // Libera o cursor para movimentação
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);     // Desativa o painel de pausa
        telaCreditos.SetActive(false);   // Desativa a tela de créditos caso esteja aberta
        BarraDia.SetActive(true);        // Mostra a BarraDia
        BarraDinheiro.SetActive(true);   // Mostra a BarraDinheiro
        Time.timeScale = 1f;             // Retoma o tempo do jogo
        Cursor.visible = false;          // Esconde o cursor do mouse novamente
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor novamente, se necessário
        isPaused = false;
    }

    public void OpenCreditos()
    {
        pausePanel.SetActive(false);     // Esconde o painel de pausa
        telaCreditos.SetActive(true);    // Mostra a tela de créditos
        BarraDia.SetActive(false);       // Esconde a BarraDia
        BarraDinheiro.SetActive(false);  // Esconde a BarraDinheiro
        BalaoFala.SetActive(false);      // Esconde o BalaoFala
    }

    public void OpenTutorial()
    {
        Time.timeScale = 1f;             // Retoma o tempo do jogo antes de carregar a nova cena
        SceneManager.LoadScene("Tela Inicial - Tutorial"); // Nome da cena de tutorial
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do Jogo...");
        Application.Quit();              // Fecha o jogo
    }

    private void ToggleCursor()
    {
        isCursorVisible = !isCursorVisible; // Alterna o estado do cursor
        Cursor.visible = isCursorVisible;   // Define a visibilidade do cursor
        Cursor.lockState = isCursorVisible ? CursorLockMode.None : CursorLockMode.Locked; // Libera ou trava o cursor
    }
}
