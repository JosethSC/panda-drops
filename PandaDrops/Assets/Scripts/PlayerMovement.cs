using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D _r;
    protected Animator _a;

    [SerializeField] protected float dir = 1;
    protected const float speed = 6;
    //The speedMultiplier changes the player
    //velocity without changing the speed
    //It can change depending on the difficulty and the level.
    public float speedMultiplier = 1;

    //Checks if the player is on ground using Raycast
    [SerializeField] protected bool onGround;
    public float collRad = 0.05f;
    public LayerMask groundLayer;

    [SerializeField] Vector2 _newVel;

    private void Awake()
    {
        //setup all required components
        _r = GetComponent<Rigidbody2D>();
        //_a = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //setting up the values of _newVel
        //if it is not on ground => zero
        _newVel.x = (onGround) ? dir * speed * speedMultiplier : 0;

        _r.velocity = new Vector2(_newVel.x, _r.velocity.y);
    }
    private void Update()
    {
        //Checks if player is on ground.
        onGround = Physics2D.OverlapCircle(_r.position, collRad, groundLayer);
        //Limits the position of the player
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,-4.8f,4.8f),
            transform.position.y
            );
        dir = Input.GetAxisRaw("Horizontal");

        Debug.Log(dir);
        Debug.Log(speed);
        Debug.Log(speed*speedMultiplier);
    }
}
