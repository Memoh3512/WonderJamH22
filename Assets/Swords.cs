using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : MonoBehaviour
{
   public void PlaySFX()
   {
      
      
      SoundPlayer.instance.PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Sword hit"));
      
   }
}
