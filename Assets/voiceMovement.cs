using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class voiceMovement : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private Dictionary <string, System.Action> actions = new Dictionary<string, System.Action>();
    //float someSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        actions.Add("left", moveLeft);
        actions.Add("right", moveRight);   
        actions.Add("up", speedUp); 
        actions.Add("down", speedDown);
        
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();
        Debug.Log("We are listining!");
        if(keywordRecognizer.IsRunning){
            Debug.Log("We are NOT listining!");
        }
        
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs speech){
        Debug.Log("We got some Speech!");
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void moveLeft(){
        Debug.Log("Left is pressed!");
        if(transform.position.x == 0){
                transform.position =  new Vector3(-4,transform.position.y,0);
               
            }
            else if(transform.position.x > 0){
                transform.position = new Vector3(0,transform.position.y,0);
        }

    }
    
    private void moveRight(){
            Debug.Log("Right is pressed!");
            if(transform.position.x == 0){
                transform.position =  new Vector3(4,transform.position.y,0);
                
            }
            else if (transform.position.x < 0){
                transform.position = new Vector3(0,transform.position.y,0);
              
        }

    }

    private void speedUp(){
        transform.Translate(Vector2.up * 4.0f * Time.deltaTime, Space.World);
        Debug.Log(transform.position);
    }

    private void speedDown(){
        transform.Translate(Vector2.up * 1.0f * Time.deltaTime, Space.World);
        Debug.Log(transform.position);
    }
    /*
    // Update is called once per frame
    void Update()
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
    }*/
}
