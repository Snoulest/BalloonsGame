using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawning : MonoBehaviour
{
    public bool spawned;
    public float waitTime;
    LevelSystem levelHolder;
    Points points;

    [SerializeField] GameObject balloonTemplate;

    private void Start()
    {
        spawned = true;

        levelHolder = GameObject.Find("LevelHolder").GetComponent<LevelSystem>();
        points = GameObject.Find("Text Points").GetComponent<Points>();
    }

    private void Update()
    {
        if (spawned)
        {
            StartCoroutine(spawning());
            spawned = false;
        }
    }

    private IEnumerator spawning()
    {
        GameObject canvas = GameObject.Find("Game Canvas");

        float xPos = Random.Range(0, canvas.transform.position.x * 2);

        var balloon = Instantiate(balloonTemplate, new Vector3(xPos, 0, 1), balloonTemplate.transform.rotation);
        balloon.transform.parent = canvas.transform;
        balloon.GetComponent<BalloonMovement>().ySpeed = GetComponent<BalloonClickDetection>().currentYSpeed;

        yield return new WaitForSeconds(waitTime);

        spawned = true;
    }
}
