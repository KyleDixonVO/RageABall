using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CheckFiles : MonoBehaviour
{
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/playerScores/");
        CreateHighScoreFile();
    }

    public void CreateHighScoreFile()
    {
        string fileName = Application.streamingAssetsPath + "/playerScores/" + "highScores" + ".txt";

        if (!File.Exists(fileName))
        {
            File.WriteAllText(fileName, "Player High Scores");
        }
    }
}
