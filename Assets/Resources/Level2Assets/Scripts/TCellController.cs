using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TCellController : MonoBehaviour {
	public float moveSpeed;

	TCellControls controls;
	InputAction moveLeft;
	InputAction moveRight;

	readonly int[] positions_ = new int[3] { -1, 0, 1 };
	int positionIndex_ = 1;

	void Awake() {
		controls = new TCellControls();
		moveLeft = controls.Player.MoveLeft;
		moveRight = controls.Player.MoveRight;
	}

	void OnEnable() {
		moveLeft.Enable();
		moveRight.Enable();
		moveLeft.started += MoveLeft;
		moveRight.started += MoveRight;
	}

	void OnDisable() {
		moveLeft.Disable();
		moveRight.Disable();
		moveLeft.started -= MoveLeft;
		moveRight.started -= MoveRight;
	}

	void MoveLeft(InputAction.CallbackContext context) {
		if (positionIndex_ <= 0)
			return;

		--positionIndex_;
	}

	void MoveRight(InputAction.CallbackContext context) {
		if (positionIndex_ >= 2)
			return;

		++positionIndex_;
	}

	void Update() {
		Vector3 destination = new Vector3(positions_[positionIndex_], -1.5f, 0);

		Rigidbody rb = GetComponent<Rigidbody>();

		float step = moveSpeed * Time.fixedDeltaTime;

		transform.position = Vector3.MoveTowards(transform.position, destination, step);
	}
}
