using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required to work with UI, e.g., Text

public class GameManager : MonoBehaviour
{

    public int planeNumber = 0;
    public GreenArrowBehavior mHero = null;  

    void Start()
    {
        Debug.Assert(mHero != null);
        EggBehavior.SetGreenArrow(mHero);

    }

    private void generate(){
        GameObject enemyNumber = GameObject.Find("EnemyNumber");
        string enemyNumberString = enemyNumber.GetComponent<Text>().text;
        planeNumber = int.Parse(enemyNumberString);
        while(planeNumber<10){
            GameObject e = Instantiate(Resources.Load("Prefabs/Plane") as GameObject); 
            CameraSupport s = Camera.main.GetComponent<CameraSupport>();  
            Vector3 pp = e.transform.localPosition;
            pp.x = s.GetWorldBound().min.x + Random.value * s.GetWorldBound().size.x;
            pp.y = s.GetWorldBound().min.y + Random.value * s.GetWorldBound().size.y;
            e.transform.localPosition = pp;
            planeNumber++;
        }
        enemyNumber.GetComponent<Text>().text = planeNumber.ToString();
    }
    void Update()
    {
        generate();
    }

}