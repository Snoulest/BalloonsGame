using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    void Awake()
    {
        new SaveSystem().createFile();       
    }
}
