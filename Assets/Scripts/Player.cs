using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform _transform;
    public Transform cameraTransform;

    Vector2 rotacaoMouse;
    public int sensibilidade = 100;

    public float velocidade = 5f;         // Velocidade de movimento
    public float forcaPulo = 5f;          // Força do pulo
    private CharacterController controller;
    private Vector3 movimento;
    private float gravidade = -9.81f;     // Gravidade

    private bool estaNoChao;
    private Vector3 velocidadeVertical;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Adiciona o CharacterController ao GameObject
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        // Controle do mouse para rotação
        Vector2 controleMouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        rotacaoMouse = new Vector2(rotacaoMouse.x + controleMouse.x * sensibilidade * Time.deltaTime,
                                   rotacaoMouse.y + controleMouse.y * sensibilidade * Time.deltaTime);
        rotacaoMouse.y = Mathf.Clamp(rotacaoMouse.y, -80, 80);

        _transform.eulerAngles = new Vector3(_transform.eulerAngles.x, rotacaoMouse.x, _transform.eulerAngles.z);
        cameraTransform.localEulerAngles = new Vector3(-rotacaoMouse.y,
                                                       cameraTransform.localEulerAngles.y,
                                                       cameraTransform.localEulerAngles.z);

        // Controle de movimento WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direcao = transform.right * horizontal + transform.forward * vertical;

        // Movimento do personagem
        movimento = direcao * velocidade;

        // Verifica se o personagem está no chão
        estaNoChao = controller.isGrounded;

        // Configura a velocidade vertical
        if (estaNoChao && velocidadeVertical.y < 0)
        {
            velocidadeVertical.y = -2f;  // Mantém o personagem no chão
        }

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            velocidadeVertical.y = Mathf.Sqrt(forcaPulo * -2f * gravidade);
        }

        // Aplica a gravidade
        velocidadeVertical.y += gravidade * Time.deltaTime;

        // Adiciona o movimento vertical (gravidade e pulo) ao movimento final
        movimento.y = velocidadeVertical.y;

        // Move o personagem
        controller.Move(movimento * Time.deltaTime);
    }
}
