using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**  
 Author: Sanders
 Description: Loads the scenes n shit
*/

public class SceneManagement : MonoBehaviour {

    //loads a scene using a random array of the scenes
	public void LoadGameScene(string name)
    {
        Debug.Log("Scene loaded was : " + name);
        SceneManager.LoadScene(name);
    }

    //will only work in production. Wont work in editor
    public void QuitRequest()
    {
        Application.Quit();
    }

}
