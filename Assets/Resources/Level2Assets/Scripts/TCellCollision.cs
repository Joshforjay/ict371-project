using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCellCollision : MonoBehaviour {
	public delegate void DeadAction();
	public static event DeadAction OnDead;

	public delegate void BCellAction();
	public static event BCellAction OnBCellCollect;

	public SceneController sc;

	public GameObject bCellActivationParticle;

	// Start is called before the first frame update
	void Start() {}

	// Update is called once per frame
	void Update() {}

	void OnTriggerEnter(Collider collision) {
		switch (collision.gameObject.tag) {
			case "Covid":
				Destroy(gameObject);
				OnDead();
				sc.ShowScoreMenu();
				sc.isPaused = true;
				break;

			case "BCell":
				GameObject particle = Instantiate(
				    bCellActivationParticle, collision.transform.position, Quaternion.identity);
				particle.GetComponent<ParticleSystem>().Play();
				Destroy(collision.gameObject);
				OnBCellCollect();
				break;
		}
	}
}
