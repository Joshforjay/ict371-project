using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungCellSpawner : MonoBehaviour
{
    public static int numberOfObjects = 1;
    public GameObject infectLungParticle;


    void Start()
    {

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        var hash = new HashSet<int>();
        Debug.Log("Vertice size: " + mesh.vertices.Length + "\n");

   
        for (int i = 0; i < numberOfObjects; ++i)
        {
            int num = Random.Range(0, vertices.Length - 1);
            if(vertices[num].y <= 50)
                hash.Add(num);
            else
                i--;
        }

        foreach (int j in hash)
        {
            GameObject infectedCell = Instantiate(infectLungParticle, vertices[j], Quaternion.identity);
        }
    }
}
