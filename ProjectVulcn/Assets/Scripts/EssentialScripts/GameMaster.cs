using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Material skyBox;
    private float shipHealthValue = 50f;

    [Header("Essential GameObjects")]
    [SerializeField] private GameObject scrapWolf;
    [SerializeField] private GameObject scrapPile;
    public Image shipHealth;

    bool gameOver = false;
    bool gauntletIsWorn = false;

    List<GameObject> spawnPoints = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject points in GameObject.FindGameObjectsWithTag("spawn"))
        {
                spawnPoints.Add(points);
        }

       gauntletIsWorn = true;
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
            case 100:
                if (!gameOver)
                {
                    ShipIsRepaired();
                    gameOver = true;
                }
                break;
        }

        if (gauntletIsWorn)
        {
            SpawnWolves();
            gauntletIsWorn=false;
        }
        
    }

    private void SpawnWolves()
    {
        int randomPoint = Random.Range(1, 3);
        int randomWolves = Random.Range(5, 10);

        for(int i = 0; i < randomWolves; i++) {
            Instantiate(scrapWolf, spawnPoints[randomPoint].transform);
        }
        print(randomWolves);

    }


    public void RepairShip()
    {
        shipHealthValue += 5f;
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
    }

    void ShipIsDestroyed()
    {
        print("Booo you lose >:(");
    }



    private void RotateSky()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.3f);
    }
}
