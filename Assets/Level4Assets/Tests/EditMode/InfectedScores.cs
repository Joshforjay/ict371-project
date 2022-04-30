using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InfectedScores
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
    public void InfectedBCell()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[0]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void InfectedCovid()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[1]);
        Assert.AreEqual(-0.25f, score);
    }


    [Test]
    public void InfectedInfected()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[2]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void InfectedKiller()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[3]);
        Assert.AreEqual(1f, score);
    }

    [Test]
    public void InfectedMacrophage()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[4]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void InfectedMuscle()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[5]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void InfectedPlasma()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[6]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void InfectedRed()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[7]);
        Assert.AreEqual(-0.25, score);
    }

    [Test]
    public void InfectedSpike()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[8]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void InfectedTHelper()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[9]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void InfectedVaccine()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[2], objs[10]);
        Assert.AreEqual(-0.25f, score);
    }
}
