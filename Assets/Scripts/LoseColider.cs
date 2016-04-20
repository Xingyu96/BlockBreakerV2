using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseColider : MonoBehaviour {

    //public LevelManager levelManager;
    private SceneManager sceneManager;
    void OnTriggerEnter2D(Collider2D trigger){
        SceneManager.LoadScene("Lose");
    }

    void OnCollisionEnter2D(Collision2D collision){
        print("Collision");
    }
}
