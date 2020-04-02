using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    private float currentZoom = 10f, yawInput = 0f;
    public float pitch = 2f, zoomSpeed = 4f, minZoom = 5f, maxZoom = 15f, yawSpeed = 100f;





    // Update is called once per frame

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(zoomSpeed, minZoom, maxZoom);

        yawInput -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }



    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, yawInput);
    }
}
