using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyController : MonoBehaviour {

    public int goalCount = 20;
    private SceneManagement scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) )
        {
            

            this.gameObject.transform.localScale = new Vector2(this.gameObject.transform.localScale.x + 0.5f, this.gameObject.transform.localScale.y + 0.5f);
            if (goalCount % 2 == 0)
            {
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + 5f , this.gameObject.transform.localScale.y );
             }
            else
            {
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x - 5f, this.gameObject.transform.localScale.y );
            }
            goalCount--;
        }

        if(goalCount == 0)
        {
            scene = FindObjectOfType<SceneManagement>();
            scene.LoadGameScene();
        }     

	}
}
