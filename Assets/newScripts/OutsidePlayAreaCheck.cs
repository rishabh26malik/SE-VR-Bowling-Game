using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsidePlayAreaCheck : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    Vector3 originalPos;

    void Start()
    {
        originalPos = new Vector3(Ball.transform.position.x, Ball.transform.position.y, Ball.transform.position.z);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "leftOutside" || col.gameObject.name == "rightOutside" || col.gameObject.name == "backOutside")
        {
            Debug.Log("Outside play area");
            ResetPins();
            //Debug.Log(originalPos);
            //ResetPins();
            //collision.gameObject.transform.SetParent(transform);
        }
    }

    private void ResetPins()
    {
        /*for (int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true);
            pins[i].transform.position = pinsPositon[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = Quaternion.identity;
        }*/

        Ball.transform.position = originalPos;
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Ball.transform.rotation = Quaternion.identity;
    }
}
