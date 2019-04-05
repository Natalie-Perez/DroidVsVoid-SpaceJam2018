using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    public GameObject IntroScreen;
    public GameObject HUD;
    public GameObject Instructions;

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(20);
        HUD.SetActive(true);
        IntroScreen.SetActive(false);
        yield return new WaitForSeconds(5);
        Instructions.SetActive(false);
        Camera.main.GetComponent<CameraController>().enabled = true;
    }
}
