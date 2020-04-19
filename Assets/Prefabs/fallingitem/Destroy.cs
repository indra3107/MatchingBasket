using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Red"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Green"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Purple"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
