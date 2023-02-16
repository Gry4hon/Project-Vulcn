using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private Material skyBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateSky();
    }


    private void RotateSky()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.3f);
    }
}
