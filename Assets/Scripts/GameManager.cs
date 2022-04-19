using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Transform Spawn;
    public GameObject Obstacle;
    Text scoreText;
    Text finalScoreText;
    int score;
    public GameObject scoringMenu;
    public GameObject deathMenu;

    void Start()
    {
        Spawn = GameObject.Find("ObstacleSpawn").transform;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        finalScoreText = GameObject.Find("finalScore").GetComponent<Text>();;
        scoringMenu = GameObject.Find("ScoringUI");
        deathMenu = GameObject.Find("RestartMenu");
        deathMenu.SetActive(false);
        Time.timeScale = 1f; 
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
 void OnTriggerEnter(Collider col)
 {
   if(col.gameObject.CompareTag("Obstacle"))
   {
     Destroy(col.gameObject);

     Instantiate(Obstacle, Spawn.position, Spawn.rotation);
     score += 1;
     scoreText.text = score.ToString();
   } 
 }

 public void Lost()
 {
    Time.timeScale = 0f;   
    deathMenu.SetActive(true);
    scoringMenu.SetActive(false);
    finalScoreText.text = score.ToString();
 }

 public void Restart()
 { 
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
 }
}
