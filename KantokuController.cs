using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KantokuController : MonoBehaviour
{
    float velocity=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<0)
        {
            velocity+=Time.deltaTime;
        }
        else if(transform.position.x>0)
        {
            velocity-=Time.deltaTime;
        }
        
        transform.Translate(new Vector3(velocity, 0,0) * Time.deltaTime);
    }
}
