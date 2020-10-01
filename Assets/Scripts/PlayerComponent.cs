using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ShipComponent))]
public class PlayerComponent : MonoBehaviour
{
    public List<Transform> barrels;
    private Animator animator;
    private Vector3 prevPos;
    private Vector3 velocity;
    private ShipComponent shipComponent;
    private bool isShooting;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        shipComponent = GetComponent<ShipComponent>();
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateVelocity();
        Animations();
    }

    public List<Transform> GetActiveBarrels()
    {
        List<Transform> listRtn = new List<Transform>();
        foreach (var barrel in barrels)
        {
            if (barrel.gameObject.activeSelf)
                listRtn.Add(barrel);
        }
        return listRtn;
    }

    public void Shoot()
    {
        isShooting = true;
    }

    public void ReleaseShoot()
    {
        isShooting = false;
    }

    void Animations(){
        string currentAnimationName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if(!shipComponent.isDead()){
            if(velocity.y>0f){
                if(currentAnimationName!="SpeedingUp")
                    animator.Play("Base Layer.SpeedingUp", 0, 0);
            }else{
                if(currentAnimationName!="Idle")
                    animator.Play("Base Layer.Idle", 0, 0);
            }
        }else{
            if(currentAnimationName!="Explosion")
                animator.Play("Base Layer.Explosion", 0, 0);
        }
    }

    void CalculateVelocity(){
        velocity = (transform.position - prevPos) * Time.deltaTime;
        prevPos = transform.position;
    }
}
