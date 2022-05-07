using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCellGeneration : MonoBehaviour {
	public int spawnCount;

	[SerializeField]
	GameObject bCell;

	[SerializeField]
	GameObject covid;

	// Start is called before the first frame update
	void Start() {}

	// Update is called once per frame
	void Update() {}

	void OnEnable() {
		BloodVesselGeneration.OnSpawnVessel += SpawnCells;
	}

	void OnDisable() {
		BloodVesselGeneration.OnSpawnVessel -= SpawnCells;
	}

	void SpawnCells() {
		Transform lastVessel = FindObjectOfType<BloodVesselGeneration>().GetLastVessel();

		for (int i = 0; i < spawnCount; ++i) {
			Vector3 bCellPos;
			Vector3 covidPos;

			do {
				bCellPos.x = Random.Range(-1, 2);
				bCellPos.y = -1.5f;
				bCellPos.z = Random.Range(lastVessel.position.z - 10, lastVessel.position.z + 10);

				covidPos.x = Random.Range(-1, 2);
				covidPos.y = -1.5f;
				covidPos.z = Random.Range(lastVessel.position.z - 10, lastVessel.position.z + 10);
			} while (isClose(bCellPos, covidPos));

			Instantiate(bCell, bCellPos, Quaternion.identity, lastVessel);
			Instantiate(covid, covidPos, Quaternion.identity, lastVessel);
		}
	}

	bool isClose(Vector3 pos1, Vector3 pos2) {
		return Vector3.Distance(pos1, pos2) <= 2.0f;
	}
}
