using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletManager : MonoBehaviour
{
    [SerializeField] protected int poolSize;
    // Dictionary để ánh xạ từ Prefab của mỗi loại đạn đến danh sách các đối tượng được pool của loại đó
   
    public abstract void CreatePool();


    public abstract Bullet GetPooledObject();

    public abstract void ReturnObjectToPool(Bullet obj);
   

   
}
