using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class BF_BallPlayer : MonoBehaviour
{
    public Camera cam;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 inputDirection;

    public float moveSpeed = 10f; // Velocidad de movimiento
    public float jumpForce = 10f; // Fuerza de salto
    public int maxJumpCount = 2; // Cantidad máxima de saltos permitidos
    private int jumpCount = 0; // Contador de saltos

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    private void Update()
    {
        // Comenzar el salto si la tecla Espacio es presionada y se puede saltar
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpCount++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reiniciar el contador de saltos cuando colisiona con el suelo (tag "Terrain")
        if (collision.gameObject.CompareTag("Terrain"))
        {
            jumpCount = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputDirection = Vector3.zero;
#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current.qKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            inputDirection += new Vector3(-1, 0, 0);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            inputDirection += new Vector3(1, 0, 0);
        }
        if (Keyboard.current.wKey.isPressed || Keyboard.current.zKey.isPressed)
        {
            inputDirection += new Vector3(0, 0, 1);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            inputDirection += new Vector3(0, 0, -1);
        }
#else
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            inputDirection += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputDirection += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            inputDirection += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputDirection += new Vector3(0, 0, -1);
        }
#endif

        MoveBall();
    }

    private void MoveBall()
    {
        cam.transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
        moveDirection = cam.transform.TransformDirection(inputDirection.normalized);
        moveDirection.y = 0;

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
    }
}




