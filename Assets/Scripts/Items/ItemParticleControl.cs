using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParticleControl : MonoBehaviour
{
    public static ItemParticleControl Instance;
    [SerializeField] private ParticleSystem particlePrefab;
    Queue<ParticleSystem> particles = new Queue<ParticleSystem>();
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        particles = new Queue<ParticleSystem>();

        for (int i = 0; i < 50; ++i)
        {
            ParticleSystem spawned = Instantiate(particlePrefab);
            particles.Enqueue(spawned);
            spawned.transform.SetParent(transform);
        }
        
    }

    
    public void Play(Transform parent)
    {
        if(particles.Count <= 0)
            return;
        
        ParticleSystem nowParticle = particles.Dequeue();
        nowParticle.transform.SetParent(parent);
        nowParticle.transform.position = parent.position;
        nowParticle.Play();
        
        StartCoroutine(Utility.DelayAction(1.5f, () =>
        {
            particles.Enqueue(nowParticle);
        }));


    }
}
