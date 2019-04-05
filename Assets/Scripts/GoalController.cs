using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    public GameObject WinningScreen;
    public GameObject HUD;

    private void OnCollisionEnter(Collision collision)
    {
        WinningScreen.SetActive(true);
        HUD.SetActive(false);
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
}
