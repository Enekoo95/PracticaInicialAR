using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneUIManager : MonoBehaviour
{
    public GameObject uiCanvas;

    private string targetScene = "";

    void Start()
    {
        uiCanvas.SetActive(false);
    }

    public void ShowUI(string sceneName)
    {
        targetScene = sceneName;
        uiCanvas.SetActive(true);
    }

    public void HideUI()
    {
        uiCanvas.SetActive(false);
        targetScene = "";
    }

    public void GoToScene()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}
