using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : MonoBehaviour
{
    private Moving moving;
    private AnimationPlayer animplayer;

    private bool death;
    private bool move = true;
    [SerializeField] private bool globalMove;
    [SerializeField] private float rayDistans;
    [SerializeField] private Vector3 beginHit;

    [SerializeField] private bool getsUp;
    [SerializeField]private bool _dontEnter = true;
    public bool DontEnter { get => _dontEnter; set => _dontEnter = value; }
    private Rigidbody2D rb;
    public bool Death { get => death; set => death = value; }

    void Awake()
    {
        moving = GetComponent<Moving>();
        animplayer = GetComponent<AnimationPlayer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        
        if(!Death)
        {
            if(globalMove)
            {
                if(move)
                {
                    MovePlayer();
                }
                JumpPlayer();
                NotClingWalls();
                if(!_dontEnter)
                {
                    Enter();
                }
                
            }
            GetsUp();
        }
        
    }
    private void MovePlayer()
    {
        if(Input.GetAxis("Horizontal") > 0) {
            moving.MoveLogic();
            animplayer.Walk(1);

        }
        if(Input.GetAxis("Horizontal") < 0) {
            moving.MoveLogic();
            animplayer.Walk(1);
        }
        if(Input.GetAxis("Horizontal") == 0) {
            animplayer.Walk(0);
        }    
    }
    private void JumpPlayer() {
        if(Input.GetAxis("Jump") > 0)
        {
            moving.JumpLogic();
            animplayer.JumpAnim(true);
        }
        if(moving.IsGrounded == true)
        {
            animplayer.JumpAnim(false);
        }
    }
    private void Enter() {
        if(Input.GetButton("E"))
        {
            StartCoroutine("enterStop", 0.3f);
        }
    }
    private void NotClingWalls()
    {
        int layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hitright = Physics2D.Raycast(transform.position + beginHit, transform.localScale.x * Vector3.right, rayDistans, layerMask, 0);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position + beginHit, transform.localScale.x * -Vector3.right, rayDistans, layerMask, 0);
        if (hitright.collider != null)
        {
            move = false;
            animplayer.Walk(0);
            if(Input.GetAxis("Horizontal") < 0){move = true;}
        }
        else
        {
            move = true;
        }
        if (hitleft.collider != null)
        {
            move = false;
            animplayer.Walk(0);
            if(Input.GetAxis("Horizontal") > 0){move = true;}
            
        }
        else
        {
            move = true;
        }
    }
    private void GetsUp() {
        if(getsUp == true)
        {
            animplayer.GetsUpAnim(true);
            globalMove = false;
            Invoke("OnMove", 4f);
            animplayer.NoLight(true);
        }
    }
    private void OnMove() {
        globalMove = true;
        animplayer.GetsUpAnim(false);
        

    }
    IEnumerator enterStop(float t)
    {
        move = false;
        animplayer.EnterAnim();
        yield return new WaitForSeconds(t);
        move = true;
    }
}
