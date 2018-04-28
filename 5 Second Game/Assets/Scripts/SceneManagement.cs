using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 Author: Sanders, Dylan did not help at all. for real tho. kid did nothing. LIke absolutely no hepl whatsoever. 
 Description: Loads the scenes n shit
*/

public class SceneManagement : MonoBehaviour
{

    private ArrayList gameScenes;
    private int scenesLoadedCount = 0;

    //loads a scene using a random array of the scenes
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadGameScene()
    {
        Debug.Log("Scene loaded was : " + name);
        if (scenesLoadedCount == 0)
        {
            SceneManager.LoadScene("TUTORIAL");
            scenesLoadedCount++;
        }
        else
        {
            SceneManager.LoadScene(Random.Range(2, SceneManager.sceneCount));
        }
        scenesLoadedCount++;
    }

    //will only work in production. Wont work in editor
    public void QuitRequest()
    {
        Application.Quit();
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        LoadGameScene();

    }
}