using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionManager : MonoBehaviour
{
    public string winScene;
    public string loseScene;
    public GameObject mCloud;
    public GameObject mEnd;
    public GameObject[] wallCol = new GameObject[4];

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == mEnd)
        {
            SceneManager.LoadScene(winScene);
        }
        if (collision.gameObject == mCloud)
        {
            SceneManager.LoadScene(loseScene);
        }
        for (int i = 0; i < wallCol.Length; i++)
        {
            if (collision.gameObject == wallCol[i])
            {
                SceneManager.LoadScene(loseScene);
            }
        }
    }


}
