using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleSys : MonoBehaviour
{
    public int numer_of_colums;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    private float angle;
    public Material material;
    public float spin_speed;
    private float time;
    public ParticleSystem system;


    private void Awake()
    {
        Summon();

    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time * spin_speed);
    }
    void Summon()
    {
        angle = 360 / numer_of_colums;
        for (int i = 0; i < numer_of_colums; i++)
        {

            Material particleMaterial = material;

           
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); 
            go.AddComponent<CollisionEnter>();
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 100000;

            var coll = system.collision;
            coll.enabled = true;
            coll.collidesWith = 7;
            coll.type = ParticleSystemCollisionType.World;
            coll.mode = ParticleSystemCollisionMode.Collision2D;
            coll.sendCollisionMessages = true;
            coll.lifetimeLoss = 1.0f;

            var emission = system.emission;
            emission.enabled = false;

            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            
            var rend = system.GetComponent<Renderer>();

            rend.sortingLayerName = "EnemyBullets";


            var form = system.shape;
            form.enabled = true;
            form.shapeType = ParticleSystemShapeType.Sprite;
            form.sprite = null;

            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);
        }
        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, firerate);
    }

    void DoEmit()
    {

        foreach (Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;

            system.Emit(emitParams, 10);

        }
    }
}








