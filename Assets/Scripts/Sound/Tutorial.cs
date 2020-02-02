using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TutorialRoutine());
    }

    public IEnumerator TutorialRoutine()
    {
        yield return new WaitForSeconds(3);
        SoundManager.Instance.PlayAudioClip("baue_doch_solarpanele", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2);
        SoundManager.Instance.PlayAudioClip("baumenue", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayAudioClip("baumenue_controls", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(5);
        SoundManager.Instance.PlayAudioClip("sammle_schrott", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayAudioClip("traktor_beam", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayAudioClip("traktor_beam_controls", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(5);
        SoundManager.Instance.PlayAudioClip("batterie", 1);
        while (SoundManager.Instance.IsPlaying())
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(10);
        SoundManager.Instance.PlayAudioClip("seil", 1);
    }
}
