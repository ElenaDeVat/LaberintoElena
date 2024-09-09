using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;  // C�mara principal
    public Camera topDownCamera;  // C�mara desde arriba
    public MonoBehaviour[] mainCameraScripts; // Los scripts que controlan la c�mara principal
    public bool lockCursorWhenMainCamera = true; // Controla si el cursor debe bloquearse con la c�mara principal

    private bool isTopDownView = false; // Para verificar cu�l c�mara est� activa

    // Este m�todo se llamar� al presionar el bot�n
    public void SwitchCameraView()
    {
        if (isTopDownView)
        {
            // Cambiar de la c�mara superior a la c�mara principal
            topDownCamera.gameObject.SetActive(false);
            mainCamera.enabled = true;
            SetScriptsActive(true); // Reactiva los scripts de la c�mara principal
            LockCursor(true); // Bloquea el cursor cuando vuelve a la c�mara principal
            Debug.Log("Cambiado a la c�mara principal");
        }
        else
        {
            // Cambiar de la c�mara principal a la c�mara superior
            mainCamera.enabled = false;
            SetScriptsActive(false); // Desactiva los scripts de la c�mara principal
            topDownCamera.gameObject.SetActive(true);
            LockCursor(false); // Desbloquea el cursor cuando pasa a la c�mara superior
            Debug.Log("Cambiado a la c�mara desde arriba");
        }

        // Cambia el estado de la vista
        isTopDownView = !isTopDownView;
    }

    // M�todo para activar/desactivar los scripts de la c�mara principal
    private void SetScriptsActive(bool active)
    {
        foreach (MonoBehaviour script in mainCameraScripts)
        {
            script.enabled = active;
        }
    }

    // M�todo para bloquear/desbloquear el cursor
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
