using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighestScoreText : MonoBehaviour
{
    void Start()
    {
        GetComponent<TMP_Text>().text = new SaveSystem().read();
    }
}
