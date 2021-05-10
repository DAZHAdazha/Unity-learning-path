using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    static private GreenArrowBehavior sGreenArrow = null;
    static public void SetGreenArrow(GreenArrowBehavior g) { sGreenArrow = g; }
    private const float kEggSpeed = 40f;
    private const int kLifeTime = 300; 
    private int mLifeCount = 0; 
    void Start()
    {
    }

    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);
        CameraSupport s = Camera.main.GetComponent<CameraSupport>(); 
        if (s != null)   
        {
            Bounds myBound = GetComponent<Renderer>().bounds; 
            CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound);
            if (status != CameraSupport.WorldBoundStatus.Inside)
            {
                Destroy(transform.gameObject);
                sGreenArrow.OneLessEgg();
            }
        }
    }
}
