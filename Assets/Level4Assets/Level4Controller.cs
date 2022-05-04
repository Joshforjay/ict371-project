using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Controller : MonoBehaviour
{
    public GameObject[] gameObjects;
    public SceneController sceneController;
    public Transform centerPointOfSpawn;
    public float zDistTillOutOfView = 1;
    public float xDistTillOutOfView = 1;
    public float timeBetweenSpawning;
    public int maxSpawned = 10;
    public float forceMagnitude = 1;
    public float levelTimeLimit = 60;
    public GamepadCursor gpc;

    static private float oldTime = 0;
    static public List<GameObject> currentlyCreatedObjects = new List<GameObject>();
    static private List<float> timeOfCreation = new List<float>();
    static private int countObjects = 0;
    private float startTime;
    private int[] objOfEachType;
    private int lastSide = 10;
    private bool end = false;
    static private level4Scores l4;

    [SerializeField]
    private GameObject HUD;
    [SerializeField]
    private GameObject StartOBJ;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        objOfEachType = new int[gameObjects.Length];

        l4.numberEscaped = 0;
        l4.correctMatches = 0;
        l4.incorrectMatches = 0;
        l4.baseScores.numCollected = 0;
        l4.baseScores.score = 0;
        l4.baseScores.time = levelTimeLimit;

        HUD.SetActive(false);
        StartOBJ.SetActive(true);

        
        

    }

    // Update is called once per frame
    void Update()
    {
        StartController start = StartOBJ.transform.GetChild(0).GetComponent<StartController>();
        if(!start.is_active())
        {
            return;
        }
        
        hud_update();

        if (Time.time - startTime > levelTimeLimit)
        {
            if (!end)
            {
                end = true;
                for (int count = 0; count < currentlyCreatedObjects.Count; count++)
                {
                    Destroy(currentlyCreatedObjects[count]);
                }
                sceneController.ShowScoreMenu();
                scoreFinishing();

            }

        }
        else if (oldTime < Time.time - timeBetweenSpawning && countObjects < maxSpawned)
        {
            oldTime = Time.time;
            createNewObject();
        }

        if (!end) { checkExistingObjects(); }
        
    }

    private void hud_update()
    {
        if (!HUD.activeSelf)
        {
            startTime = Time.time;
            HUD.SetActive(true);
        }

        HUDController hud = HUD.transform.GetChild(0).GetComponent<HUDController>();
        hud.set_TLitem_1_number(l4.baseScores.score);
        float timeLeft = levelTimeLimit - (Time.time - startTime);
        if(timeLeft < 0) { timeLeft = 0; }
        hud.set_TLitem_2_number(timeLeft);
    }

    void createNewObject()
    {
        Vector3 spawnLoc = new Vector3(0f, 1f, 0f);
        int side = Random.Range(0, 4); //Chooses which side to spawn
        float section = 1;

        while(side == lastSide) { side = Random.Range(0, 4); }
        lastSide = side;


        //Choose position to spawn object
        if (side == 0 || side == 1) { section = Random.Range(-zDistTillOutOfView, zDistTillOutOfView); }
        else{ section = Random.Range(-xDistTillOutOfView, xDistTillOutOfView); }

        

        //Sets spawn location
        if (side == 0) { spawnLoc.x = section; spawnLoc.z = xDistTillOutOfView; }
        if (side == 1) { spawnLoc.x = section; spawnLoc.z = -xDistTillOutOfView; }
        if (side == 2) { spawnLoc.x = zDistTillOutOfView; spawnLoc.z = section; }
        if (side == 3) { spawnLoc.x = -zDistTillOutOfView; spawnLoc.z = section; }

        //Creates object
        int choosenObject = chooseObjectToCreate();
        GameObject newObject = Instantiate(gameObjects[choosenObject], spawnLoc, Quaternion.identity);

        //Set name //i.e. remove (clone)
        int nameEndIndex = newObject.name.IndexOf('(');
        newObject.name = newObject.name.Substring(0, nameEndIndex);

        //Adds force
        addForceTowardsCenter(newObject);

        
        currentlyCreatedObjects.Add(newObject);
        timeOfCreation.Add(Time.time);
        countObjects++;
    }

    void addForceTowardsCenter(GameObject newObject)
    {
        Vector3 force = new Vector3(0f, 0f, 0f);

        //Get distance and angle of a point from the center of the spawn location
        float angle = Random.Range(0f, 360f);
        float distance = 1;
        if (xDistTillOutOfView < zDistTillOutOfView) { distance = xDistTillOutOfView; }
        else { distance = zDistTillOutOfView; }
        distance = distance * 3 / 4;

        //Get point the new object will travel towards
        Vector3 point = centerPointOfSpawn.position;
        int xDir = 1;
        if (angle > 90 && angle < 180) { xDir = -1; }
        int zDir = 1;
        if (angle > 180) { zDir = -1; }
        point.x = point.x + distance * Mathf.Sin(angle%90) * xDir;
        point.z = point.z + distance * Mathf.Cos(angle % 90) * zDir;

        //Get force vector
        force.x = point.x - newObject.transform.position.x;
        force.z = point.z - newObject.transform.position.z;
        force.Normalize();

        //Add force to object
        newObject.GetComponent<Rigidbody>().AddForce(force * forceMagnitude, ForceMode.Impulse);
    }

    void checkExistingObjects()
    {
        Vector3 pos = new Vector3( 0f, 0f, 0f);

        int size = currentlyCreatedObjects.Count;
        for(int count = 0; count < size; count++) //Loops through objects in scene
        {
            pos = currentlyCreatedObjects[count].transform.position;
            if(!testIfInbounds(pos))
            {
                //If the object has been alive 4 seconds then delete.
                if (Time.time - timeOfCreation[count] > 4)
                {
                    destroyObject(count);
                    l4.numberEscaped++;
                    count--;
                    size--;
                }
            }
        }

    }

    bool testIfInbounds(Vector3 pos)
    {
        if ((pos.x > xDistTillOutOfView + 5 || pos.x < -xDistTillOutOfView - 5)
                || (pos.z > zDistTillOutOfView + 5 || pos.z < -zDistTillOutOfView - 5))
        {
            return false;
        }
        return true;
    }

    static void destroyObject(int count)
    {
        GameObject go = currentlyCreatedObjects[count];
        currentlyCreatedObjects.RemoveAt(count);
        timeOfCreation.RemoveAt(count);
        Debug.Log("Object " + go.name + " deleted");
        Destroy(go, 0);
        countObjects--;
    }

    int chooseObjectToCreate()
    {
        int choosenObject, avd = 0;
        while(true)
        {
            choosenObject = Random.Range(0, gameObjects.Length);

            for(int count = 0; count < gameObjects.Length; count++)
            {
                avd = avd + objOfEachType[count];
            }
            avd = avd / gameObjects.Length + 1;

            if(objOfEachType[choosenObject] < avd) { break; }
        }

        objOfEachType[choosenObject] += 1;
        return choosenObject;
    }

    static public void collisionResolution(GameObject obj, GameObject objTwo)
    {
        int index = currentlyCreatedObjects.IndexOf(obj);
        float score = matchingPairs(obj, objTwo);
        int d = PlayerPrefs.GetInt("difficulty");
        if(d == 1) { score = score * 1.5f; }
        else if (d == 2) { score = score * 1.25f; }

        l4.baseScores.score = l4.baseScores.score + score;
        destroyObject(index);
        Debug.Log("Score: " + score);

        GameObject soundObject = GameObject.Find("soundEffects");
        soundEffects sEFX = soundObject.GetComponent<soundEffects>();
        if(score > 0)
        {
            l4.correctMatches++;
            sEFX.playCorrect();
        }
        else
        {
            l4.incorrectMatches++;
            sEFX.playIncorrect();
        }

    }
    
    
    static public float matchingPairs(GameObject obj, GameObject objTwo)
    {
        float score = 1f;

        if (obj.tag == "Covid" || obj.tag == "Spike")
        {
            if (objTwo.tag == "Macrophage" || objTwo.tag == "Muscle" || objTwo.tag == "Plasma" || objTwo.tag == "RedBloodCell"){ score /= 4; }
            else { score = score * -1; }
        }
        else if (obj.tag == "RedBloodCell" || obj.tag == "Plasma")
        {
            if (objTwo.tag == "Covid" || objTwo.tag == "Spike") { score /= 2; }
            else { score = score * -1 / 2; }
        }
        else if (obj.tag == "InfectedCell")
        {
            if (objTwo.tag == "KillerMemory") { score /= 1; }
            else { score = score * -1 / 4; }
        }
        else if (obj.tag == "KillerMemory")
        {
            if (objTwo.tag == "InfectedCell") { score /= 1; }
            else { score /= -4; }
        }
        else if (obj.tag == "Macrophage")
        {
            if (objTwo.tag == "Covid" || objTwo.tag == "THelper" || objTwo.tag == "Spike") { score /= 3; }
            else { score = score * -3 / 4; }
        }
        else if (obj.tag == "Muscle")
        {
            if (objTwo.tag == "Covid" || objTwo.tag == "Vaccine" || objTwo.tag == "Spike") { score /= 3; }
            else { score = score * -3 / 4; }
        }
        else if (obj.tag == "Vaccine")
        {
            if (objTwo.tag == "Muscle") { score /= 1; }
            else { score /= -4; }
        }
        else if (obj.tag == "THelper")
        {
            if (objTwo.tag == "BCell" || objTwo.tag == "Macrophage") { score /= 2; }
            else { score /= -2; }
        }
        else if (obj.tag == "BCell")
        {
            if (objTwo.tag == "THelper") { score /= 1; }
            else { score /= -4; }
        }

        return score;
    }
    
    public float getScore()
    {
        return l4.baseScores.score;
    }
    
    public float getlevelTimeLimit()
    {
        return levelTimeLimit;
    }

    private void scoreFinishing()
    {
        outputCollectedData oCD = new outputCollectedData();
        oCD.outputData("level4Data.txt", l4);
    }

}
