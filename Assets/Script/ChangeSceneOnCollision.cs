using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que deseas cambiar

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Debug.Log("1");
        {
            
            SceneManager.LoadScene(sceneName); // Cargar la nueva escena
            Debug.Log("2");
        }
    }
}

