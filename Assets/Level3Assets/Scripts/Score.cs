using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private LungCellSpawner lungCount = new LungCellSpawner();
    public SceneController sceneController;
    public Text displayText1, displayText2;
    public static int infectedCellsLeft;
    private float elapsedTime = 0;
    private bool endLevel = true;

    void Start()
    {
        infectedCellsLeft = LungCellSpawner.numberOfObjects;
    }

    // Update is called once per frame
    void Update()
    {
        if (infectedCellsLeft != 0)
            elapsedTime += Time.deltaTime;
        else if(endLevel)
        {
            sceneController.ShowScoreMenu();
            endLevel = false;
        }
         

        displayText1.text = "Time: " + elapsedTime.ToString();
        displayText2.text = "Remaining infected cells: " + infectedCellsLeft.ToString();
            
    }

}
