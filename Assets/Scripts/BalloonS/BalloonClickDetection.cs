using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class BalloonClickDetection : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Balloon")) 
        {
            GameObject.Find("Text Points").GetComponent<Points>().points += 1;

            var levels = GameObject.Find("LevelHolder").GetComponent<LevelHolder>().levels;

            foreach (LevelUpSystem level in levels)
            {
                if (checkpoints(level))
                {
                    GetComponent<BalloonSpawning>().waitTime = level.waitTime;
                }
            }

            GetComponent<AudioSource>().Play();

            Destroy(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject);
        }
    }

    bool checkpoints(LevelUpSystem lev)
    {
        if (lev.pointsReq == GetComponent<Points>().points) { return true; }

        return false;
    }
}
