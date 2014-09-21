using UnityEngine;
using System.Collections;

public class GodFingerShake : MonoBehaviour 
{
    public GOD god;
    public NPC npc;
    public CameraShake cam_shake;

    private float max_dist = 10;


    public void Update()
    {
        float dist = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), npc.transform.position);
        if (dist >= max_dist) return;

        float intensity = Mathf.Min(0.03f, (1f / dist) * 0.15f);
        cam_shake.Shake(new CamShakeInstance(intensity, 0.1f));
    }
}
