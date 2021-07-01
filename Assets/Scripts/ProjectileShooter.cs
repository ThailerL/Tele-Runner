using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

	void LateUpdate ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(projectilePrefab) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * projectileSpeed;
        }
	}
}
