using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardMovement : MonoBehaviour
{
    public float upwardForce = 5f; 
    public float movementDuration = 1f; 

    private bool playerTouching = false; 

    void Update()
    {
       
        if (playerTouching && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveUpward());
        }
    }

    IEnumerator MoveUpward()
    {
        float timer = 0f;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = transform.position + Vector3.up * upwardForce;

        
        while (timer < movementDuration)
        {
            
            timer += Time.deltaTime;

           
            transform.position = Vector3.Lerp(initialPosition, targetPosition, timer / movementDuration);

            
            yield return null;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTouching = true;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTouching = false;
        }
    }
}
