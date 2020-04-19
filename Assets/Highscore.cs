using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore.text = "Highscore : " + player.highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
