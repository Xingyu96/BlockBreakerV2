using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
    public bool autoPlay = false;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
	}

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1.3f, 14.7f);
        this.transform.position = paddlePos;
    }
    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, 1.3f, 14.7f);
        this.transform.position = paddlePos;
    }

    //void OnCollisionExit2D()
    //{
    //    float xScale = ball.transform.position.x - this.transform.position.x;
    //    float newX = xScale * ball.GetComponent<Rigidbody2D>().velocity.x;
    //    float magnitude = Mathf.Sqrt(ball.GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
    //    print("xscale " + xScale);
    //    print("magnitude " + magnitude);
    //    ball.GetComponent<Rigidbody2D>().velocity = new Vector2( newX, calculateY(magnitude, newX));
    //}

    //float calculateY(float magnitude, float newX)
    //{
    //    return Mathf.Sqrt(Mathf.Pow(magnitude, 2) - Mathf.Pow(newX, 2));
    //}
}
