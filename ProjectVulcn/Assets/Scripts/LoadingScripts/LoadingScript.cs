using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    private Scene loadingScene;
    private float loadingValue = 0f;
    public Image loadingBar;
    bool loadingDone = false;

    private void Update()
    {
        
        if(loadingValue <= 10)
        {
            loadingValue += Time.deltaTime;
            //print("Loading: " + loadingValue);
            loadingBar.fillAmount = loadingValue / 10;
        }
        if(loadingValue >= 10 && !loadingDone)
        {
            SceneManager.LoadScene(1);
            loadingDone= true;
        }

    }


}
