using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**  
 Author: Sanders
 Description: Loads the scenes n shit
*/



public class SceneManagement : MonoBehaviour {

    private ArrayList gameScenes;
    
    public void GetGameScenes()
    {
        
        Debug.Log(SceneManager.GetSceneByPath("Assets/_Scenes/GameScenes"));
    }

    //loads a scene using a random array of the scenes
	public void LoadGameScene(string name)
    {
        Debug.Log("Scene loaded was : " + name);
        SceneManager.LoadScene(name);
        GetGameScenes();
    }

    //will only work in production. Wont work in editor
    public void QuitRequest()
    {
        Application.Quit();
    }

}
