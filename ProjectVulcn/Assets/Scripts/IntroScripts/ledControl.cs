using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ledControl : MonoBehaviour, IObserver
{
    [SerializeField] private Subject buttonControl;

    private GameObject ledBulb;
    private Material ledMaterial;

    // Start is called before the first frame update
    void Start()
    {
        ledBulb = this.gameObject;
        ledMaterial = ledBulb.GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        buttonControl.AddObservingClass(this);
    }

    private void OnDisable()
    {
        buttonControl.RemoveObservingClass(this);
    }

    public void NotifyClass(bool buttonPressed)
    {
        if(buttonPressed)
        {
            if(ledBulb.name == "One")
            {
                ledMaterial.color= Color.green;
            }

            if(ledBulb.name == "Zero")
            {
                ledMaterial.color= Color.grey;
            }
        }
        else
        {
            if (ledBulb.name == "One")
            {
                ledMaterial.color = Color.grey;
            }

            if (ledBulb.name == "Zero")
            {
                ledMaterial.color = Color.red;
            }
        }

    }
}
