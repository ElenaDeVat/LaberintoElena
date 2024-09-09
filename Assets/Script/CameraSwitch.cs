using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;  // Cámara principal
    public Camera topDownCamera;  // Cámara desde arriba
    public MonoBehaviour[] mainCameraScripts; // Los scripts que controlan la cámara principal
    public bool lockCursorWhenMainCamera = true; // Controla si el cursor debe bloquearse con la cámara principal

    private bool isTopDownView = false; // Para verificar cuál cámara está activa

    // Este método se llamará al presionar el botón
    public void SwitchCameraView()
    {
        if (isTopDownView)
        {
            // Cambiar de la cámara superior a la cámara principal
            topDownCamera.gameObject.SetActive(false);
            mainCamera.enabled = true;
            SetScriptsActive(true); // Reactiva los scripts de la cámara principal
            LockCursor(true); // Bloquea el cursor cuando vuelve a la cámara principal
            Debug.Log("Cambiado a la cámara principal");
        }
        else
        {
            // Cambiar de la cámara principal a la cámara superior
            mainCamera.enabled = false;
            SetScriptsActive(false); // Desactiva los scripts de la cámara principal
            topDownCamera.gameObject.SetActive(true);
            LockCursor(false); // Desbloquea el cursor cuando pasa a la cámara superior
            Debug.Log("Cambiado a la cámara desde arriba");
        }

        // Cambia el estado de la vista
        isTopDownView = !isTopDownView;
    }

    // Método para activar/desactivar los scripts de la cámara principal
    private void SetScriptsActive(bool active)
    {
        foreach (MonoBehaviour script in mainCameraScripts)
        {
            script.enabled = active;
        }
    }

    // Método para bloquear/desbloquear el cursor
    private void LockCursor(bool shouldLock)
    {
        if (shouldLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
