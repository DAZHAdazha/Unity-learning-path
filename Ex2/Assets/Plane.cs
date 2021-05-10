using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane: MonoBehaviour
{

    private int hit = 0;
    // Start is called before the first frame update
    void Start()
    {
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();  // Try to access the CameraSupport component on the MainCamera
        if (s != null)   // if main camera does not have the script, this will be null
        {
            Bounds myBound = GetComponent<Renderer>().bounds;  // this is the bound of the collider defined on GreenUp
            CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound,0.9f);
            Vector3 pp = transform.localPosition;
            while (status != CameraSupport.WorldBoundStatus.Inside){
                    pp.x = s.GetWorldBound().min.x + Random.value * s.GetWorldBound().size.x;
                    pp.y = s.GetWorldBound().min.y + Random.value * s.GetWorldBound().size.y;
                    transform.localPosition = pp;
                    myBound = GetComponent<Renderer>().bounds;
                    status = s.CollideWorldBound(myBound,0.9f);
            }
        }
    }
    void Update()
    {
        
    }

    private void UpdateColor()
    {
        
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        Color c = s.color;
        c.a *= 0.8f;
        s.color = c;
        hit += 1;
        if(hit>=4){
            Destroy(transform.gameObject);
            GameObject destroyNumber = GameObject.Find("DestoryNumber");
            string destroyNumberString = destroyNumber.GetComponent<Text>().text;
            destroyNumber.GetComponent<Text>().text = (int.Parse(destroyNumberString)+1).ToString();

            GameObject enemyNumber = GameObject.Find("EnemyNumber");
            string enemyNumberString = enemyNumber.GetComponent<Text>().text;
            enemyNumber.GetComponent<Text>().text = (int.Parse(enemyNumberString)-1).ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.ToString()=="GreenUp"){
            Destroy(transform.gameObject);
            GameObject destroyNumber = GameObject.Find("DestoryNumber");
            string destroyNumberString = destroyNumber.GetComponent<Text>().text;
            destroyNumber.GetComponent<Text>().text = (int.Parse(destroyNumberString)+1).ToString();

            GameObject touchEnemyNumber = GameObject.Find("TouchEnemyNumber");
            string touchEnemyNumberString = touchEnemyNumber.GetComponent<Text>().text;
            touchEnemyNumber.GetComponent<Text>().text = (int.Parse(touchEnemyNumberString)+1).ToString();

            GameObject enemyNumber = GameObject.Find("EnemyNumber");
            string enemyNumberString = enemyNumber.GetComponent<Text>().text;
            enemyNumber.GetComponent<Text>().text = (int.Parse(enemyNumberString)-1).ToString();
        } else {
            UpdateColor();
            Destroy(collision.gameObject);
        }
    }

}