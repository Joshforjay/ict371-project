using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCellGeneration : MonoBehaviour {
	[SerializeField]
	GameObject bCell;

	// Start is called before the first frame update
	void Start() {}

	// Update is called once per frame
	void Update() {}

	void OnEnable() {
		BloodVesselGeneration.OnSpawnVessel += SpawnBCell;
	}

	void OnDisable() {
		BloodVesselGeneration.OnSpawnVessel -= SpawnBCell;
	}

	void SpawnBCell(int count) {
		for (int i = 0; i < count; i++) {
			Transform lastVessel = FindObjectOfType<BloodVesselGeneration>().GetLastVessel();

			Vector3 spawnPos = Random.insideUnitCircle * 5;
			spawnPos.z = Random.Range(lastVessel.position.z - 10, lastVessel.position.z + 10);

			Instantiate(bCell, spawnPos, Quaternion.identity, lastVessel);
		}
	}
}
