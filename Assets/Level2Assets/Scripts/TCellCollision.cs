using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCellCollision : MonoBehaviour {
	public delegate void DeadAction();
	public static event DeadAction OnDead;

	public delegate void BCellAction();
	public static event BCellAction OnBCellCollect;

	public SceneController sc;

	// Start is called before the first frame update
	void Start() {}

	// Update is called once per frame
	void Update() {}

	void OnCollisionEnter(Collision collision) {
		switch (collision.gameObject.tag) {
			case "BloodVessel":
				Destroy(gameObject);
				OnDead();
				sc.ShowScoreMenu();
				break;

			case "BCell":
				Destroy(collision.gameObject);
				OnBCellCollect();
				break;
		}
	}
}
