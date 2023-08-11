using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public int health;

    [SerializeField] private GameObject[] equipmentArr;
    [SerializeField] private ParticleSystem[] flameArr;

    [SerializeField] private float thrustForce;
    [SerializeField] private float maxHeat;
    [SerializeField] private float heatRate;
    [SerializeField] private float waitForSec;
    [SerializeField] private float cooldownRate;

    [SerializeField] private GameObject anchor;
    [SerializeField] private GameObject ionEffect;
    [SerializeField] private GameObject harpoonSpear;

    private PlayerInput playerInput;
    private float heat = 0f; //Thruster heat
    private float timer = 0f;
    private Vector2 moveVec2;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        OverheatManager.instance.setMaxHeat(maxHeat);
        HealthManager.instance.setMaxHealth(health);

        equipmentArr[0].SetActive(true);
    }

    private void FixedUpdate()
    {
        if (heat < maxHeat)
        {
            rb.AddForce(moveVec2 * thrustForce);
            playFlameParticles();
            equipmentSwap();

            if (moveVec2 != Vector2.zero)
            {
                heat += heatRate * Time.deltaTime;
                OverheatManager.instance.updateHeat(heat);
            }
            else
            {
                cooldown();
            }
        }
        else
        {
            overheating();
        }
        OverheatManager.instance.updateHeat(heat);
    }

    private void OnMove(InputValue value)
    {
        moveVec2 = value.Get<Vector2>();
    }

    private void OnFire()
    {
        Camera cam = Camera.main;
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (equipmentArr[0].activeSelf)
        {
            if (ionEffect.activeSelf)
            {
                ionEffect.SetActive(false);
            }
            else
            {
                ionEffect.SetActive(true);
            }
        }
        else if (equipmentArr[1].activeSelf)
        {
            var hook = Instantiate(harpoonSpear, mousePos, anchor.transform.rotation);
            hook.GetComponent<hook>().caster = anchor.transform;
        }
    }

    private void cooldown()
    {
        if (heat > 0f)
        {
            heat -= (heatRate / cooldownRate) * Time.deltaTime;
        }
    }
    private void overheating()
    {
        //Disabling objects when overheated
        ionEffect.SetActive(false);
        OverheatManager.instance.displayOverheatTxt(true);
        playerInput.currentActionMap.Disable();
        foreach (ParticleSystem flame in flameArr)
        {
            flame.Stop();
        }

        if (timer < waitForSec)
        {
            timer += 1 * Time.deltaTime;
        }
        else
        {
            heat = 0f;
            timer = 0f;

            playerInput.currentActionMap.Enable();
            OverheatManager.instance.displayOverheatTxt(false);
        }
    }

    private void equipmentSwap()
    {
        if (Input.GetKey("1"))
        {
            equipmentArr[0].SetActive(true);
            equipmentArr[1].SetActive(false);
            EquipmentUIManager.instance.setEquipmentUI("1");
        }
        else if(Input.GetKey("2"))
        {
            equipmentArr[1].SetActive(true);
            equipmentArr[0].SetActive(false);
            EquipmentUIManager.instance.setEquipmentUI("2");
        }
    }

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

    //Collision with Debris
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ship Collision");
        if (collision.collider.tag == "DebrisL" || collision.collider.tag == "DebrisS")
        {
            health -= 1;
            HealthManager.instance.updateHealth(health);
        }
    }
}

