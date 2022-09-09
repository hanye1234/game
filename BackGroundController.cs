using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float speed;
    public float initialspeed;
    public int Startindex;
    public int Endindex;
    public Transform[] background;
    public int BackWidth;
    public GameController gameController;

    int maxspeed=25;

    void Start()
    {
        initialspeed=speed;
        speed=gameController.GameSpeed*speed;
        maxspeed=(int)(speed*1.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
        if(speed>=maxspeed)
        {
            speed=maxspeed;
        }
        else
        {
            speed=speed+Time.deltaTime/5.0f;
        }

        transform.Translate(new Vector3(speed, 0,0) * Time.deltaTime);
        if(background[Endindex].transform.position.x>40){
            Vector3 backSpritePos=background[Startindex].GetComponent<RectTransform>().anchoredPosition;
            Vector3 frontSpritePos=background[Endindex].GetComponent<RectTransform>().anchoredPosition;
            background[Endindex].transform.localPosition=backSpritePos+Vector3.left*BackWidth;

            int Startindexsave=Startindex;
            Startindex=Endindex;
            Endindex++;
            if(Endindex>=background.Length)
            {
                Endindex=0;
            }
        }

    }
}


// public class BackGroundController : MonoBehaviour
// {
//     public float speed;
//     public int Startindex;
//     public int Endindex;
//     public Transform[] sprites;

//     // Update is called once per frame
//     void Update()
//     {
//         transform.Translate(new Vector3(speed, 0,0) * Time.deltaTime);
//         if(sprites[Endindex].position.x>20){
//             Vector3 backSpritePos=sprites[Startindex].localPosition;
//             Vector3 frontSpritePos=sprites[Endindex].localPosition;
//             sprites[Endindex].transform.localPosition=backSpritePos+Vector3.left*20;

//             int Startindexsave=Startindex;
//             Startindex=Endindex;
//             Endindex=Startindexsave;
//         }

//     }
// }
