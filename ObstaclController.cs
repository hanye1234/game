using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclController : MonoBehaviour
{
    public GameObject[] Obstacles;
    public GameObject background;
    public BackGroundController Obstacleback;
    bool isGeneratecorn=true;
    int cornidx=1;
    int disableidx=100;
    List<int> ActiveObstacles=new List<int>(){};

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<Obstacles.Length;i++){
            Obstacles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGeneratecorn)
        {
            int randomidx=Random.Range(3,5);
            int idx=(cornidx+randomidx) % Obstacles.Length;
            Obstacles[idx].SetActive(true);
            cornidx=idx;
            isGeneratecorn=false;
        }

        if(cornidx==((Obstacleback.Endindex+8) % Obstacles.Length))
        {
            ActiveObstacles.Add(cornidx);
            isGeneratecorn=true;
        }

        if(ActiveObstacles.Contains(Obstacleback.Endindex))
        {
            Obstacles[Obstacleback.Endindex].SetActive(false);
            ActiveObstacles.Remove(Obstacleback.Endindex);
        }
    }
}
