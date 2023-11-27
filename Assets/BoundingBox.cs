using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BoundingBox : MonoBehaviour
{
    public Bounds aabb;
    public int rows = 3;
    public int cols = 3;
    public UnityEngine.Vector3 getSpawnLocation(){
        float xSpacing = aabb.size.x / cols; // 100 / 3 = 33
        float ySpacing = aabb.size.y / rows; // 100 / 3 = 33
        float z = aabb.center.z;

        int totalBillboards = transform.childCount; // 3
        int curRow = totalBillboards / cols; // 3 / 3 = 1
        Debug.Log(curRow);
        Debug.Log(curRow > rows);
        int curCol = totalBillboards % cols; // 0 % 3 = 0

        float x = aabb.min.x + (curCol * xSpacing) + (xSpacing / 2); // -50 + (0) + (16.5)
        float y = aabb.max.y + (curRow * -ySpacing) - (ySpacing / 2);

        if (!aabb.Contains(new UnityEngine.Vector3(x, y, z)) || curRow > rows-1){
            Debug.Log(new UnityEngine.Vector3(x, y, z));
            return UnityEngine.Vector3.negativeInfinity;
        }
        return new UnityEngine.Vector3(x, y, z);
    }
}

    
