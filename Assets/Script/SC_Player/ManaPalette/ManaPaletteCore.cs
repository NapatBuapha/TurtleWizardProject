using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ManaColor
{
    Empty,
    Red,
    Blue,
    Yellow,
    Purple,
    Orange,
    Green
}
public class ManaPaletteCore : MonoBehaviour
{
    [SerializeField] private ManaColor[] manaColor;
    // Start is called before the first frame update
    void Start()
    {
        manaColor = new ManaColor[2];
        for (int i = 0; i < manaColor.Length; i++)
        {
            manaColor[i] = ManaColor.Empty;
        }
    }


    void Update()
    {

    }

    public void AddMana(ManaColor mana)
    {
        if (manaColor[0] != ManaColor.Empty)
        {
            manaColor[1] = manaColor[0];
            manaColor[0] = mana;
            CheckforColorCombine();
        }
        else
        {
            manaColor[0] = mana;

        }
    }
    void CheckforColorCombine()
    {
        int red = 0, yellow = 0, blue = 0;
        for (int i = 0; i < manaColor.Length; i++)
        {
            switch (manaColor[i])
            {
                case ManaColor.Red:
                    red++;
                    break;
                case ManaColor.Yellow:
                    red++;
                    break;
                case ManaColor.Blue:
                    red++;
                    break;
            }
        }

        if (red == 1 & blue == 1)
        {
            AddMana(ManaColor.Purple);
        }
        if (red == 1 & yellow == 1)
        {
            AddMana(ManaColor.Orange);
        }
        if (yellow == 1 & blue == 1)
        {
            AddMana(ManaColor.Green);
        }
    }
}
    



