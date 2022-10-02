using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    private int dollarsStolen;
    private int dollars;
    public static FlagManager current;
    public int startCash;

    private bool[] flagArray;
    private void Awake()
    {
        current = this;        
        flagArray = new bool[System.Enum.GetNames(typeof(flags)).Length];
        dollars = startCash;
        dollarsStolen = 0;
    }

    public bool TakeMoney(int v)
    {
        dollars -= v;
        if (dollars < 0)
            return true;
        dollarsStolen += v;
        if (dollarsStolen < 15)
        {
            AudioManager.current.coinSource.Play();
        }
        TextManager.current.UpdateCashText(dollars);
        return false;
    }

    public void SetFlag(flags flagToSet, bool newState)
    {
        flagArray[(int)flagToSet] = newState;
    }

    public bool GetFlag(flags flag)
    {
        return flagArray[(int)flag];
    }

    public void GainMoney(int amount)
    {
        dollars += amount;
        TextManager.current.UpdateCashText(dollars);
        AudioManager.current.coinSource.Play();
    }

    public int GetMoney()
    {
        return dollars;
    }
}


public enum flags
{
    hasShovel,
    gotMoneyFromSandbox,
    hasCards,
    hasApple,
    hasBug1,
    hasBug2,
    hasBug3,
    hasBadge,
    tizGF,
    hasDeadBird,
    hasBall,
    hasCandyBar
}