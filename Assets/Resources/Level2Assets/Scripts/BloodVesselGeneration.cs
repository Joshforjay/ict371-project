using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVesselGeneration : MonoBehaviour {
	[SerializeField]
	int maxBloodVessels;

	[SerializeField]
	GameObject bloodVessel;

	public delegate void SpawnAction();
	public static event SpawnAction OnSpawnVessel;

	// Start is called before the first frame update
	void Start() {
		SpawnBloodVessel(maxBloodVessels);
	}

	// Update is called once per frame
	void Update() {
		SpawnBloodVessel(maxBloodVessels - transform.childCount);
	}

	public Transform GetLastVessel() {
		return transform.GetChild(transform.childCount - 1).transform;
	}

	void SpawnBloodVessel(int count) {
		for (int i = 0; i < count; ++i) {
			Transform lastVessel = GetLastVessel();
			float zPos = lastVessel.position.z;

			// Spawn at the end of the last vessel.
			Vector3 spawnPos = new Vector3(0, 0, zPos + 20.0f);

			Instantiate(bloodVessel, spawnPos, Quaternion.identity, transform);

			OnSpawnVessel();
		}
	}
}
