using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;    
    private Animator animator;
    public float CurrentHealth;
    public Slider slider;
    public Vector3 SliderOffset;
    public bool IsDead;
    public bool deadSFX;
    public float def = 0f;
    [HideInInspector]public float finalDamage;
    public int parry;
    public int willCreate = 1;
    public bool isTakeDamage = false;


    // ******************** Flash Stuff*********************
    public Material flashMaterial;
    public float duration = .1f;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    void Start()
    {
        deadSFX = false;
        CurrentHealth = MaxHealth;
        setmaxhealth(MaxHealth);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + SliderOffset);
        if (CurrentHealth <= 0)
        {
            IsDead = true;

            if (deadSFX == false)
            {
                AudioManagerTwo.instance.PlayPlayerDeathSFX();
                AudioManagerTwo.instance.PlayGameOverSFX();
                deadSFX = true;
            }

        }
        else
            IsDead = false;        
    }

   
    public void TakeDamage(float damage)
    {
        isTakeDamage = true;
        AudioManagerTwo.instance.PlayPlayerHitSFX();
        if (def != 0)
        {
            finalDamage = Mathf.Max(((damage*def)*parry)*willCreate, 0);            
        }
        else
        {
            finalDamage = (damage*parry)*willCreate;            
        }
        CurrentHealth -= finalDamage;
        sethealth(CurrentHealth);
        Flash();
        

    }
    public void Heal(float Healing)
    {
        if (CurrentHealth + Healing >= MaxHealth)
        {
            CurrentHealth = MaxHealth;

        }
        else
        {
            CurrentHealth += Healing;
        }

    }
    public void setmaxhealth(float mhealth)
    {

        slider.maxValue = mhealth;

        slider.value = mhealth;



    }

    public void sethealth(float health)
    {


        slider.value = health;

        //  slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Color.red, Color.green, slider.normalizedValue);
    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        if (flashMaterial != null)
            spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }


}

