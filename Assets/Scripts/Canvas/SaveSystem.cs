using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    string path;

    public void save()
    {
        path = "./SaveFile.txt";

        if (File.Exists(path))
        {
            File.WriteAllText(path, "HighestScore: " + GameObject.Find("Text Points").GetComponent<Points>().highestScore.ToString());
        }
    }
    
    public string read()
    {
        path = "./SaveFile.txt";

        if (File.Exists(path))
        {
            var points = File.ReadAllText(path);

            return points;
        }

        return "Something Went Wrong When Trying To Read The File.";
    }

    public void createFile()
    {
        path = "./SaveFile.txt";

        if (File.Exists(path)) return;

        File.Create(path);
    }
}
