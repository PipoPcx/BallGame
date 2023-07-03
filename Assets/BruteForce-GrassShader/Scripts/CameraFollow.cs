using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float velocidadRotacion = 3f;

    private float rotacionX = 0f;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;

        
    }

    private void LateUpdate()
    {
        float movimientoMouseX = Input.GetAxis("Mouse X") * velocidadRotacion; // Obtener el movimiento del mouse en el eje horizontal

        player.Rotate(0f, movimientoMouseX, 0f); // rotar según movimiento del mouse

       Vector3 desiredPos = player.position + offset;
       transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * velocidadRotacion);
       transform.LookAt(player);


    }
}
