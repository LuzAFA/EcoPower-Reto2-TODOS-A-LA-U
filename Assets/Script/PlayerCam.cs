using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public bool activeTP;
    public Transform posTP;
    public Transform posPP;

    // CamaraTP
    public float rotSpeed;
    public float rotMin, rotMax;
    private float mouseX, mouseY;
    public Transform target, player;

    // FOV (Campo de Visión)
    public float minFOV = 20f;
    public float maxFOV = 100f;
    public float sensitivity = 10f;

    private Camera cam;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponent<Camera>();
    }

    public void Cam()
    {
        mouseX += rotSpeed * Input.GetAxis("Mouse X");
        mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, rotMin, rotMax);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0.0f);
        player.rotation = Quaternion.Euler(0.0f, mouseX, 0.0f);

        // Adjust FOV based on input
        float fov = cam.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        cam.fieldOfView = fov;
    }

    private void LateUpdate()
    {
        Cam();
        if (activeTP == false && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = true;
            transform.position = posPP.position;
        }
        else if (activeTP == true && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = false;
            transform.position = posTP.position;
            transform.LookAt(player);
        }
    }
}