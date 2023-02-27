using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Material skyBox;
    private float shipHealthValue = 5f;

    [Header("Essential GameObjects")]
    [SerializeField] private GameObject scrapWolf;
    [SerializeField] private GameObject scrapPile;

    [Header("UI Elements")]
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Image shipHealth;

    bool gameOver = false;
    public bool startSpawning = false;
    bool newWave = false;

    int newSpawnPoint = 0;
    int numOfWolves = 5;

    bool twentyFiveReached = false;
    bool fiftyReached = false;
    bool seventyFiveReached = false;

   List<GameObject> spawnPoints = new List<GameObject>();
   List<GameObject> enemyList = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject points in GameObject.FindGameObjectsWithTag("spawn"))
        {
                spawnPoints.Add(points);
        }

        shipHealth.enabled = false;
    }

    void Update()
    {
        RotateSky();

        switch (shipHealthValue)
        {
            case 0:
                if (!gameOver)
                {
                    ShipIsDestroyed();
                    gameOver = true;
                }
                break;

            case 25:
                if (!twentyFiveReached)
                {
                    print("Start Spawning More Wolves");
                    numOfWolves = 10;
                    twentyFiveReached= true;
                }
                break;

            case 50:

                if (!fiftyReached)
                {
                    print("Start Spawning at another Point, and start spawning even more wolves");
                    newSpawnPoint = 1;
                    numOfWolves = 15;
                    fiftyReached= true;
                }
                break;

            case 75:
                if (!seventyFiveReached)
                {
                    print("Start Spawning at all 3 points, and start spawning EVEN MORE wolves!");
                    newSpawnPoint = 2;
                    numOfWolves = 20;
                    seventyFiveReached= true;
                }
                break;

            case 100:
                if (!gameOver)
                {
                    ShipIsRepaired();
                    gameOver = true;
                }
                break;
        }

        if (newWave && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            print("I will only exacute if there was enemies that have been killed after the gauntlet was picked up");
            newWave = false;
            enemyList.Clear();
            startSpawning = true;
        }

        if (startSpawning)
        {
            SpawnWolves();
            shipHealth.enabled = true;
            newWave = true;
            if (GameObject.FindGameObjectsWithTag("Enemy") != null)
            {
                foreach (GameObject enemies in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    enemyList.Add(enemies);
                }
            }

            for(int s = 0; s < 5; s++)
            {
                float newX = Random.Range(-6f, 15f);
                float newZ = Random.Range(-25f, 25f);
                float newRotaion = Random.Range(0f, 360f);
                Vector3 newScrapPileLoc = new Vector3(newX, 0f, newZ);
                scrapPile.transform.eulerAngles = new Vector3(scrapPile.transform.eulerAngles.x, scrapPile.transform.eulerAngles.y + newRotaion, scrapPile.transform.eulerAngles.z);
                Instantiate(scrapPile, newScrapPileLoc, scrapPile.transform.rotation);
            }

            startSpawning = false;
        }
        
    }

    private void SpawnWolves()
    {
        int randomPoint = Random.Range(0, newSpawnPoint);

        for(int i = 0; i < numOfWolves; i++) {
            Instantiate(scrapWolf, spawnPoints[randomPoint].transform.position, Quaternion.identity);
        }

    }

    public void RepairShip()
    {
        shipHealthValue += 1f;
        shipHealth.fillAmount = shipHealthValue / 100;
    }

    public void DamageShip()
    {
        shipHealthValue -= 5f;
        shipHealth.fillAmount = shipHealthValue / 100;
    }
    void ShipIsRepaired()
    {
        print("Congrats you win!");
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        shipHealth.enabled = false;
    }

    void ShipIsDestroyed()
    {
        print("Booo you lose >:(");
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
        shipHealth.enabled = false;
    }

    private void RotateSky()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.3f);
    }
}
