using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public ImageSynthesis synth;
    public GameObject[] prefabs;

    public int minObjects = 10;
    public int maxObjects = 20;
    public int trainingImages;
    public int valImages;

    //private GameObject[] created;
    private int frameCount = 0;
    private ShapePool pool;
    // Start is called before the first frame update
    void Start()
    {
        //created = new GameObject [maxObjects];
        pool = ShapePool.Create(prefabs);
    }

    // Update is called once per frame
    void Update()
    {
        if(frameCount < trainingImages + valImages){
            if (frameCount % 30 == 0){
            GenerateRandom(); 
            Debug.Log($"FrameCount:{frameCount}");
            }
            if(frameCount<trainingImages){
                string filename = $"image_{frameCount.ToString().PadLeft(5,'0')}";
                synth.Save(filename,512,512,"Captures/train", 2);
            }else if(frameCount < trainingImages + valImages){
                int valFrameCount = frameCount - trainingImages;

                string filename = $"image_{valFrameCount.ToString().PadLeft(5,'0')}";
                synth.Save(filename,512,512,"Captures/val", 2);
            }
            frameCount++;
        }

        
    }

    void GenerateRandom()
    {
        // for(int i=0; i<created.Length; i++){
        //     if(created[i] != null){
        //         Destroy(created[i]);
        //     }
        // }
        pool.ReclaimAll();
        int objectTisTime = Random.Range(minObjects, maxObjects);
        for(int i=0; i<objectTisTime; i++){
            //选择一个prefab
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
            
            var shape = pool.Get((ShapeLabel)prefabIndex);
            var newObj = shape.obj;
            //var newObj = Instantiate(prefab, newPos, newRot); 
            //created[i]=newObj;
            newObj.transform.position=newPos;
            newObj.transform.rotation=newRot;

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
        synth.OnSceneChange();   //目的是为了在每次添加预制对象的时候都能在3级显示上，按照图层正确显示渲染对象
        //比较低效          
    }
}
