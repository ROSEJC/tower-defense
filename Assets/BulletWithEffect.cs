using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWithEffect : Bullet
{
    [SerializeField]protected ParticleSystem effect;
    [SerializeField]protected GameObject Arrow;
    public void effectOn()
    {
        effect.Play();
    }

    public void effectOff()
    {
        effect.Stop();
    }

    public void ArrowSpriteOn()
    {
        Arrow.SetActive(true);
    }

    public void ArrowSpriteOff()
    {
        Arrow.SetActive(false);
    }

   
}
