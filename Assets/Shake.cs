using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = 4f;
    public bool shake_test = false;

    IEnumerator Shaking(){
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration){
            elapsedTime += Time.deltaTime;

            //
            float strength = curve.Evaluate(elapsedTime/duration); 
            
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }

    // Public method to trigger shake
    public void TriggerShake()
    {
        StartCoroutine(Shaking());
    }

    void Update()
    {
     if (shake_test == true )
        {
            TriggerShake();
            shake_test = false; 
        }
    }
}