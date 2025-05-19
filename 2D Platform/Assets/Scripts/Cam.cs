using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player;
    public float minX, maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void FixedUpdate()
    {
        Vector3 newPositionCam = player.position + new Vector3(0, 0, -10);
        newPositionCam.y = -0.1f;
        newPositionCam = Vector3.Lerp(transform.position, newPositionCam, Time.deltaTime/1.15f);
        transform.position = newPositionCam;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        
    }
}
