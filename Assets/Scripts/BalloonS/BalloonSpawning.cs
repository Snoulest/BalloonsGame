using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawning : MonoBehaviour
{
    public bool spawned;
    public float waitTime;

    [SerializeField] GameObject balloonTemplate;

    private void Start()
    {
        spawned = true;
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
        balloon.transform.parent = GameObject.Find("Game Canvas").transform;

        yield return new WaitForSeconds(waitTime);

        spawned = true;
    }   
}
