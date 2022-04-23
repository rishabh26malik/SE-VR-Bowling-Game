using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class ShowScore : MonoBehaviour
{
    public GameObject[] allScores;
    GameObject scoreObj;
    string myfile;
    public void Start()
    {
        //string myfile = "";

        myfile = Application.persistentDataPath + "/scores.txt";
        //if (!File.Exists(myfile))
        //{
        //    FileStream fs = File.Create(myfile);
        //    using var sr = new StreamWriter(fs);

        //    sr.WriteLine("100\n");
        //using (StreamWriter sw = File.AppendText(myfile))
        //{
        //    //Debug.Log("writing ... " + playerScore);
        //    sw.WriteLine("100");
        //}
        //}
        //int n;
        //string[] lines = System.IO.File.ReadAllLines(myfile);
        //int[] scores = Array.ConvertAll(lines, s => int.Parse(s));
        //Array.Sort(scores);
        //Array.Reverse(scores);
        //allScores = GameObject.FindGameObjectsWithTag("highScore");
        //Debug.Log("allScores length : " + allScores.Length);
        //if(allScores.Length >= scores.Length)
        //{
        //    n = scores.Length;
        //}
        //else
        //{
        //    n = allScores.Length;
        //}
        //foreach (int value in scores)
        //{
        //    Debug.Log("Player 1 - " + value);

        //}
        //for(int i = 0; i < n; i++)
        //{
        //    allScores[i].GetComponent<TextMeshProUGUI>().text = scores[i].ToString();
        //}

        List<int> scores = new List<int>();
        using (StreamReader sw = File.OpenText(myfile))
        {
            string line = "";
            while ((line = sw.ReadLine()) != null)
            {
                int temp = Int32.Parse(line);
                scores.Add(temp);
            }
        }

        List<int> last10 = new List<int>();
        scores.Reverse();

        for (int i = 0; i<10; i++)
        {
            if (i == scores.Count)
                break;
            last10.Add(scores[i]);
        }


        last10.Sort();
        last10.Reverse();

        

        string abc = "";
        for(int i=0; i<last10.Count; i++)
        {
            scoreObj = GameObject.FindWithTag("h" + i.ToString());
            scoreObj.GetComponent<TextMeshProUGUI>().text = last10[i].ToString();
            abc += last10[i] + " | ";
        }



        Debug.Log(abc);





    }

    public void BackFunction()
    {
        SceneManager.LoadScene(0);
    }
}
