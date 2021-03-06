using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

namespace ICTProject
{
    public class LevelManager : MonoBehaviour
    {
        public SceneController sceneController;

        int difficulty = 1;
        public GameObject redBloodPrefab;
        public GameObject spikeProteinPrefab;

        public TextMeshProUGUI timerText;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI rankText;
        float levelTimer = 45f;
        float actualTime;

        [SerializeField]
        HUDController hc;

        [SerializeField]
        int maxSpikes = 30;
        [SerializeField]
        GameObject[] muscles;

        float timer = 0;
        float spawnTime = 0.2f;
        float emitForce = 1f;
        public int currentSpikes = 0;

        public int score;

        bool levelFinished = false;

        private void OnEnable()
        {
            difficulty = PlayerPrefs.GetInt("difficulty");
        }

        // Start is called before the first frame update
        void Start()
        {
            levelTimer = (levelTimer / (float)difficulty) * 1.5f;
            Debug.Log(levelTimer);
            actualTime = levelTimer;
            //populate the level with initial entities.
            for (int i = 0; i < 100; i++)
            {
                Vector3 pos = new Vector3(Random.Range(-20f, 20f), Random.Range(0.5f, 8f), Random.Range(-20f, 20f));
                GameObject go = Instantiate(redBloodPrefab, pos, Quaternion.identity, transform);
            }
            //keep track of spikes collected. 
            spawnTime = (float)difficulty / 2f;
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer > spawnTime && currentSpikes < maxSpikes)
            {
                GameObject muscle = muscles[Random.Range(0, muscles.Length)];
                Vector3 pos = muscle.transform.position +
                    (muscle.transform.forward * Random.Range(-2f, 2f)) +
                    (muscle.transform.right * Random.Range(-0.5f, 0.5f));
                GameObject go = Instantiate(spikeProteinPrefab, pos, Quaternion.identity, transform);
                go.GetComponent<Rigidbody>().AddForce(muscle.transform.up * emitForce, ForceMode.Impulse);
                timer = 0;
                currentSpikes++;
            }
            if(!levelFinished)
                levelTimer -= Time.deltaTime;
            //timerText.text = "Time Left: " + (int)levelTimer + "s";
            levelTimer = Mathf.Clamp(levelTimer, 0, 9999999);
            hc.set_TLTwo_num(Mathf.Round(levelTimer * 100f) / 100f);
            hc.set_TLitem_1_number(score);
            if (levelTimer <= 0 && !levelFinished)
            {
                EndOfScene();
                levelFinished = true;
            }

        }

        void EndOfScene()
        {
            baseScores bs = new baseScores();
            bs.score = score;
            bs.time = actualTime;
            bs.numCollected = score;
            bs.grade = GetGrade(score, difficulty);
            sceneController.SetLevel1Scores(bs);
            
            string file = Application.persistentDataPath + "/" + "level1data.csv";   //path is 
            //actually just the file name, unless you want a path
            StreamWriter writer = new StreamWriter(file, true);

            writer.Write(System.DateTime.Now.ToString());
            writer.Write(", " + actualTime);
            writer.Write(", " + score);
            writer.Write(", " + bs.grade + "\n");

            Debug.Log(Application.persistentDataPath); //location where it is stored

            writer.Close();
            Debug.Log("End of scene");
            scoreText.text = "Score: " + score;
            rankText.text = "Rank: " + bs.grade;
            sceneController.ShowScoreMenu();
        }

        char GetGrade(int s, int d)
        {
            d = 4 - d;
            if (s * d > 10)
                return 'S';
            if (s * d > 8)
                return 'A';
            if (s * d > 6)
                return 'B';
            if (s * d > 4)
                return 'C';
            if (s * d > 2)
                return 'D';
            if (s * d > 1)
                return 'E';
            return 'F';
        }
	}

}