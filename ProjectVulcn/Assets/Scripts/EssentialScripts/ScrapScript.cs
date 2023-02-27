using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapScript : MonoBehaviour
{
    Vector3 scrapLocation;
    Quaternion scrapRotation;

    public GameObject defenseGolmn;
    public GameObject repairGolmn;

    private void Start()
    {
        scrapLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        scrapRotation = Quaternion.identity;
    }

    public void SpawnRGolem()
    {
        Instantiate(repairGolmn, scrapLocation, scrapRotation);
        Destroy(this.gameObject);
    }

    public void SpawnDGolem()
    {
        Instantiate(defenseGolmn, scrapLocation, scrapRotation);
        Destroy(this.gameObject);
    }



}
