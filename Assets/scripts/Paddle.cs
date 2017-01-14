using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {


    public bool autoPlay = false;

    private Ball ball;


    void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (!autoPlay) {
            MoveWithMouse ();
        } else {
            AutoPlay();
        }

	}

    void AutoPlay() {
        float ballPos = ball.transform.position.x;
        ballPos = Mathf.Clamp (ballPos, 0.5f, 15.5f);

        Vector3 pos = new Vector3(ballPos, this.transform.position.y, this.transform.position.y);

        this.transform.position = pos;        
    }

    void MoveWithMouse ()
    {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        mousePosInBlocks = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);

        Vector3 pos = new Vector3(mousePosInBlocks, this.transform.position.y, this.transform.position.y);

        this.transform.position = pos;
    }
}
