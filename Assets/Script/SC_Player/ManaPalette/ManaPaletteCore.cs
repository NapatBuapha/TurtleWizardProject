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
    [SerializeField] private ManaPaletteVisual[] manaPaletteObj;

    void Start()
    {
        manaColor = new ManaColor[2];
        EmptyManaColor();
    }


    public void AddMana(ManaColor mana)
    {
        if (manaColor[0] != ManaColor.Empty)
        {
            manaPaletteObj[1].SetManaColor(manaColor[0]);
            manaColor[1] = manaColor[0];

            manaPaletteObj[0].SetManaColor(mana);
            manaColor[0] = mana;
            CheckforColorCombine();
        }
        else
        {
            manaPaletteObj[0].SetManaColor(mana);
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
                    yellow++;
                    break;
                case ManaColor.Blue:
                    blue++;
                    break;
            }
        }

        if (red == 1 & blue == 1)
        {
            EmptyManaColor();
            AddMana(ManaColor.Purple);
        }
        if (red == 1 & yellow == 1)
        {
            EmptyManaColor();
            AddMana(ManaColor.Orange);
        }
        if (yellow == 1 & blue == 1)
        {
            EmptyManaColor();
            AddMana(ManaColor.Green);
        }
    }

    void EmptyManaColor()
    {
        for (int i = 0; i < manaColor.Length; i++)
        {
            manaPaletteObj[i].SetManaColor(ManaColor.Empty);
            manaColor[i] = ManaColor.Empty;
        }
    }
}
    



