using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ManaColor
{
    Empty,
    Red,
    Blue,
    Yellow,
}
public class ManaPaletteCore : MonoBehaviour
{
    [SerializeField] private ManaColor manaColor;
    [SerializeField] private ManaPaletteVisual manaPaletteObj;

    //For Blue , YellowSpell
        private PlayerHP playerHP;
    [Header("Yellow Magic")]

    [SerializeField] private float barrierDuration = 5;

    [Header("Blue Magic")]
    [SerializeField] private float invisibleDuraion = 5;


    [Header("Red Magic")]
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float rushDuration;
    private PlayerStateManager player;
    [SerializeField] private Animator anim;
   


    void Start()
    {
        player = GetComponent<PlayerStateManager>();
        playerHP = GetComponent<PlayerHP>();
        anim = player.animator;
        EmptyManaColor();
    }


    public void AddMana(ManaColor mana)
    {
        manaColor = mana;
        manaPaletteObj.SetManaColor(mana);
    }
    public void UsingMagic()
    {
        switch (manaColor)
        {
            case ManaColor.Blue:
                BlueManaInvisible();
                break;
            case ManaColor.Red:
                RedManaRush();
                break;
            case ManaColor.Yellow:
                YellowManaBarrier();
                break;
            default:
                Debug.Log("Empty");
                break;
        }
        EmptyManaColor();
    }

    void EmptyManaColor()
    {

        manaPaletteObj.SetManaColor(ManaColor.Empty);
        manaColor = ManaColor.Empty;

    }
    void YellowManaBarrier()
    {
        playerHP.GainBarrier(barrierDuration);
    }
    void BlueManaInvisible()
    {
        anim.SetBool("WaterCast" , true);
        anim.SetTrigger("CastWater");
        playerHP.StartTheInvincibelState(invisibleDuraion);
    }
    void RedManaRush()
    {
        Debug.Log("Rush");
        StartCoroutine(player.RushingState(speedMultiplier, rushDuration));
    }
    
}
    



