using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Torus : MonoBehaviour
{
   public gameManager manager;
   public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {

            manager.puntaje += 10;
            audioSource.Play();
        }
    }
}
