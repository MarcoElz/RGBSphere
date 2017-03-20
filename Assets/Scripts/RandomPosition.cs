using UnityEngine;

public class RandomPosition : MonoBehaviour 
{
    private Transform parent; //Cache parent

    void Start()
    {
        Randomize(); //At start randomize
    }

    public void Randomize()
    {
        parent = this.transform.parent;
        int x = Random.Range(-1, 2); //random position value
        this.transform.position = new Vector3(x, this.transform.position.y, parent.transform.position.z); //The new position
    }
}
