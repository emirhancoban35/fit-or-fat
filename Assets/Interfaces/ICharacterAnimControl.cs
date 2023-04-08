using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterAnimControl
{
   void WalkingAnimation(bool isWalking);
   void DeadAnimation();
   void LevelFinishAnimation();
}