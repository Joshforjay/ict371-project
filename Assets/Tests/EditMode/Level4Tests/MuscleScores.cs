using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MuscleScores
{
    GameObject[] objs = new GameObject[11];

    GameObject LoadPrefabFromFile(string name)
    {
        var objTwo = Resources.Load("Models/" + name);
        GameObject obj = (GameObject)GameObject.Instantiate(objTwo);

        return obj;
    }

    public void Start()
    {
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
    public void MuscleBCell()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[0]);
        Assert.AreEqual(-(3 / 4f), score);
    }

    [Test]
    public void MuscleCovid()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[1]);
        Assert.AreEqual((1 / 3f), score);
    }


    [Test]
    public void MuscleInfected()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[2]);
        Assert.AreEqual(-(3 / 4f), score);
    }

    [Test]
    public void MuscleKiller()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[3]);
        Assert.AreEqual(-(3 / 4f), score);
    }

    [Test]
    public void MuscleMacrophage()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[4]);
        Assert.AreEqual(-(3 / 4f), score);
    }

    [Test]
    public void MuscleMuscle()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[5]);
        Assert.AreEqual(-(3 / 4f), score);
    }

    [Test]
    public void MusclePlasma()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[6]);
        Assert.AreEqual(-(3 / 4f), score);
    }

    [Test]
    public void MuscleRed()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[7]);
        Assert.AreEqual(-(3 / 4f), score);
    }

    [Test]
    public void MuscleSpike()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[8]);
        Assert.AreEqual((1 / 3f), score);
    }

    [Test]
    public void MuscleTHelper()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[9]);
        Assert.AreEqual(-(3 / 4f), score);
    }

    [Test]
    public void MuscleVaccine()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[5], objs[10]);
        Assert.AreEqual((1 / 3f), score);
    }
}
