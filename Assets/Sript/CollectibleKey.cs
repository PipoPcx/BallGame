using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleKey : MonoBehaviour
{
    public GameObject keyObject;
    public GameObject activatedObject;
    public Image collectedImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectKey();
        }
    }

    private void CollectKey()
    {
        // Desactivar el objeto llave
        keyObject.SetActive(false);

        // Activar el objeto deseado
        activatedObject.SetActive(true);

        // Activar la imagen en el canvas
        collectedImage.gameObject.SetActive(true);
    }
}


