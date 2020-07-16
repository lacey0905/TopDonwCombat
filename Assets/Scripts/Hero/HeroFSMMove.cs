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

    public override void OnUpdate()
    {
        base.OnUpdate();

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }
}
