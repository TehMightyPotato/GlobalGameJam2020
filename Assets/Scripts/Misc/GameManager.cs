using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public EventHandler<LocationChangedArgs> OnPlayerLocationChanged;

    public int navigationCount;
    public int shieldCount;
    public int boosterCount;

    private bool hasWon = false;

    public void PlayerLocationChanged(object sender, bool onStation)
    {
        OnPlayerLocationChanged?.Invoke(sender, new LocationChangedArgs(onStation));
    }

    public void CheckForWin()
    {
        if(navigationCount > 0 && shieldCount > 0 && boosterCount > 0)
        {
            hasWon = true;
            StartCoroutine(WinRoutine());
        }
    }

    public void SetWinCondition(int val, WinCondition winCondition)
    {
        if (hasWon) return;
        switch (winCondition)
        {
            case WinCondition.Booster:
                boosterCount += val;
                break;
            case WinCondition.Navigation:
                navigationCount += val;
                break;
            case WinCondition.Shield:
                shieldCount += val;
                break;
        }
        CheckForWin();
    }

    public IEnumerator WinRoutine()
    {
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayAudioClip("win1", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayAudioClip("win2", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2);
        SoundManager.Instance.PlayAudioClip("credit1", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayAudioClip("credit2", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayAudioClip("credit3", 1);
        yield break;
    }

}

public class LocationChangedArgs : EventArgs
{
    public bool onStation;
    public LocationChangedArgs(bool onStation)
    {
        this.onStation = onStation;
    }
}
