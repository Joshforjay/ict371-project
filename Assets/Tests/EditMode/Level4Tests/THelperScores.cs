using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class THelperScores {
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
	public void THelperBCell() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[0]);
		Assert.AreEqual(0.5f, score);
	}

	[Test]
	public void THelperCovid() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[1]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void THelperInfected() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[2]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void THelperKiller() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[3]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void THelperMacrophage() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[4]);
		Assert.AreEqual(0.5f, score);
	}

	[Test]
	public void THelperMuscle() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[5]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void THelperPlasma() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[6]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void THelperRed() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[7]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void THelperSpike() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[8]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void THelperTHelper() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[9]);
		Assert.AreEqual(-0.5f, score);
	}

	[Test]
	public void THelperVaccine() {
		Start();
		float score = Level4Controller.matchingPairs(objs[9], objs[10]);
		Assert.AreEqual(-0.5f, score);
	}
}
