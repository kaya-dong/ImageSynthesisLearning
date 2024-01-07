using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShapeLabel {Cube, Sphere, Cylinder}

public class Shape{
    public ShapeLabel label;
    public GameObject obj;
}

//相对于MonoBehaviour更加轻量级的存在
public class ShapePool : ScriptableObject
{
    private GameObject[] prefabs;//不同的对象有不同的对象池
    private Dictionary<ShapeLabel, List<Shape>> pools;
    private List<Shape> active;

    public static ShapePool Create(GameObject[] prefabs){
        var p = ScriptableObject.CreateInstance<ShapePool>();
        p.prefabs = prefabs;
        p.pools = new Dictionary<ShapeLabel, List<Shape>>();
        for(int i=0; i<prefabs.Length; i++){
            p.pools[(ShapeLabel)i] = new List<Shape>();
        }

        p.active = new List<Shape>();
        return p;
    }

    public Shape Get(ShapeLabel label) {
        var pool = pools[label];
        int lastIndex = pool.Count - 1;
        Shape retShape;
        if (lastIndex <= 0) {//池中没有对象，实例化
            var obj = Instantiate(prefabs[(int)label]);
            retShape = new Shape() { label = label, obj = obj };
        } else {//返回池中最后一个对象
            retShape = pool[lastIndex];
            retShape.obj.SetActive(true);//对象是否输出到屏幕上
            pool.RemoveAt(lastIndex);
        }
        active.Add(retShape);
        return retShape;
    }

    public Shape GetActive(int index)
    {
        return active[index];
    }

    public void ReclaimAll() {//查看所有的活动对象
        foreach (var shape in active) {
            shape.obj.SetActive(false);
            pools[shape.label].Add(shape);
        }
        active.Clear();
    }
}
