using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCreationManager : MonoBehaviour
{

    GolemCreationSetter creationSetter;

    public GolemCreationState creationState = new GolemCreationState();
    public ScrapState scrapState = new ScrapState();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        creationSetter.RunCurrentState(this);
    } 
}
