using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFSMMove : HeroFSM
{
    public override void OnEnter(HeroManager _manager)
    {
        base.OnEnter(_manager);
        Manager.Anim.SetBool("Move", true);
    }

    public override void OnExit(HeroManager _manager)
    {
        base.OnExit(_manager);
        Manager.Anim.SetBool("Move", false);
    }

    public float speed;
    public float rotSpeed;

    Vector3 movement;
    Quaternion newRot;

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (Input.GetMouseButtonDown(0))
        {
            Manager.SetState(State.Attack);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Manager.SetState(State.Evade);
        }

    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        newRot = Quaternion.LookRotation(movement);

        if (movement.x != 0f || movement.z != 0f)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            Vector3 velocity = movement * speed * Time.fixedDeltaTime;

            //rigidbody.velocity = velocity;

            rigidbody.MovePosition(rigidbody.position + velocity);
            rigidbody.MoveRotation(Quaternion.Slerp(rigidbody.rotation, newRot, rotSpeed * Time.deltaTime));
        }
        else
        {
            Manager.SetState(State.Idle);
        }

    }
}
