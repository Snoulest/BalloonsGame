using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathZone : MonoBehaviour
{
    public GameObject deathScreen;

    private void Start()
    {
        GameObject.Find("Text Health").GetComponent<TMP_Text>().text = "Health: " + GetComponentInParent<Stats>().health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponentInParent<Stats>().dead)
        {
            if (GameObject.Find("Text Points").GetComponent<Points>().points > GameObject.Find("Text Points").GetComponent<Points>().highestScore)
            {
                GameObject.Find("Text Points").GetComponent<Points>().highestScore = GameObject.Find("Text Points").GetComponent<Points>().points;
                new SaveSystem().save();
            }

            return;
        }

        GameObject.Find("Text Health").GetComponent<TMP_Text>().text = "Health: " + (GetComponentInParent<Stats>().health - 1).ToString();

        Destroy(collision.gameObject);
        GetComponentInParent<Stats>().health -= 1;

        if (GetComponentInParent<Stats>().health <= 0) { GetComponentInParent<Stats>().dead = true; deathScreen.SetActive(true); }
    }
}
