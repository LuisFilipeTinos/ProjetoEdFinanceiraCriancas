using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public string cenaParaParar; // Nome da cena onde a música deve parar

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Para manter o objeto ativo entre cenas
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == cenaParaParar)
        {
            Destroy(gameObject); // Destrói o GameObject quando a cena especificada é carregada
        }
    }
}
