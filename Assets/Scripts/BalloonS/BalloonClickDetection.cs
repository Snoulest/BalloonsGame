using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class BalloonClickDetection : MonoBehaviour, IPointerClickHandler
{

    LevelSystem levelHolder;
    Points points;

    private void Start()
    {
        levelHolder = GameObject.Find("LevelHolder").GetComponent<LevelSystem>();
        points = GameObject.Find("Text Points").GetComponent<Points>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Balloon")) 
        {
            points.points += 1;

            GetComponent<AudioSource>().Play();

            foreach (Level level in levelHolder.levels)
            {
                if (points.points == level.pointsReq)
                {
                    GetComponent<BalloonSpawning>().waitTime = level.waitTime;
                }
            }

            Destroy(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject);
        }
    }
}
