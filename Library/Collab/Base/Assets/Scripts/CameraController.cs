using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float AccelSpeed = 0.1f;
    public float TurnSpeed = 0.6f;
    public float FuelCount = 100;
    public Slider FuelSlider;

        private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            Accelerate();
        //if (Input.GetKey(KeyCode.DownArrow))
        //    transform.Translate(Vector3.back * AccelSpeed);        
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, -TurnSpeed, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, TurnSpeed, 0);

        if (SystemInfo.supportsAccelerometer || SystemInfo.supportsGyroscope)
        {
            float lRotation = Mathf.Clamp(Input.acceleration.x, -1, 1);
            transform.Rotate(0, lRotation, 0);
        }
    }

    public void Accelerate()
    {
        if (FuelCount > 0)
        {
            transform.Translate(Vector3.forward * AccelSpeed);
            FuelCount -= 1;
            FuelSlider.value -= 1;
        }
    }
}
