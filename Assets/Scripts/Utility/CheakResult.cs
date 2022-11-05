using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class CheakResult : MonoBehaviour
{
    string video_Path = "";
    public VideoPlayer videoplayer;
    public GameObject good;
    public GameObject bad;

    // Start is called before the first frame update
    void Start()
    {
        GameObject count = GameObject.Find("CollectionsCount");
        if (count)
        {
            if (count.GetComponent<CollectionsCount>().getCollection() == 0)
            {
                video_Path = Application.streamingAssetsPath + "/EndGood.mp4";
                good.SetActive(true);
            }
            else
            {
                video_Path = Application.streamingAssetsPath + "/End1.mp4";
                bad.SetActive(true);
            }
            videoplayer.url = video_Path;
            videoplayer.Play();
        }
    }
}
