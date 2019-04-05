using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelUp : MonoBehaviour
{
    public float maxDistanceFromPlanet;

    private Transform _Player;

    void Start()
    {
        _Player = Camera.main.transform;       
    }

    // Update is called once per frame
    void Update()
    {
        float planetDistance = Vector3.Distance(transform.position, _Player.position);

        // If within certain distance of planet then fuel will go to max fill.
        if(planetDistance < maxDistanceFromPlanet)
        {            
            // Fuel up. Change count back to 100
            Camera.main.GetComponent<CameraController>().FuelCount = 100;
            // update slider to be filled 100% again
            Camera.main.GetComponent<CameraController>().FuelSlider.value = 100;
        }

        // Do this code in CameraController.cs
        // Deplete fuel while traveling (Spacebar/on-screen buttin will be the way to accelerate)
        // When pressing spacebar, fuel amount goes down.
        // lower FuelSlider.value to deplete fuel
        // Fuel should update when traveling to planet.
    }
}
