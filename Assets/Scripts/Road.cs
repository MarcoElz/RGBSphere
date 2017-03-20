using UnityEngine;

public class Road : MonoBehaviour {

    //Cachce variables
    private Vector3 restartPosition; //The restart position of this object
    private Vector3 childDestructionPosition; //The position when 'destroying' children
    private float vanishZ; //The z position to vanish the object

    void Start()
    {
        //Initialize variables
        restartPosition = new Vector3(0f, 0f, 10f);
        childDestructionPosition = new Vector3(0f, 0f, 20f);
        vanishZ = -2f;
    }

    //Check for z position to vanish
	void FixedUpdate () 
    {
        if (this.transform.position.z < vanishZ)
            Vanish();
	}

    //Vanish the object
    private void Vanish()
    {
        //More particles

        //Move the children position
        if (this.transform.childCount > 0)
            this.transform.GetChild(0).transform.position = childDestructionPosition; 
        
        this.transform.position = restartPosition; //Move this to last position of the road

        //Even more particles

        GameManager.instance.SpawnObject(this.gameObject); //Spawn a new object
    }
}
