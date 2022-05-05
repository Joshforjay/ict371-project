using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TCellController : MonoBehaviour {
	public float moveSpeed;

	TCellControls controls;
	InputAction movement;

	void Awake() {
		controls = new TCellControls();
	}

	void OnEnable() {
		movement = controls.Player.Move;
		movement.Enable();
	}

	void OnDisable() {
		movement.Disable();
	}

	void FixedUpdate() {
		Vector2 move = moveSpeed * Time.fixedDeltaTime * movement.ReadValue<Vector2>();

		Rigidbody rb = GetComponent<Rigidbody>();

		rb.AddForce(new Vector3(move.x, move.y, 0.0f));
	}
}
