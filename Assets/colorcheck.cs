using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorcheck : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Green"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Red"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Purple"))
        {
            other.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
