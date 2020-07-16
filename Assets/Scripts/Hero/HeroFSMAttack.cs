using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroFSMAttack : HeroFSM
{
    public override void OnEnter(HeroManager _manager)
    {
        base.OnEnter(_manager);
        Manager.Anim.SetBool("Attack", true);
        Manager.Anim.SetInteger("AttackMotion", 1);
        atkMode = 0;
    }

    public override void OnExit(HeroManager _manager)
    {
        base.OnExit(_manager);
        Manager.Anim.SetBool("Attack", false);
        Manager.Anim.SetInteger("AttackMotion", 0);
    }

    int atkMode;
    bool reserve = false;
    bool isLoop = true;
    bool move = false;
    float timer = 0f;

    public GameObject col;

    Vector2 movement;

    public override void OnUpdate()
    {
        base.OnFixedUpdate();
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetMouseButtonDown(1))
        {
            reserve = false;
            isLoop = true;
            move = false;
            timer = 0f;
            Manager.SetState(State.Evade);
            EndCollider();
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnUpdate();

        if (atkMode == 0)
        {
            if(isLoop)
            {
                timer += Time.deltaTime;
                if (timer > 0.2f)
                {
                    move = false;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    reserve = true;
                }
                else if (reserve && timer > 0.35f)
                {
                    isLoop = false;
                    reserve = false;
                    Manager.Anim.SetInteger("AttackMotion", 2);
                }
                else if (timer > 1.0f)
                {
                    isLoop = false;
                    if(movement.x != 0f || movement.y != 0f)
                    {
                        Manager.SetState(State.Move);
                    }
                    else
                    {
                        Manager.SetState(State.Idle);
                    }
                }
            }
        }
        else if (atkMode == 1)
        {
            
            if (isLoop)
            {
                timer += Time.deltaTime;
                if (timer > 0.25f)
                {
                    move = false;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    reserve = true;
                }
                else if (reserve && timer > 0.5f)
                {
                    isLoop = false;
                    reserve = false;
                    Manager.Anim.SetInteger("AttackMotion", 3);
                }
                else if (timer > 1.0f)
                {
                    isLoop = false;
                    if (movement.x != 0f || movement.y != 0f)
                    {
                        Manager.SetState(State.Move);
                    }
                    else
                    {
                        Manager.SetState(State.Idle);
                    }
                }
            }
        }
        else if (atkMode == 2)
        {
            if (isLoop)
            {
                timer += Time.deltaTime;
                if (timer > 0.5f)
                {
                    move = false;
                }
                if (timer > 1.0f)
                {
                    isLoop = false;
                    if (movement.x != 0f || movement.y != 0f)
                    {
                        Manager.SetState(State.Move);
                    }
                    else
                    {
                        Manager.SetState(State.Idle);
                    }
                }
            }
        }

        if(move)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Vector3 velocity = transform.forward;
            velocity = velocity * speed * Time.fixedDeltaTime;
            rigidbody.MovePosition(rigidbody.position + velocity);
        }

    }

    public float speed;

    public void Atk1()
    {
        atkMode = 0;
        reserve = false;
        isLoop = true;
        move = true;
        timer = 0f;
    }

    public void Atk2()
    {
        atkMode = 1;
        reserve = false;
        isLoop = true;
        move = true;
        timer = 0f;
    }

    public void Atk3()
    {
        atkMode = 2;
        reserve = false;
        isLoop = true;
        move = true;
        timer = 0f;
    }

    public void OnCollider()
    {
        col.SetActive(true);
    }
    public void EndCollider()
    {
        col.SetActive(false);
    }

}
