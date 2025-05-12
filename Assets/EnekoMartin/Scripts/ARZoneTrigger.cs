using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ARZoneTrigger : MonoBehaviour
{
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            onEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            onExit.Invoke();
        }
    }
}
