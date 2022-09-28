using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using TMPro;

public class BalloonClickDetection : MonoBehaviour, IPointerClickHandler
{

    LevelSystem levelHolder;
    Points points;
    public float currentYSpeed;

    private void Start()
    {
        levelHolder = GameObject.Find("LevelHolder").GetComponent<LevelSystem>();
        points = GameObject.Find("Text Points").GetComponent<Points>();

        foreach (Level level in levelHolder.levels)
        {
            if (points.points == level.pointsReq)
            {
                GetComponent<BalloonSpawning>().waitTime = level.waitTime;

                currentYSpeed = level.ySpeed;

                GameObject.Find("Text Level").GetComponent<TMP_Text>().text = level.name;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponent<Stats>().dead) return;

        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Balloon")) 
        {
            points.points += 1;

            GetComponent<AudioSource>().Play();

            foreach (Level level in levelHolder.levels)
            { 

                if (points.points == level.pointsReq)
                {
                    GetComponent<BalloonSpawning>().waitTime = level.waitTime;

                    currentYSpeed = level.ySpeed;

                    GameObject.Find("Text Level").GetComponent<TMP_Text>().text = level.name;
                }

            }

            Destroy(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject);
        }
    }
}
