using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private float dirX;
    [SerializeField] private float speed = 4f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(dirX * speed, _rb.velocity.y);
    }
    void Update()
    {
        Flip();
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        /* if(Mathf.Abs(Input.acceleration.x)>0.2f)
        {
            dirX = Input.acceleration.x * speed;
        } else {
            dirX = 0;
        }*/
        _animator.SetFloat("speed",Mathf.Abs(_rb.velocity.x));   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Food")
        {
            PointsManager pm = GameObject.FindGameObjectWithTag("PointsManager").GetComponent<PointsManager>();
            pm.AddScore();
            _animator.SetTrigger("isEating");
            Destroy(other.gameObject,0.2f);   
        }
        if(other.tag=="Trash")
        {
            _animator.SetTrigger("isSad");
            Health health = GetComponent<Health>();
            health.DecreaseHealth();
            Destroy(other.gameObject,0.2f);
        }
    }

    void Flip()
    {
        if(_rb.velocity.x>0.01f)
        {
            transform.localScale = new Vector3(1,1,1);
        } else if(_rb.velocity.x<-0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
    }
}
