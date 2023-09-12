using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public int health;

    [SerializeField] private GameObject[] equipmentArr; //Equipment Array
    [SerializeField] private ParticleSystem[] flameArr; //Thruster Flame Particle Array

    [SerializeField] private float thrustForce; //Thruster Force
    [SerializeField] private float maxHeat, heatRate; //Overheat
    [SerializeField] private float waitForSec, cooldownRate; //Cooldown
    [SerializeField] private float releaseForce; //Force applied when releasing debris (harpoon)

    [SerializeField] private GameObject lineStart, anchor, harpoon; //Space Harpoon
    [SerializeField] private GameObject ionEffect; //Ion Wave Gun

    private PlayerInput playerInput; //Player Input
    private float heat = 0f; //Thruster heat
    private float timer = 0f; //Overheat timer
    private Vector2 moveVec2; //Movement Vector
    private Rigidbody2D rb; //Rigidbody
    private GameObject childDebris; //Debris parented to ship

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        
        //Setting up UI
        OverheatManager.instance.setMaxHeat(maxHeat);
        HealthManager.instance.setMaxHealth(health);

        //Activate the 1st equipment (Ion Wave Gun)
        equipmentArr[0].SetActive(true);
        equipmentArr[1].SetActive(false);
    }
    private void Update()
    {
        equipmentSwap();
    }
    private void FixedUpdate()
    {
        //If heat has not reached maximum heat limit, allow movement.
        if (heat < maxHeat)
        {
            rb.AddForce(moveVec2 * thrustForce);

            playFlameParticles();
            
            //If moving, increase heat
            if (moveVec2 != Vector2.zero)
            {
                heat += heatRate * Time.deltaTime;
                OverheatManager.instance.updateHeat(heat);
            }
            else //Else decrease heat
            {
                cooldown();
            }
        }
        else //Else overheat
        {
            overheating();
        }
        OverheatManager.instance.updateHeat(heat);
    }
    //Player movement, and play thruster sounds
    private void OnMove(InputValue value)
    {
        moveVec2 = value.Get<Vector2>();
        SFXManager.instance.playThrusters();
    }
    //Player activating equipment
    private void OnFire()
    {
        //Activate Ion effect if 1st equipment is active
        if (equipmentArr[0].activeSelf)
        {
            fireIon();
        }
        //Check if 2nd equipment is active and if there are no other harpoons in game
        else if (equipmentArr[1].activeSelf && GameObject.FindGameObjectsWithTag("Harpoon").Length == 0) 
        {
            fireHarpoon();
        }
    }
    //Check if there is a debris parented to ship
    private bool harpoonedDebris()
    {
        bool _containDebris = false;
        foreach (Transform i in equipmentArr[1].transform)
        {
            if (i.gameObject.tag == "DebrisL" || i.gameObject.tag == "DebrisS")
            {
                childDebris = i.gameObject;
                _containDebris = true;
            }
        }
        return _containDebris;
    }
    //Activate Ion Effect
    private void fireIon()
    {
        if (ionEffect.activeSelf)
        {
            SFXManager.instance.playIonWave(false);
            ionEffect.SetActive(false);
        }
        else
        {
            SFXManager.instance.playIonWave(true);
            ionEffect.SetActive(true);
        }
    }
    //Fire Harpoon
    private void fireHarpoon()
    {
        //If there is no debris parented, instantiate a harpoon
        if (!harpoonedDebris())
        {
            var _harpoon = Instantiate(harpoon, lineStart.transform.position, anchor.transform.rotation);
            _harpoon.GetComponent<HarpoonBehaviour>().caster = lineStart.transform; //Set caster variable to lineStart
        }
        else //Release debris
        {
            childDebris.GetComponent<Rigidbody2D>().isKinematic = false;

            //Push object away from player
            Vector2 diff = childDebris.transform.position - lineStart.transform.position;
            childDebris.GetComponent<Rigidbody2D>().AddForce(diff * releaseForce, ForceMode2D.Impulse);

            //Reset debris status
            childDebris.GetComponent<Collider2D>().isTrigger = false;
            childDebris.transform.parent = null;
        }
    }
    //Decrease heat
    private void cooldown()
    {
        if (heat > 0f)
        {
            heat -= (heatRate / cooldownRate) * Time.deltaTime;
        }
    }
    //Overheated
    private void overheating()
    {
        //Disabling object states when overheated
        ionEffect.SetActive(false);
        OverheatManager.instance.displayOverheatTxt(true);
        playerInput.currentActionMap.Disable();
        //Stop all flame effects
        foreach (ParticleSystem flame in flameArr)
        {
            flame.Stop();
        }
        //Start penalty timer
        if (timer < waitForSec)
        {
            timer += 1 * Time.deltaTime;
        }
        else
        {
            //Reset heat and timer
            heat = 0f;
            timer = 0f;

            //Enable objects
            playerInput.currentActionMap.Enable();
            OverheatManager.instance.displayOverheatTxt(false);
        }
    }
    //Swap equipment
    private void equipmentSwap()
    {
        //If 1 is pressed and there are no debris parented, swap to equipment 1
        if (Input.GetKeyDown("1") && !harpoonedDebris())
        {
            SFXManager.instance.playSwap();
            equipmentArr[0].SetActive(true);
            equipmentArr[1].SetActive(false);
            EquipmentUIManager.instance.setEquipmentUI("1");
        }
        //If 2 is pressed, swap to equipment 2
        if (Input.GetKeyDown("2"))
        {
            SFXManager.instance.playSwap();
            equipmentArr[1].SetActive(true);
            equipmentArr[0].SetActive(false);
            EquipmentUIManager.instance.setEquipmentUI("2");
        }
    }
    //Play flame particle system
    private void playFlameParticles()
    {
        //Horizontal Thrust
        if (moveVec2.x > 0)
        {
            flameArr[0].Play();
            flameArr[1].Stop();
        }
        else if (moveVec2.x < 0)
        {
            flameArr[1].Play();
            flameArr[0].Stop();
        }
        else
        {
            flameArr[0].Stop();
            flameArr[1].Stop();
        }

        //Vertical Thrust
        if (moveVec2.y < 0)
        {
            flameArr[2].Play();
            flameArr[3].Stop();
        }
        else if (moveVec2.y > 0)
        {
            flameArr[3].Play();
            flameArr[2].Stop();
        }
        else
        {
            flameArr[2].Stop();
            flameArr[3].Stop();
        }
    }

    //Collision with Debris, decrease health
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ship Collision");
        if (collision.collider.tag == "DebrisL" || collision.collider.tag == "DebrisS")
        {
            health -= 1;
            HealthManager.instance.updateHealth(health);
            SFXManager.instance.playDamaged();
        }
    }
}

