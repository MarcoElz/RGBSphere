using UnityEngine;

public abstract class CallsBoxManaged : MonoBehaviour
{
    void OnEnable()
    {
        CallsBoxManager.instance.Register(this);
    }

    void OnDisable()
    {
        CallsBoxManager.instance.Unregister(this);
    }

    public abstract void ManagedFixedUpdate();

}
