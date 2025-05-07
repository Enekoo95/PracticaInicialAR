using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;

public class ARUIManager : MonoBehaviour
{
    [Header("Managers")]
    public ARPlaneManager planeManager;
    public PlaceOnPlane placeOnPlane;

    [Header("UI Elements")]
    public TMP_Text planeCountText;
    public TMP_Dropdown prefabDropdown;
    public Button clearButton;

    [Header("Prefabs List")]
    public List<GameObject> prefabOptions = new List<GameObject>();

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        // Llenar el dropdown con nombres de los prefabs
        prefabDropdown.ClearOptions();
        List<string> names = prefabOptions.ConvertAll(p => p.name);
        prefabDropdown.AddOptions(names);

        // Cambiar el prefab cuando se selecciona otro
        prefabDropdown.onValueChanged.AddListener(index =>
        {
            placeOnPlane.placedPrefab = prefabOptions[index];
        });

        // Botón de borrar
        clearButton.onClick.AddListener(() =>
        {
            foreach (var obj in spawnedObjects)
            {
                Destroy(obj);
            }
            spawnedObjects.Clear();
        });

        // Asignar el primer prefab por defecto
        if (prefabOptions.Count > 0)
            placeOnPlane.placedPrefab = prefabOptions[0];

        // Hook en el PlaceOnPlane para registrar objetos instanciados
        placeOnPlane.OnObjectPlaced += obj => spawnedObjects.Add(obj);
    }

    void Update()
    {
        if (planeManager != null)
        {
            planeCountText.text = $"Planos detectados: {planeManager.trackables.count}";
        }
    }
}
