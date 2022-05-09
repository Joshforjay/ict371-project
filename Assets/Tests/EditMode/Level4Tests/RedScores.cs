using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RedScores {
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
	public void RedBloodBCell() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[0]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void RedBloodCovid() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[1]);
		Assert.AreEqual(0.5f, score);
	}

	[Test]
	public void RedBloodInfected() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[2]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void RedBloodKiller() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[3]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void RedBloodMacrophage() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[4]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void RedBloodMuscle() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[5]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void RedBloodPlasma() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[6]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void RedBloodRed() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[7]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void RedBloodSpike() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[8]);
		Assert.AreEqual(0.5f, score);
	}

	[Test]
	public void RedBloodTHelper() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[9]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void RedBloodVaccine() {
		Start();
		float score = Level4Controller.matchingPairs(objs[7], objs[10]);
		Assert.AreEqual(-0.5f, score);
	}
}
