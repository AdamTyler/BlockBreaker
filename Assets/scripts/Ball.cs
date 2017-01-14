using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    private bool hasStarted = false;

    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
	    paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if(!hasStarted) {
            if (Input.GetMouseButtonUp (0)) {
                print ("mouseup");
                Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();
                rigidbody.velocity = new Vector2 (2f, 10f);
                hasStarted = true;
            }


            this.transform.position = paddle.transform.position + paddleToBallVector;
        }
	}

    void OnCollisionEnter2D (Collision2D collision)
    {

        Vector2 tweak = new Vector2(Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));

        if (hasStarted) {
            AudioSource audio = GetComponent<AudioSource> ();
            audio.volume = 0.2f;
            audio.Play ();

            Rigidbody2D rigidbody = GetComponent<Rigidbody2D> ();
            rigidbody.velocity += tweak;
        }
    }
}
