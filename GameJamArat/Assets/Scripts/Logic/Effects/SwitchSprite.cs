using UnityEngine;
using System.Collections;

public class SwitchSprite : Effect
{
    public Transform Rend_obj;
    
    public Sprite spr1;
    public Sprite spr2;

    public override void Do()
    {
        SpriteRenderer spr_rend = Rend_obj.GetComponent<SpriteRenderer>();

        if (spr_rend.sprite == spr1)
        {
            spr_rend.sprite = spr2;
        }
        else
        {
            spr_rend.sprite = spr1;
        }
    }
}
