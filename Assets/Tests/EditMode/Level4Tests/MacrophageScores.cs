using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MacrophageScores {
	GameObject[] objs = new GameObject[11];

	GameObject LoadPrefabFromFile(string name) {
		var objTwo = Resources.Load<GameObject>("Models/" + name);
		GameObject obj = Object.Instantiate(objTwo);

		return obj;
	}

	public void Start() {
		objs[0] = LoadPrefabFromFile("B cell");
		objs[1] = LoadPrefabFromFile("COVID-19");
		objs[2] = LoadPrefabFromFile("Infected Cell");
		objs[3] = LoadPrefabFromFile("Killer memory cell");
		objs[4] = LoadPrefabFromFile("Macrophage");
		objs[5] = LoadPrefabFromFile("Muscle Cell");
		objs[6] = LoadPrefabFromFile("Plasma Cell");
		objs[7] = LoadPrefabFromFile("RedBloodCell");
		objs[8] = LoadPrefabFromFile("Spike");
		objs[9] = LoadPrefabFromFile("T Helper Cell");
		objs[10] = LoadPrefabFromFile("Vaccine");
	}

	[Test]
	public void MacrophageBCell() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[0]);
		Assert.AreEqual(-(3 / 4f), score);
	}

	[Test]
	public void MacrophageCovid() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[1]);
		Assert.AreEqual((1 / 3f), score);
	}

	[Test]
	public void MacrophageInfected() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[2]);
		Assert.AreEqual(-(3 / 4f), score);
	}

	[Test]
	public void MacrophageKiller() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[3]);
		Assert.AreEqual(-(3 / 4f), score);
	}

	[Test]
	public void MacrophageMacrophage() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[4]);
		Assert.AreEqual(-(3 / 4f), score);
	}

	[Test]
	public void MacrophageMuscle() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[5]);
		Assert.AreEqual(-(3 / 4f), score);
	}

	[Test]
	public void MacrophagePlasma() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[6]);
		Assert.AreEqual(-(3 / 4f), score);
	}

	[Test]
	public void MacrophageRed() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[7]);
		Assert.AreEqual(-(3 / 4f), score);
	}

	[Test]
	public void MacrophageSpike() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[8]);
		Assert.AreEqual((1 / 3f), score);
	}

	[Test]
	public void MacrophageTHelper() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[9]);
		Assert.AreEqual((1 / 3f), score);
	}

	[Test]
	public void MacrophageVaccine() {
		Start();
		float score = Level4Controller.matchingPairs(objs[4], objs[10]);
		Assert.AreEqual(-(3 / 4f), score);
	}
}
