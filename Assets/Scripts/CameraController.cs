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
    public bool Accel = false;
    public Wormhole Wormhole;
    public float Speed;
    public Transform Engine;

    private void Update()
    {
        CheckBoost();

        if (Wormhole == null)
            transform.Translate(Vector3.forward * AccelSpeed / 2);
        else
        {
            if (Vector3.Distance(transform.position, Wormhole.transform.position) > Wormhole.WormholePull)
                Wormhole = null;
        }

        if (SystemInfo.supportsAccelerometer || SystemInfo.supportsGyroscope)
        {
            float lRotation = Mathf.Clamp(Input.acceleration.x, -1, 1);
            transform.Rotate(0, lRotation, 0);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(0, -TurnSpeed, 0);
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0, TurnSpeed, 0);
        }

        FuelSlider.value = FuelCount;
    }

    public void CheckBoost()
    {
        if (FuelCount > 0 && Accel)
        {
            transform.Translate(Vector3.forward * AccelSpeed);
            FuelCount -= 0.5f;
            Engine.Rotate(new Vector3(0, 200, 0) * Time.deltaTime);
        }
    }

    public void BoostDown() { Accel = true; }
    public void BoostUp() { Accel = false; }
}
