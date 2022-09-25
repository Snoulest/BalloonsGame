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

            GetComponent<AudioSource>().Play();

            Destroy(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject);
        }
    }
}
