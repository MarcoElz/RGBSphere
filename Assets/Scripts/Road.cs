using UnityEngine;

public class Road : MonoBehaviour {

    private Vector3 restartPosition;
    private float vanishZ;

    void Start()
    {
        restartPosition = new Vector3(0, 0, 10);
        vanishZ = -2f;
    }

	void FixedUpdate () 
    {
        if (this.transform.position.z < vanishZ)
            Vanish();
	}

    private void Vanish()
    {
        //More particles
        if(this.transform.childCount > 0)
            Destroy(this.transform.GetChild(0).gameObject);     
        this.transform.position = restartPosition; //Move this to last
        //Even more particles
        GameManager.instance.SpawnObject(this.gameObject);
    }
}
