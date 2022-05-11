using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour {
	public int moveSpeed = 70;
	public Transform cam;
	Rigidbody rb;

	RaycastHit hit;

	private void Start() {
		Cursor.lockState = CursorLockMode.Confined;
		rb = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void Update() {
		if (Physics.Linecast(transform.position, cam.position, out hit)) {
			//cam.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
		}

		if (cam.localPosition.z > -3f) {
			//cam.localPosition = new Vector3(0f, 0f, -3f);
		}

		if (Input.GetButton("Fire1")) {
			if (rb.velocity.magnitude < 100)
				rb.velocity = transform.forward * moveSpeed;
		} else if (Input.GetButtonUp("Fire1"))
			rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);

		rb.MoveRotation(cam.rotation);
	}
}
