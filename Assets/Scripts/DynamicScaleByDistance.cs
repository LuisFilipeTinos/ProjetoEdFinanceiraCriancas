using UnityEngine;

public class DynamicScaleByDistance : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float baseScale = 1f; // Escala base para o objeto
    public float scaleFactor = 0.3f; // Fator de escala com base na distância

    void Update()
    {
        if (player == null) return;

        // Calcula a distância entre o jogador e o objeto
        float distance = Vector3.Distance(player.position, transform.position);

        // Define a escala proporcional à distância
        float scale = baseScale + (distance * scaleFactor);

        // Aplica a escala ao objeto
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
