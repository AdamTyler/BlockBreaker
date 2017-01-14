using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public AudioClip track;

    private int timesHit;
    private LevelManager levelManager;
    public static int numBricks = 0;

	// Use this for initialization
	void Start ()
    {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager> ();
        if (this.tag == "breakable") {
            numBricks++;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D (Collision2D collision)
    {
        AudioSource.PlayClipAtPoint (track, transform.position, 0.2f);
        bool isBreakable = (this.tag == "breakable");
        if (isBreakable) {
            HandleHits ();
        }
 
    }

    void HandleHits ()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits) {
            numBricks--;
            Destroy (gameObject);

            levelManager.BrickDestroyed ();

        } else {
            LoadSprites();
        }
    }

    void LoadSprites ()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites [spriteIndex]) {
            this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
        }

    }

}
