﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class TriggerScript : MonoBehaviour
{
    public float dam;
    public GameObject player;
    ParticleSystem ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
        
    }
    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
           player = GameObject.FindGameObjectWithTag("Player");
            ps.trigger.SetCollider(0, player.GetComponent<CircleCollider2D>());
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.tag);
        //// get the particles which matched the trigger conditions this frame
        //int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        //// iterate through the particles which entered the trigger and make them red
        //for (int i = 0; i < numEnter; i++)
        //{
        //    ParticleSystem.Particle p = enter[i];
        //    p.startColor = new Color32(255, 0, 0, 255);
        //    enter[i] = p;
        //}

        //// iterate through the particles which exited the trigger and make them green
        //for (int i = 0; i < numExit; i++)
        //{
        //    ParticleSystem.Particle p = exit[i];
        //    p.startColor = new Color32(0, 255, 0, 255);
        //    exit[i] = p;
        //}

        //// re-assign the modified particles back into the particle system
        //ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }
    int i = 0;
    void OnParticleTrigger()
    {
        i++;
        Debug.Log("enter: "+i);
        player.GetComponent<PlayerHealth>().beEnterTrigger(dam);
        // get the particles which matched the trigger conditions this frame
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        // iterate through the particles which entered the trigger and make them red
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color32(255, 0, 0, 255);
            enter[i] = p;
        }

        // iterate through the particles which exited the trigger and make them green
        for (int i = 0; i < numExit; i++)
        {
            ParticleSystem.Particle p = exit[i];
            p.startColor = new Color32(0, 255, 0, 255);
            exit[i] = p;
        }

        // re-assign the modified particles back into the particle system
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }
}