using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Material skyBox;
    private float shipHealthValue = 90f;

    [Header("Essential GameObjects")]
    public Image shipHealth;

    bool gameOver = false;

    // Update is called once per frame
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
