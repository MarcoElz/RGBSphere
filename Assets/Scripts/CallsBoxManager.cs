using UnityEngine;
using System.Collections.Generic;

public class CallsBoxManager : MonoBehaviour
{
    private List<CallsBoxManaged> _managedBoxes;
    
    public static CallsBoxManager instance;
	void Awake ()
	{
        if (instance == null)
            instance = this;

        _managedBoxes = new List<CallsBoxManaged>();
	}

    public void Register(CallsBoxManaged box)
    {
        _managedBoxes.Add(box);
    }

    public void Unregister(CallsBoxManaged box)
    {
        _managedBoxes.Remove(box);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < _managedBoxes.Count; i++)
        {
            _managedBoxes[i].ManagedFixedUpdate();
        }
    }

}
