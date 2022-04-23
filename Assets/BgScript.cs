using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    public static BgScript BgInstance;
    public static BgScript Instance
    {
        get { return BgInstance; }
    }

    private void Awake()
    {
        if (BgInstance != null && BgInstance != this)
        {
            Debug.Log(BgInstance);
            Debug.Log("yess");
            Destroy(this.gameObject);
            BgScript.Instance.gameObject.GetComponent<AudioSource>().UnPause();
            return;
        }
        BgInstance = this;
        DontDestroyOnLoad(this);
    }
}
