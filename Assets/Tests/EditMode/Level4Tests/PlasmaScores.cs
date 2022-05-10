using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlasmaScores {
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
	public void PlasmaBCell() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[0]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void PlasmaCovid() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[1]);
		Assert.AreEqual(0.5f, score);
	}

	[Test]
	public void PlasmaInfected() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[2]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void PlasmaKiller() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[3]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void PlasmaMacrophage() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[4]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void PlasmaMuscle() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[5]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void PlasmaPlasma() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[6]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void PlasmaRed() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[7]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void PlasmaSpike() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[8]);
		Assert.AreEqual(0.5f, score);
	}

	[Test]
	public void PlasmaTHelper() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[9]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void PlasmaVaccine() {
		Start();
		float score = Level4Controller.matchingPairs(objs[6], objs[10]);
		Assert.AreEqual(-0.5f, score);
	}
}
