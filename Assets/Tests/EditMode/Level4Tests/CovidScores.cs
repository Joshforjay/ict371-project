using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CovidScores {
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
	public void CovidBCell() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[0]);
		Assert.AreEqual(-1f, score);
	}

	[Test]
	public void CovidCovid() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[1]);
		Assert.AreEqual(-1f, score);
	}

	[Test]
	public void CovidInfected() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[2]);
		Assert.AreEqual(-1f, score);
	}

	[Test]
	public void CovidKiller() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[3]);
		Assert.AreEqual(-1f, score);
	}

	[Test]
	public void CovidMacrophage() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[4]);
		Assert.AreEqual(0.25f, score);
	}

	[Test]
	public void CovidMuscle() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[5]);
		Assert.AreEqual(0.25f, score);
	}

	[Test]
	public void CovidPlasma() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[6]);
		Assert.AreEqual(0.25f, score);
	}

	[Test]
	public void CovidRed() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[7]);
		Assert.AreEqual(0.25, score);
	}

	[Test]
	public void CovidSpike() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[8]);
		Assert.AreEqual(-1f, score);
	}

	[Test]
	public void CovidTHelper() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[9]);
		Assert.AreEqual(-1f, score);
	}

	[Test]
	public void CovidVaccine() {
		Start();
		float score = Level4Controller.matchingPairs(objs[1], objs[10]);
		Assert.AreEqual(-1f, score);
	}
}
