using UnityEngine;
using System.Collections;

public class SetSprite : Effect {

    public Transform Rend_obj;

    public Sprite spr1;

    public override void Do()
    {
        SpriteRenderer spr_rend = Rend_obj.GetComponent<SpriteRenderer>();

        spr_rend.sprite = spr1;

    }
}