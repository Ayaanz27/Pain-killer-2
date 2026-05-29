using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public GameObject Bomb1;           
    public float spawnInterval = 1.5f;   
    public float spreadAmount = 2f;    

    void Start() {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine() {
        while (true) {
            SpawnBall();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBall() {
        
        GameObject newBall = Instantiate(Bomb1, transform.position, Quaternion.identity);
        newBall.tag = "Ball"; 

        Rigidbody ballRb = newBall.GetComponent<Rigidbody>();

        if (ballRb != null) {
            
            ballRb.useGravity = true;
 
            float randomX = Random.Range(-spreadAmount, spreadAmount);
            float randomZ = Random.Range(-spreadAmount, spreadAmount);

            // 4. Apply the velocity. 
            // We set Y to 0 so it doesn't "teleport" down, letting gravity take over.
            ballRb.linearVelocity = new Vector3(randomX, 0, randomZ);

            // 5. Add some random spin (Torque) to make the rolling look realistic
            Vector3 randomSpin = new Vector3(Random.value, 15, Random.value);
            ballRb.AddTorque(randomSpin * 15f, ForceMode.Impulse);
        }
    }
}