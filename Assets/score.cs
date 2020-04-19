using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    public TextMeshProUGUI result;
    
    // Start is called before the first frame update
    void Start()
    {
        
        result.text = "Score : " + player.scoreakhir.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
