using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneUIManager : MonoBehaviour
{
    public GameObject uiCanvas;  // Referencia al Canvas

    private string targetScene;

    // Asigna la escena que se cargará
    public void SetTargetScene(string sceneName)
    {
        targetScene = sceneName;
        Debug.Log($"Se ha establecido targetScene como {targetScene}");
    }

    // Muestra el Canvas y la UI
    public void ShowUI(string message)
    {
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(true);  // Activa el Canvas
        }
    }

    // Oculta el Canvas y la UI
    public void HideUI()
    {
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(false);  // Desactiva el Canvas
        }
    }

    // Carga la escena cuando el botón es clickeado
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);  // Carga la escena
            Debug.Log($"Cargando la escena: {targetScene}");
        }
        else
        {
            Debug.LogError("No se ha asignado una escena.");
        }
    }
}
