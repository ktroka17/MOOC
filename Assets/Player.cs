using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    float someSpeed = 1.0f;
    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        transform.Translate(Vector2.up * someSpeed * Time.deltaTime, Space.World);
        Debug.Log(transform.position);
      
        if(Input.GetKeyDown("left")){
            Debug.Log("Left is pressed!");
            if(transform.position.x == 0){
                transform.position =  new Vector3(-4,transform.position.y,0);
               
            }
            else if(transform.position.x > 0){
                transform.position = new Vector3(0,transform.position.y,0);
        }
        }
        else if (Input.GetKeyDown("right")){
            Debug.Log("Right is pressed!");
            if(transform.position.x == 0){
                transform.position =  new Vector3(4,transform.position.y,0);
                
            }
            else if (transform.position.x < 0){
                transform.position = new Vector3(0,transform.position.y,0);
              
        }
        }
        else if(Input.GetKeyDown("up")){
            someSpeed = 4.0f;
        }
        else if(Input.GetKeyDown("down")){
            someSpeed = 1.0f;
        }
    }
}
