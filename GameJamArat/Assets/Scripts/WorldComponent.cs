﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum WorldComponentState { FlickeringOn, FlickeringOff, On, Off }

public class WorldComponent : MonoBehaviour 
{
    public List<string> tags = new List<string>();

    private float live_time_max = 1;
    private float live_time;
    private float flicker_time_max = 1;
    private float flicker_time;
    private float mini_flicker_chance = 0.0007f;


    private WorldComponentState state;


    // PUBLIC MODIFIERS
    public void Start()
    {
        live_time = live_time_max;

        state = WorldComponentState.On;
        renderer.enabled = true;
    }

    public void Update()
    {
        // mini flicker random chance
        if (state == WorldComponentState.On && Random.value < mini_flicker_chance) DoMiniFlicker();

        // flickering
        if (state == WorldComponentState.FlickeringOn || state == WorldComponentState.FlickeringOff)
        {
            Flicker();
            flicker_time -= Time.deltaTime;
            if (flicker_time <= 0)
            {
                if (state == WorldComponentState.FlickeringOn) SetOn();
                else SetOff();
            }
        }

        // timing out
        else if (state == WorldComponentState.On)
        {
            live_time -= Time.deltaTime;
            if (live_time <= 0)
            {
                TurnOff();
            }
        }
    }

    private void Flicker()
    {
        if ((int)(flicker_time * 100) % 4 == 0)
        {
            if (Random.value > 0.5f)
            {
                renderer.enabled = true;
            }
            else
                renderer.enabled = false;
        }
    }

    public void TurnOn()
    {
        if (state == WorldComponentState.FlickeringOff) SetOn();
        if (state == WorldComponentState.On || state == WorldComponentState.FlickeringOn) return;
        state = WorldComponentState.FlickeringOn;
        flicker_time = flicker_time_max;
        gameObject.renderer.enabled = true;
    }
    public void TurnOff()
    {
        if (state == WorldComponentState.Off || state == WorldComponentState.FlickeringOff) return;
        state = WorldComponentState.FlickeringOff;
        flicker_time = flicker_time_max;
        gameObject.renderer.enabled = false;
    }

    public void DoMiniFlicker()
    {
        state = WorldComponentState.FlickeringOn;
        flicker_time = flicker_time_max;
        gameObject.renderer.enabled = true;
    }

    private void SetOn()
    {
        renderer.enabled = true;
        state = WorldComponentState.On;
        live_time = live_time_max;
    }
    private void SetOff()
    {
        renderer.enabled = false;
        state = WorldComponentState.Off;
        live_time = 0;
    }


    // PUBLIC ACCESSORS
    public bool IsOn() { return state == WorldComponentState.On || state == WorldComponentState.FlickeringOn; }
    public bool HasTag(string tag) { return tags.Contains(tag); }
}
