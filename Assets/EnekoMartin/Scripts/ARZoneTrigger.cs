using UnityEngine;

public class ARZoneTrigger : MonoBehaviour
{
    public ZoneUIManager zoneUIManager;  // Declaramos una referencia pública a ZoneUIManager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log($"Entraste en la zona {gameObject.name}");

            if (zoneUIManager != null)
            {
                // Asigna la escena dependiendo del cubo
                if (gameObject.name == "Cubo1")  // Si entras en el cubo 1
                {
                    zoneUIManager.SetTargetScene("Escena1");
                }
                else if (gameObject.name == "Cubo2")  // Si entras en el cubo 2
                {
                    zoneUIManager.SetTargetScene("Escena2");
                }

                zoneUIManager.ShowUI("Selecciona la escena");
            }
            else
            {
                Debug.LogError("zoneUIManager no está asignado.");
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            zoneUIManager.HideUI();
            Debug.Log($"Saliste de la zona {gameObject.name}");
        }
    }
}
