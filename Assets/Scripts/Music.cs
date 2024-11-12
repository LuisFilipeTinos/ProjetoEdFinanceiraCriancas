using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public string cenaParaParar; // Nome da cena onde a m�sica deve parar

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Para manter o objeto ativo entre cenas
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == cenaParaParar)
        {
            Destroy(gameObject); // Destr�i o GameObject quando a cena especificada � carregada
        }
    }
}
