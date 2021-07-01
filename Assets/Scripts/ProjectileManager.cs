using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {

    Rigidbody rb;

    GameObject player;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Destroy(gameObject);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
    }
}
