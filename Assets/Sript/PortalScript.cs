using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public string destinationPortalTag; // Tag del portal de destino
    public float forwardOffset = 1.0f; // Desplazamiento hacia adelante en el eje Z
    public float colliderDisableTime = 1.0f; // Tiempo en segundos para desactivar el collider después de teletransportarse
    public GameObject objectToActivate; // Objeto a activar después del teletransporte
    public GameObject objectToDeactivate; // Objeto a desactivar después del teletransporte

    private bool isTeleporting = false; // Control de teletransportación
    private Collider portalCollider; // Collider del portal

    private void Start()
    {
        portalCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTeleporting && other.CompareTag("Player"))
        {
            // Teletransportar al jugador a la posición del portal de destino
            TeleportPlayer(other.transform);

            // Desactivar el collider durante un tiempo para evitar teletransportaciones consecutivas
            StartCoroutine(DisableCollider());

            // Obtener el portal de destino mediante el tag y asignar el teletransporte
            GameObject destinationPortal = GetDestinationPortal();
            if (destinationPortal != null)
            {
                PortalScript destinationScript = destinationPortal.GetComponent<PortalScript>();
                destinationScript.TeleportPlayer(other.transform);

                // Desactivar el collider del portal de destino durante un tiempo
                StartCoroutine(destinationScript.DisableCollider());
            }

            // Activar objeto y desactivar otro objeto
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }
        }
    }

    private void TeleportPlayer(Transform playerTransform)
    {
        // Teletransportar al jugador a la posición del portal de destino
        playerTransform.position = GetDestinationPortalPosition();
    }

    private Vector3 GetDestinationPortalPosition()
    {
        // Obtener la posición del portal de destino
        Vector3 destinationPosition = transform.position + transform.forward * forwardOffset;

        return destinationPosition;
    }

    private GameObject GetDestinationPortal()
    {
        // Buscar el portal de destino mediante el tag
        GameObject[] portals = GameObject.FindGameObjectsWithTag(destinationPortalTag);
        foreach (GameObject portal in portals)
        {
            if (portal != gameObject)
            {
                return portal;
            }
        }

        return null;
    }

    private System.Collections.IEnumerator DisableCollider()
    {
        isTeleporting = true;
        portalCollider.enabled = false;

        yield return new WaitForSeconds(colliderDisableTime);

        isTeleporting = false;
        portalCollider.enabled = true;
    }
}














