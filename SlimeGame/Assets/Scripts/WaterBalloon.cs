using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

//Globo de agua - gestiona lanzamiento, daño y explosion
public class WaterBalloon : Gun
{
    public float delay = 10f;
    float radius = 3f;

    public GameObject waterExplosion;

    float countdown;
    bool hasExploded = false;

    PhotonView id;

    void Awake()
    {
        id = GetComponent<PhotonView>();
        if (!id.IsMine)
        {
            Destroy(GetComponent<Rigidbody>());
        }
    }
    private void Start()
    {
        GameManager.am.playSound(5, 1f);
        countdown = delay;
    }

    private void Update()
    {
        if (id.IsMine)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0 && !hasExploded)
            {
                hasExploded = true;
                Explode();
            }
        }
    }
    public override void Use()
    {

    }

    void Explode()
    {
        //Mostrar particulas de agua
        PhotonNetwork.Instantiate(Path.Combine("SimpleFX", "Prefabs", "FX_BlueExplosion"), transform.position, transform.rotation);
        //Comprobar objetos cercanos
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider c in colliders)
        {
            if (c.gameObject.CompareTag("Player") && c.GetType()!=typeof(CharacterController))
            {
                c.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
            }
        }
        //Destroy gameobject
        id.RPC("RPC_Destroy", RpcTarget.All);
    }
    [PunRPC]
    void RPC_Destroy()
    {
        GameManager.am.playSound(4, 1f);
        Destroy(gameObject);
    }

    public override void End(){}
}
