using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    // Arrastra aquí tu Canvas desde el Inspector
    public GameObject canvas;

    // Este método se llama cuando otro objeto entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos que el objeto que entra en el trigger es el jugador (tagged como "Player")
        if (other.CompareTag("Player"))
        {
            // Activar el Canvas
            canvas.SetActive(true);
        }
    }

    // Este método se llama cuando otro objeto sale del trigger
    private void OnTriggerExit(Collider other)
    {
        // Verificamos que el objeto que sale es el jugador
        if (other.CompareTag("Player"))
        {
            // Desactivar el Canvas
            canvas.SetActive(false);
        }
    }
}
