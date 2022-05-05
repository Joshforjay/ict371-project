using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Late Night Radio by Kevin MacLeod
//Link: https://incompetech.filmmusic.io/song/7613-late-night-radio
//License: https://filmmusic.io/standard-license
namespace ICTProject
{
    public class PlayerCollectSpikes : MonoBehaviour
    {
        public int points;

        public Text score;

        public LevelManager levelManager;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            score.text = "Spikes Collected: " + points;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Spike")
            {
                collision.gameObject.GetComponent<RedBLoodCellMove>().DestroySelf();
                levelManager.currentSpikes--;
                points++;
                levelManager.score++;
            }
        }
    }

}

