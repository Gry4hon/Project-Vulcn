using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    private float loadingValue = 0f;
    public Image loadingBar;
    bool loadingDone = false;
    int randomLoadTime;

    private void Start()
    {
        Time.timeScale = 1f;
        randomLoadTime = Random.Range(5, 10);
    }

    private void Update()
    {
        if(loadingValue <= randomLoadTime)
        {
            loadingValue += Time.deltaTime;
            loadingBar.fillAmount = loadingValue / randomLoadTime;
        }
        if(loadingValue >= randomLoadTime && !loadingDone)
        {
            SceneManager.LoadScene(1);
            loadingDone= true;
        }

    }


}
