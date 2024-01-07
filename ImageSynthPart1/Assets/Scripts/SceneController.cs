using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public ImageSynthesis synth;
    public GameObject[] prefabs;
    public int maxObjects = 10;
    private GameObject[] created;

    // Start is called before the first frame update
    void Start()
    {
        created = new GameObject [maxObjects];
    }

    // Update is called once per frame
    void Update()
    {
        GenerateRandom();
        synth.OnSceneChange();
        //目的是为了在每次添加预制对象的时候都能在3级显示上，按照图层正确显示渲染对象
        //比较低效
    }

    void GenerateRandom()
    {
        for(int i=0; i<created.Length; i++){
            if(created[i] != null){
                Destroy(created[i]);
            }
        }
        //选择一个prefab
        for(int i=0; i<maxObjects; i++){
            int prefabIndex = Random.Range(0,prefabs.Length);
            var prefab = prefabs[prefabIndex];
        

            //设置位置
            float newX, newY, newZ;
            newX = Random.Range(-10.0f,10.0f);
            newY = Random.Range(2.0f,10.0f);
            newZ = Random.Range(-10.0f,10.0f);
            Vector3 newPos = new Vector3(newX, newY, newZ);

            //设置旋转
            var newRot = Random.rotation;
            var newObj = Instantiate(prefab, newPos, newRot); 
            created[i]=newObj;

            //设置缩放
            float sx = Random.Range(0.5f,2.0f);
            Vector3 newScale = new Vector3(sx,sx,sx);
            newObj.transform.localScale = newScale;

            //设置颜色
            float newR, newG ,newB;
            newR = Random.Range(0.0f,1.0f);
            newG = Random.Range(0.0f,1.0f);
            newB = Random.Range(0.0f,1.0f);
            var newColor = new Color(newR,newG,newB);
            newObj.GetComponent<Renderer>().material.color = newColor;


        }
    }
}
