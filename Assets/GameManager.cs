using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject player; // Assign the Player in Inspector

    void OnTriggerEnter(Collider other) // if something touches my deathzone platform...
    {
        if (other.gameObject == player) // is the collided object the player??
        {
            
            Debug.Log("Game Over: Fell off!");
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.CompareTag("Ball")) // is the collided object a cannon ball??
        {
            Debug.Log("Destroyed ball: " + other.name);
            Destroy(other.gameObject);
        }
    }
}