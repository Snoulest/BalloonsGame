using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFullScreen : MonoBehaviour
{
    Image image;
    
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.transform.position = image.transform.parent.position;
    }
}
