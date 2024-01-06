using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public ImageSynthesis synth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        synth.OnSceneChange();
        //目的是为了在每次添加预制对象的时候都能在3级显示上，按照图层正确显示渲染对象
        //比较低效
    }
}
