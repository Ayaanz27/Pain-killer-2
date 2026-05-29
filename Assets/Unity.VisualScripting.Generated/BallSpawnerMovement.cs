using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float xSpeed = 1f;        // Oscillation speed (Hz) in x direction 
    public float xDistance  = 2f;    // How far left or right is going 

    public float zSpeed = 1f;        // Oscillation speed (Hz) in the z direction 
    public float zDistance  = 2f;   //  How far foward or backward is going 

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;  // Record base pos for oscillation
    }

    void Update()
    {
        // Smooth forward/back motion along Z (sin wave)
        float z = Mathf.Sin(Time.time * zSpeed) * zDistance;
       

        float x = Mathf. Sin(Time.time*xSpeed) * zDistance;
        transform.position = new Vector3(
            startPos.x + x,
            startPos.y,
            startPos.z + z
        );
    }
}