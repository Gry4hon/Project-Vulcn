using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctionallity : Subject
{

    public bool isPressed = false;





    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            NotifyObservingClasses(isPressed);
        }
        else
        {
            NotifyObservingClasses(isPressed);
        }
    }
}
