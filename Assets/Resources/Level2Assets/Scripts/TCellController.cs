using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class TCellController : MonoBehaviour {
	public float moveSpeed = 10f;

	TCellControls controls;
	InputAction moveLeft;
	InputAction moveRight;

	readonly int[] positions_ = new int[3] { -1, 0, 1 };
	int positionIndex_;

	void Awake() {
		controls = new TCellControls();
		moveLeft = controls.Player.MoveLeft;
		moveRight = controls.Player.MoveRight;
	}

	void Start() {
		positionIndex_ = 1;
	}

	void OnEnable() {
		moveLeft.Enable();
		moveRight.Enable();
		moveLeft.started += MoveLeftE;
		moveRight.started += MoveRightE;
	}

	void OnDisable() {
		moveLeft.started -= MoveLeftE;
		moveRight.started -= MoveRightE;
		moveLeft.Disable();
		moveRight.Disable();
	}

	public int GetDestination() {
		return positions_[positionIndex_];
	}

	public void SetDestination(int index) {
		if (positionIndex_ < 0 || positionIndex_ >= positions_.Length)
			return;

		positionIndex_ = index;
	}

	public void MoveLeft() {
		if (positionIndex_ <= 0)
			return;

		--positionIndex_;
	}

	public void MoveRight() {
		if (positionIndex_ >= 2)
			return;

		++positionIndex_;
	}

	void MoveLeftE(InputAction.CallbackContext context) {
		MoveLeft();
	}

	void MoveRightE(InputAction.CallbackContext context) {
		MoveRight();
	}

	public bool IsPointerOverUI(int fingerId) {
		EventSystem eventSystem = EventSystem.current;
		return (eventSystem.IsPointerOverGameObject(fingerId) &&
		        eventSystem.currentSelectedGameObject != null);
	}

	void Update() {
		Debug.Log(Level2SceneController.isPaused());

		if (Input.touchCount > 0 && !Level2SceneController.isPaused() && !IsPointerOverUI(0)) {
			Touch touch = Input.GetTouch(0);

			if (touch.phase == UnityEngine.TouchPhase.Began) {
				if (touch.position.x < Screen.width / 2) {
					MoveLeft();
				} else {
					MoveRight();
				}
			}
		}

		Vector3 destination = new Vector3(GetDestination(), -1.5f, 0.0f);

		float step = moveSpeed * Time.deltaTime;

		transform.position = Vector3.MoveTowards(transform.position, destination, step);
	}
}
