using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instruccion : MonoBehaviour {

    public Button quit;
    public Button start;


	// Use this for initialization
	void Start () {
        quit.onClick.AddListener(Quit);
        start.onClick.AddListener(startTrigger);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Quit() {
        Application.Quit();
    }

    void startTrigger() {
        SceneManager.LoadSceneAsync("Main");
    }
}
