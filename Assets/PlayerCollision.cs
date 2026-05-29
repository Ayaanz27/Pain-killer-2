using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public Shake cameraShake;

    private void OnCollisionEnter(Collision collision )
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("player ran into a bomb");
            if (cameraShake)
            {
                cameraShake.TriggerShake();
            }

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); // looking for GameManager.cs
  
            if (scoreManager) // Check that gameManager *actually* exists --> make sure it is not 0
            {
  	            scoreManager.GameOver();
            }
        }    
    }
   
   

   
}
