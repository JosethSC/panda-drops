using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float speed = 0.018f;
    private Transform ground;

    void Awake()
    {
        ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<Transform>();
    }
    void Update()
    {
        if(Time.timeScale==1)
        {
            if(this.transform.position.y<=ground.position.y+1.25f)
            {
                Destroy(this.gameObject,0f);
                if(this.gameObject.tag=="Food")
                {
                    Health health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
                    health.DecreaseHealth();
                }
            } else {
                this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                            new Vector3(this.transform.position.x,
                                                            ground.position.y,
                                                            0),
                                                            speed);
            }
        } else {
            return;
        }
    }
}
