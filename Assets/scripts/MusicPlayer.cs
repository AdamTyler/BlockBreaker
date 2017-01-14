using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    void Awake ()
    {
        if (instance != null) {
            Destroy (gameObject);
            print ("dupe destroy");
        } else {
            GameObject.DontDestroyOnLoad (gameObject);
            instance = this;
        }
    }
  
	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
