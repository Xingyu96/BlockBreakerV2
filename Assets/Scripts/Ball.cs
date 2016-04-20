using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle;

    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector.y);
	}
	
	// Update is called once per frame
	void Update () {
        //initiate ball on the paddle and following it
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
        }

        //wait for mouse press to launch
        if (Input.GetMouseButton(0) && !hasStarted)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            hasStarted = true;
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        
        if (hasStarted)
        {
            this.GetComponent<Rigidbody2D>().velocity += tweak; 
            this.GetComponent<AudioSource>().Play();
        }
    }

}
