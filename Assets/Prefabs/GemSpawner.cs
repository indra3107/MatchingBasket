using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField]// agar private bisa diganti melalui inspector
    private float xlimit;// wilayah jatuhnya item
    [SerializeField]
    private float[] xPosition;
    [SerializeField]
    private Wave[] wave;

    private float currentTime;

    List<float> remainingPos = new List<float>();
    private int waveIndex;
    private float xPos;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        remainingPos.AddRange(xPosition);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            SelectWave();
        }
        
    }

    void Spawn(float xPos)
    {
        int r = Random.Range(0, 3);
        string itemName = "";
        if(r == 0)
        {
            itemName = "object_0";
        }
        else if (r == 1)
        {
            itemName = "object_2";
        }
        else if (r == 2)
        {
            itemName = "object_3";
        }

        GameObject items = pooling.instance.GetPoolObjects(itemName);
        items.transform.position = new Vector3(xPos, transform.position.y, 0);
        items.SetActive(true);
    }

    void SelectWave()
    {
        remainingPos = new List<float>();
        remainingPos.AddRange(xPosition);

        waveIndex = Random.Range(0, wave.Length);

        currentTime = wave[waveIndex].delayTime;

        if(wave[waveIndex].SpawnAmount == 1)
        {
            xPos = Random.Range(-xlimit, xlimit);
        }
        else if(wave[waveIndex].SpawnAmount > 1)
        {
            rand = Random.Range(0, remainingPos.Count);
            xPos = remainingPos[rand];
            remainingPos.RemoveAt(rand);
        }

        for (int i = 0; i < wave[waveIndex].SpawnAmount; i++)
        {
            Spawn(xPos);
            rand = Random.Range(0, remainingPos.Count);
            xPos = remainingPos[rand];
            remainingPos.RemoveAt(rand);
        }
    }
}

[System.Serializable]
public class Wave
{
    public float delayTime;
    public float SpawnAmount;
}