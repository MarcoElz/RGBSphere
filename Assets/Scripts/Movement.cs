using UnityEngine;

public class Movement : MonoBehaviour 
{
    private float speed = 8.0f;
    private float smooth = 0.5f;

    private Vector3 zeroAc;
    private Vector3 curAc;

    private float GetAxisH = 0;
    private float sensH = 1;


    void FixedUpdate()
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

        this.transform.Translate(movement * speed * Time.deltaTime);

        Vector3 pos = this.transform.position;
        Vector3 clampedPos = new Vector3(
            Mathf.Clamp(pos.x, -1.2f, 1.3f),
            0.5f,
            0.5f);
        this.transform.position = clampedPos;
    }
}
