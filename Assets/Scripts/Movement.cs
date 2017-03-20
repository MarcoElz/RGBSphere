using UnityEngine;

public class Movement : CallsBoxManaged 
{
    //Variables for movement
    private float speed;
    private float smooth;

    private Vector3 zeroAc;
    private Vector3 curAc;

    private float GetAxisH;
    private float sensH;

    void Awake()
    {
        speed = 8.0f;
        smooth = 0.5f;
        GetAxisH = 0;
        sensH = 1;
    }

    //PlayerMovement
    public override void ManagedFixedUpdate()
    {
        //get input by accelerometer
        #if !UNITY_EDITOR
        curAc = Vector3.Lerp(curAc, Input.acceleration-zeroAc, Time.deltaTime/smooth);
        GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);
        Vector3 movement = new Vector3 (GetAxisH, 0.0f, 0);

        //UnityEditor
        #else
        Vector3 movement = Vector3.right * Input.GetAxis("Horizontal");
        #endif

        //The movement
        this.transform.Translate(movement * speed * Time.deltaTime); 

        //Clamp position
        Vector3 pos = this.transform.position;
        Vector3 clampedPos = new Vector3(
            Mathf.Clamp(pos.x, -1.2f, 1.3f),
            0.5f,
            0.5f);
        this.transform.position = clampedPos;
    }
}
