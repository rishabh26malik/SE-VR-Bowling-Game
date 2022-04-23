using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.IO;


public class NewGameManager : MonoBehaviour
{
    int cl;
    string myfile;
    [SerializeField] GameObject Ball;
    private GameObject RestartMenu;
    int score = 0;
    private GameObject[] pins;
    int[] bowlerScores = new int[21];
    int[] cumulScores = new int[10];
    int turnCounter = 0;
    int frameNumber = 0;
    int currentRoll = 0;
    int gullyCounter = 0;
    //[SerializeField] TextMeshPro scoreUI;
    //private TextMeshPro scoreUI;
    //public TextMeshProUGUI scoreUI;
    Vector3 originalPos;
    private Vector3[] pinsPositon;
    bool gameOver = false;
    //GameObject originalGameObject, child, subChild;

    // Start is called before the first frame update
    void Start()
    {
        BgScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
        myfile = Application.persistentDataPath + "/scores.txt";
        int c = 0;
        
        /*        string fileName = "";
                try
                {
                    fileName = Application.persistentDataPath + "/scores.txt";
                }
                catch(FileNotFoundException e)
                {
                    fileName = @"/scores.txt";
                }

                string[] lines = File.ReadAllLines(fileName);
                Console.WriteLine(String.Join(Environment.NewLine, lines));*/
        Debug.Log("-----------------------------------");
        originalPos = new Vector3(Ball.transform.position.x, Ball.transform.position.y, Ball.transform.position.z);
        
        Debug.Log("originalPos : " + originalPos);
        pins = GameObject.FindGameObjectsWithTag("PIN");
        pinsPositon = new Vector3[pins.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            pinsPositon[i] = pins[i].transform.position;
        }
        Debug.Log("pinsPositon : " + pinsPositon);
        RestartMenu = GameObject.FindWithTag("EndGame");
        RestartMenu.SetActive(false);

        /*originalGameObject = GameObject.Find("Frame1");
        child = originalGameObject.transform.GetChild(0).gameObject;
        //subChild = child.transform.GetChild(0).gameObject;
        Debug.Log(" ----- " + originalGameObject);
        Debug.Log(" ----- " + child);
        //Debug.Log(" ----- " + subChild);
        child = originalGameObject.transform.GetChild(1).gameObject;
        subChild = child.transform.GetChild(0).gameObject;
        Debug.Log(" ----- " + child);
        Debug.Log(" ----- " + subChild);*/
        //getFrameScoreObject(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (frameNumber == 10 && turnCounter==0 && gameOver==false)
        {
            Debug.Log("GAME OVER");
            gameOver = true;

            int finalScore = cumulScores[frameNumber-1];
            write2file(finalScore);
            frameNumber = 0;
            currentRoll = 0;
            RestartMenu.SetActive(true);
        }

    }

    private void write2file(int playerScore)
    {
        Debug.Log("in write2file");
        
        //try
        //{
         //myfile = Application.persistentDataPath + "/scores.txt";
        //}
        //catch(FileNotFoundException e)
        //{
        //    myfile = @"/scores.txt";
        //}

        // Appending the given texts
        using (StreamWriter sw = File.AppendText(myfile))
        {
            Debug.Log("writing ... " + playerScore);
            sw.WriteLine(playerScore.ToString());
        }
    }

    //private int countPinsDown(int frameNumber, int turnCounter)
    //private int countPinsDown()
    private IEnumerator countPinsDown()
    {
        score = 0;
        //int pinsDown = 0;
        //Debug.Log(pins);
        Debug.Log("Frame number : " + frameNumber);
        Debug.Log("TURN number : " + turnCounter);

        yield return new WaitForSeconds(7);

        for (int i = 0; i < pins.Length; i++)
        {
            // (pins[i].transform.eulerAngles.x > 5 && pins[i].transform.eulerAngles.x < 355)
            if ((pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355)
                && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
        }

        bowlerScores[currentRoll] = score;

        Debug.Log("Score : " + score);
        if (score == 10)
        {
            bowlerScores[currentRoll + 1] = -1;
        }


        int cumulScore = calculateScore(bowlerScores, frameNumber, turnCounter, score);
        updateDisplayScore(frameNumber, turnCounter, score, cumulScore);
        
        if (turnCounter == 0)
        {
            if (score == 10)
            {
                /*bowlerScores[currentRoll] = -1;*/
                currentRoll += 2;
                turnCounter = 0;
                frameNumber += 1;
                gullyCounter = 0;
                Invoke("ResetPins", 1);
                Debug.Log("Turn Skipped!!!");
            }
            else
            {
                turnCounter = 1;
                currentRoll += 1;
                Invoke("ResetBall", 2);
            }
        }

        else
        {
            turnCounter = 0;
            frameNumber+=1;
            currentRoll += 1;
            Invoke("ResetPins", 2);
        }




        //return score;
        //scoreUI.text = score.ToString();
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Left_gulley" || col.gameObject.name == "Right_gulley" || col.gameObject.name == "Back_space")
        //col.gameObject.name == "leftOutside" || col.gameObject.name == "rightOutside" || col.gameObject.name == "backOutside")
        {
            Debug.Log("ENTERED GULLEY");
            Invoke("ResetBall", 3);

        }
        if (col.gameObject.name == "leftOutside" || col.gameObject.name == "rightOutside" || col.gameObject.name == "backOutside")
        {
            Debug.Log("ENTERED OUTSIDE AREA");
            Invoke("ResetBall", 3);
        }

    }
    //    Debug.Log("Hi OnCollision Gulley");
    //if (gullyCounter == 1)
    //{
    //    Debug.Log("ENTERED GULLEY");

    //int score_main = countPinsDown(frameNumber, turnCounter);
    //Invoke("countPinsDown", 5);
    //Debug.Log("Frame number : " + frameNumber);
    //Debug.Log("TURN number : " + turnCounter);
    //turnCounter = 0;
    //frameNumber++;
    //    gullyCounter = 0;
    //    Invoke("ResetPins", 8);
    //}
    //else
    //{
    //Debug.Log("First Turn. No reset");
    //Debug.Log("Frame number : " + frameNumber);
    //Debug.Log("TURN number : " + turnCounter);
    ////int score_main = countPinsDown(frameNumber, turnCounter);
    //Invoke("countPinsDown", 5);
    ////updateDisplayScore(frameNumber, turnCounter, score);
    //if (score == 10)
    //{
    //        /*bowlerScores[currentRoll] = -1;*/
    //    currentRoll += 1;
    //    turnCounter = 0;
    //    frameNumber += 1;
    //    gullyCounter = 0;
    //    Invoke("ResetPins", 1);
    //    Debug.Log("Turn Skipped!!!");
    //}
    //else
    //{
    //    turnCounter = 1;

    //}
    //    gullyCounter = 1;
    //    Invoke("ResetBall", 5);
    //}
    //    Invoke("ResetBall", 5);
    //}

    //else if (col.gameObject.name == "leftOutside" || col.gameObject.name == "rightOutside" || col.gameObject.name == "backOutside")
    //{
    //    Debug.Log("OUTSIDE PLAY AREA");
    //    Debug.Log("Hi OnCollision Outside");
    //ResetPins();
    //Invoke("ResetPins", 3);
    //Debug.Log(originalPos);
    //ResetPins();
    //collision.gameObject.transform.SetParent(transform);
    //if (gullyCounter == 1)
    //{
    //    Debug.Log("ENTERED GULLEY");
    //Debug.Log(originalPos);
    //ResetPins();
    //Invoke("ResetPins", 10);
    //collision.gameObject.transform.SetParent(transform);
    //        gullyCounter = 0;
    //    }
    //    else
    //    {
    //        Debug.Log("First Turn. No reset");
    //        Invoke("ResetBall", 3);
    //        gullyCounter = 1;
    //    }
    //}

    //else
    //{
    //    Debug.Log("Others....");
    //}

    
    void OnTriggerEnter(Collider other) 
    {
        //Debug.Log("INSIDE TRIGGER " + other.gameObject.name);
        if (other.gameObject.name == "ball2")
        {
            AudioSource strikeAudio = GetComponent<AudioSource>();
            strikeAudio.Play();
            Debug.Log("*****INSIDE TRIGGER " + other.gameObject.name);
            Debug.Log("ENTERED TRIGGER....");
            StartCoroutine(countPinsDown());
            //if (turnCounter == 0)
            //{
            //    Debug.Log("Frame number : " + frameNumber);
            //    Debug.Log("TURN number : " + turnCounter);
            //    StartCoroutine(countPinsDown(frameNumber,turnCounter));
            //    //updateDisplayScore(frameNumber, turnCounter, score);
            //    if (score == 10)
            //    {
            //        turnCounter = 0;
            //       // frameNumber++;
            //        gullyCounter = 0;
            //        Debug.Log("Turn Skipped!!!");
            //    }
            //    else
            //    {
            //        turnCounter = 1;
            //    }
            //    //turncounter = 1;

            //}
            //else
            //{
            //    //updateDisplayScore(frameNumber, turnCounter, score);
            //    StartCoroutine(countPinsDown(frameNumber,turnCounter));
            //    Debug.Log("Frame number : " + frameNumber);
            //    Debug.Log("TURN number : " + turnCounter);
            //    turnCounter = 0;
            //    frameNumber++;
            //}
        }  
    }

    private void ResetBall()
    {

        Ball.transform.position = originalPos;
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Ball.transform.rotation = Quaternion.identity;
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
        ResetBall();
    }

    public int calculateScore(int[] bowlersScores, int frameNum, int throwNum, int pinsDown)
    {
        int currentRoll = 2 * frameNum;
        currentRoll += throwNum;
        int frameIndex = 0;
        int prevScore = 0;
        Debug.Log("Current Roll Num: " + currentRoll);
        Debug.Log("Bowlers Current Score: " + bowlerScores[currentRoll]);
        Debug.Log("Pins Down: " + bowlerScores[currentRoll]);
        for (var i = 0; i <= currentRoll; i++)
        {
            bool even = (i % 2 == 1) ? false : true;

            // Check Strike
            if (even && bowlersScores[i] == 10 && bowlersScores[i + 1] == -1)
            { // If all ten are down, and the roll we are on is even (starting at zero)
                prevScore = prevScore + strike(i, bowlersScores);
            }
            // Check Spare
            else if (!even && ((i-1>=0) && bowlersScores[i - 1] + bowlersScores[i] == 10))
            { // If the roll we are on an odd roll, and the past two rolls add to ten
                prevScore = prevScore + spare(i, bowlersScores);
            }
            // Check if Normal
            else if (bowlersScores[i] >= 0)
            { // Only display after the second throw of the frame
                /*
                if (!even || i == 20)
                {
                    prevScore = prevScore + normal(i, bowlersScores);
                }
                */
                prevScore = prevScore + bowlerScores[i]; /*normal(i, bowlersScores);*/
            }

            frameIndex = i / 2;
            if (i > 19)
            { // Last frame could have three throws
                frameIndex = 9;
            }

            cumulScores[frameIndex] = prevScore;

        }
        
        return cumulScores[frameNum];

    }

    private int strike(int index, int[] currentscores)
    {
        if (index > 17)
        {
            return (10);
        }
        int count = 0;
        int scoresum = 10; // start at ten since it was a strike
                           // if a strike is thrown, then also add the next two rolls
        return scoresum + currentscores[index + 2] + currentscores[index + 3];
        //int i = 1;
        //while (i <= 4)
        //{
        //    int temp = index + i;
        //    if (currentscores[temp] >= 0 && count < 2)
        //    {
        //        // add only the next two valid scores
        //        scoresum += currentscores[temp];
        //        count++;
        //    }
        //    i++;
        //}
        //return scoresum;
    }

    private int spare(int index, int[] currentscores)
    {
        if (index > 17)
        {
            return currentscores[index];
        }
       // int count = 0;
       /* int scoresum = 10; */// start at ten since it was a strike
                           // if a strike is thrown, then also add the next two rolls

        return currentscores[index] + currentscores[index + 1];
        //int i = 1;
        //while (i <= 4)
        //{
        //    int temp = index + i;
        //    if (currentscores[temp] >= 0 && count < 1)
        //    { // add only the next two valid scores
        //        scoresum += currentscores[temp];
        //        count++;
        //    }
        //    i++;
        //}

        //return scoresum;
    }

    private int normal(int index, int[] currentScores)
    {
        int temp = index - 1;
        
        if (temp>=0 && currentScores[temp] >= 0)
        {
            return (currentScores[index] + currentScores[temp]);
        }
        else
        {
            return currentScores[index];
        }
        //return (currentScores[index]);
    }

    void updateDisplayScore(int frameNum, int turnNum, int value2assign, int cumulScore)
    {
        Debug.Log("Score inside update: " + score);
        GameObject frameObj, turnObj, turnScoreTextObj;
        frameObj = GameObject.Find("Frame" + frameNum.ToString());
        turnObj = frameObj.transform.GetChild(turnNum).gameObject;
        turnScoreTextObj = turnObj.transform.GetChild(0).gameObject;
        turnScoreTextObj.GetComponent<TextMeshProUGUI>().text = value2assign.ToString();
        GameObject FinalScore = GameObject.Find("Final_score");
        GameObject CUMULSCOREVALUE = FinalScore.transform.GetChild(0).gameObject;
        CUMULSCOREVALUE.GetComponent<TextMeshProUGUI>().text = cumulScore.ToString();
        Debug.Log("cumlul score : " + cumulScore);

    }

    public void BackFunction()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
