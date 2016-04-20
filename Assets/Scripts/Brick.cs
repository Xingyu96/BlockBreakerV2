using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    
    private int timesHit;
    private bool isBreakable;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        isBreakable = (this.tag == "breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
        
    }

    void HandleHits()
    {
        int maxHits = hitSprites.Length + 1;
        timesHit++;
        print(timesHit);

        if (this.timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
            
        }
        else
        {
            LoadSprites();
        }
    }


    //TODO Remove this method once we can actually win!
    void simulateWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void LoadSprites(){
        if (hitSprites[timesHit - 1])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
    }
}
