using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenArrowBehavior : MonoBehaviour
{
    public bool mFollowMousePosition = true;
    public float mHeroSpeed = 20f;
    public float mHeroRotateSpeed = 90f / 2f; 
    private int mTotalEggCount = 0;
    private float mEggSpawnAt = 0f;
    public Text drive;
    public Text eggNumber;


    void Start()
    {
        
    }

    public void OneLessEgg() { 
        mTotalEggCount--;
        eggNumber.text = mTotalEggCount.ToString(); 
    }

    public string EggStatus() { return "Eggs on screen: " + mTotalEggCount; }

    private void callEvent(){
         if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        Vector3 p = transform.localPosition;

        if (Input.GetKeyDown(KeyCode.M)){
            mFollowMousePosition = !mFollowMousePosition;
            if(drive.text == "Drive(mouse)"){
                drive.text = "Drive(keyboard)"; 
            }else{
                drive.text = "Drive(mouse)"; 
            }
            
        }
        if (mFollowMousePosition)
        {
            p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f; 
        }
        else
        {
            if (Input.GetKey(KeyCode.W)){
                mHeroSpeed += 0.5f;
            }
            if (Input.GetKey(KeyCode.S)){
                 mHeroSpeed -= 0.5f;
             }
            if (Input.GetKey(KeyCode.A)){
                transform.Rotate(transform.forward,  mHeroRotateSpeed * Time.smoothDeltaTime);
            }
            if (Input.GetKey(KeyCode.D)){
                transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
            }

        }
        if (Input.GetKey(KeyCode.Space))
        {
            if ((Time.time - mEggSpawnAt) >0.2){
                GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); // Prefab MUST BE located in Resources/Prefab folder!
                e.transform.localPosition = transform.localPosition;
                e.transform.up = transform.up;
                mTotalEggCount++;
                eggNumber.text = mTotalEggCount.ToString(); 

                mEggSpawnAt = Time.time;
            }
        }
        p += ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);
        transform.localPosition = p;
    }

    void Update()
    {
       callEvent();
    }
}