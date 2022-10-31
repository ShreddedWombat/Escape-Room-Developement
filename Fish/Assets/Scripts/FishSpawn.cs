using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{

    int fishNum;

    int fishType;

    public GameObject fabFish;
    public GameObject fabTrout;
    public GameObject fabCod;
    public GameObject fabSalmon;

    public int pointFish;
    public int pointTrout;
    public int pointCod;
    public int pointSalmon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        fishNum = Random.Range(25, 45);
        for(int i = 0; i < fishNum; i++)
        {
            fishType = Random.Range(1,20);
            if (fishType <= 9)
            {
                Instantiate(fabFish, transform);
            }
            else if (fishType <= 14)
            {
                Instantiate(fabTrout, transform);
            }
            else if (fishType <= 19)
            {
                Instantiate(fabCod, transform);
            }
            else
            {
                Instantiate(fabSalmon, transform);
            }
        }
    }
}
