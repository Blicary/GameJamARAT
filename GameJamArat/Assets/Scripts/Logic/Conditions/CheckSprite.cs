using UnityEngine;
using System.Collections;

public class CheckSprite : Condition {

    public Transform target_obj;
    public Sprite target_sprite;

    public override bool Met()
    {
        Debug.Log("check sprite");
        SpriteRenderer spr_rend = target_obj.GetComponent<SpriteRenderer>();

        return (spr_rend.sprite == target_sprite);
    }
}
