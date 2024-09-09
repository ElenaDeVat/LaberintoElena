using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float mouseSensitivity = 2f; // Sensibilidad del mouse
    public Transform playerCamera; // La cámara del jugador

    private float xRotation = 0f; // Para limitar la rotación vertical

    void Start()
    {
        // Oculta y bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Esto es solo un ejemplo, puedes cambiar la lógica para desbloquear el cursor
        if (Input.GetKeyDown(KeyCode.Escape)) // Presiona "Escape" para desbloquear el cursor
        {
            Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
            Cursor.visible = true; // Haz el cursor visible
        }

        // Movimiento del jugador solo si el cursor está bloqueado
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            // Movimiento del jugador
            float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            transform.Translate(move, Space.World);

            // Movimiento de la cámara con el mouse
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }

}
