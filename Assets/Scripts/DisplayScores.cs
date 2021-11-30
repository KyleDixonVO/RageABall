using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;

public class DisplayScores : MonoBehaviour
{
    public GameObject parent;
    public TextMeshProUGUI playerScores;

    private void Start()
    {
        string readFromPath = Application.streamingAssetsPath + "/playerScores/" + "highScores" + ".txt";

        string fileLines = File.ReadAllText(readFromPath);

        playerScores.text = fileLines;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (parent.activeInHierarchy == true)
            {
                parent.SetActive(false);
            }
            else
            {
                parent.SetActive(true);
            }
        }
    }
}
