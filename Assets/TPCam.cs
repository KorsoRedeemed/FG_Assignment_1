using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerBody;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float veritcalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * veritcalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerBody.forward = Vector3.Slerp(playerBody.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
