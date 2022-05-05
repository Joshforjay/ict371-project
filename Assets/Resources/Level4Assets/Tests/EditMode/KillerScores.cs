using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class KillerScores
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
    public void KillerBCell()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[0]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void KillerCovid()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[1]);
        Assert.AreEqual(-0.25f, score);
    }


    [Test]
    public void KillerInfected()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[2]);
        Assert.AreEqual(1f, score);
    }

    [Test]
    public void KillerKiller()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[3]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void KillerdMacrophage()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[4]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void KillerMuscle()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[5]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void KillerPlasma()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[6]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void KillerRed()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[7]);
        Assert.AreEqual(-0.25, score);
    }

    [Test]
    public void KillerSpike()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[8]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void KillerTHelper()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[9]);
        Assert.AreEqual(-0.25f, score);
    }

    [Test]
    public void KillerVaccine()
    {
        Start();
        float score = Level4Controller.matchingPairs(objs[3], objs[10]);
        Assert.AreEqual(-0.25f, score);
    }
}
