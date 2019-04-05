using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wormhole : MonoBehaviour
{
    public float WormholeRange = 5;
    public float WormholePull = 0.1f;

    public GameObject GameOverScreen;
    public GameObject HUD;

    private Transform _Player;

    private void Start()
    {
        _Player = Camera.main.transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _Player.position) < WormholeRange)
        {
            Quaternion lRayDirection = Quaternion.LookRotation(_Player.position - transform.position);
            _Player.Translate(lRayDirection * Vector3.forward * WormholePull);
            Debug.Log("Captured by wormhole");
            _Player.GetComponent<CameraController>().Wormhole = this;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameOverScreen.SetActive(true);
        HUD.SetActive(false);
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(0);
    }
}