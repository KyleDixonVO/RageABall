using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Scorekeeper : MonoBehaviour
{
    public static int totalDeaths;
    //[MenuItem("Tools/Write file")]
    public static void WriteToFile()
    {
        string path = Application.persistentDataPath + "/highScores.txt";

        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine(Time.realtimeSinceStartup + "Deaths: " + totalDeaths);

        writer.Close();

        StreamReader reader = new StreamReader(path);

        //AssetDatabase.ImportAsset(path);

        //TextAsset asset = Resources.Load("highScores");

        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

    //[MenuItem("Tools/Read file")]
   public static void ReadFile()
   {
        string path = Application.persistentDataPath + "/highScores.txt";
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
   }
}
