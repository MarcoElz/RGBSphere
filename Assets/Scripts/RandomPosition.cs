using UnityEngine;

public class RandomPosition : MonoBehaviour 
{
    private Transform parent;

    void Start()
    {
        parent = this.transform.parent;
        int x = Random.Range(-1, 2);
        this.transform.position = new Vector3(x, this.transform.position.y, parent.transform.position.z);
    }
}
