using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnButton : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("MAIN MENU");
    }
}
