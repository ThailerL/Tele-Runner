using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public float jumpHeight = 10;

    public float sensitivity = 5f;
    public float clampAngle = 80f;
    float vertRot = 0;
    Rigidbody rb;
    CapsuleCollider cc;

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
    }
	
	void Update ()
    {
        //Movement
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        if (Input.GetButtonDown("Jump") && Physics.Raycast(rb.position, Vector3.down, cc.bounds.extents.y + .2f))
        {
            rb.velocity = new Vector3(0, jumpHeight, 0);
        }

        //Rotation
        float horRot = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, horRot, 0);

        vertRot -= Input.GetAxis("Mouse Y") * sensitivity;
        vertRot = Mathf.Clamp(vertRot, -clampAngle, clampAngle);
        Camera.main.transform.localRotation = Quaternion.Euler(vertRot, 0, 0);
       
	}
}
