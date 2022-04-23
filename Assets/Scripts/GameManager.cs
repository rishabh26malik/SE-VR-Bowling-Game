using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{/*
    [SerializeField] GameObject Ball;
    int score = 0;
    private GameObject[] pins;
    int turnCounter = 0;
    int frameNumber = 0;
    //[SerializeField] TextMeshPro scoreUI;
    //private TextMeshPro scoreUI;
    public TextMeshProUGUI scoreUI;
    Vector3 originalPos;
    private Vector3[] pinsPositon;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(Ball.transform.position.x, Ball.transform.position.y, Ball.transform.position.z);
        Debug.Log(originalPos);
        pins = GameObject.FindGameObjectsWithTag("PIN");
        Debug.Log("***pins info");
        Debug.Log(pins);
        pinsPositon = new Vector3[pins.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            //Debug.Log(i);
            pinsPositon[i] = pins[i].transform.position;
        }
        Debug.Log(pinsPositon);
        


        //pins = GameObject.FindGameObjectsWithTag("PIN");
    }

    // Update is called once per frame
    void Update()
    {
        //score = 0;
        //countPinsDown();
    }

    void countPinsDown()
    {
        score = 0;
        Debug.Log(pins);
        Debug.Log("***countPinsDown " + pins);
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355
                && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
        }

        //scoreUI.text = score.ToString();
        //scoreUI = GameObject.FindWithTag("SCORE");
        //scoreUI = GetComponent<TextMeshPro>();
        //scoreUI.GetComponent<TextMeshPro>().text = score.ToString();
        //scoreUI.text = score.ToString();
        //scoreUI.text = score.ToString();
        scoreUI.text = score.ToString();
        Debug.Log("***Score : " + score);
    }

    void updateFrameNum()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Left_gulley" || col.gameObject.name == "Right_gulley" || col.gameObject.name == "Back_space")
        {
            Debug.Log("***entered gulley");
            Debug.Log(originalPos);
            ResetPins();
            //collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "ball2") 
        {
            Debug.Log(other.gameObject.name);
            Debug.Log("***entered trigger....");
            countPinsDown();
            if (turnCounter == 0)
            {
                Debug.Log("***Frame number : " + frameNumber);
                Debug.Log("****TURN number : " + turnCounter);
                if (score == 10)
                {
                    turnCounter = 0;
                    frameNumber++;
                }
                else
                {
                    turnCounter = 1;
                }


            }
            else
            {

                Debug.Log("Frame number : "+ frameNumber);
                Debug.Log("TURN number : " + turnCounter);
                turnCounter = 0;
                frameNumber++;
            }
        }

        //if (turnCounter == 0)
        //{
        //    Debug.Log("Frame number : " + frameNumber);
        //    Debug.Log("TURN number : " + turnCounter);
        //    if (score == 10)
        //    {
        //        turnCounter = 0;
        //        frameNumber++;
        //    }
        //    else
        //    {
        //        turnCounter = 1;
        //    }


        //}
        //else
        //{

        //    Debug.Log("Frame number : "+ frameNumber);
        //    Debug.Log("TURN number : " + turnCounter);
        //    turnCounter = 0;
        //    frameNumber++;
        //}
    }

    private void ResetPins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true);
            pins[i].transform.position = pinsPositon[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = Quaternion.identity;
        }

        //Ball.transform.position = new Vector3(2.55f, 3.824f, -8.318f);
        //Ball.transform.position = new Vector3(1.321f, 0.4245f, -0.313f);
        //Ball.transform.position = new Vector3(-1.234f, 3.889f, -8.208f);
        Ball.transform.position = originalPos;
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Ball.transform.rotation = Quaternion.identity;
    }
    */
}
