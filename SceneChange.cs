using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Update is called once per frame
    public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
