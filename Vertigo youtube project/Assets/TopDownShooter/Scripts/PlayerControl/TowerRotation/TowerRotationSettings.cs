using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "TopDownShooter/Player/Tower Rotation Settings")]
    public class TowerRotationSettings : ScriptableObject
    {
        public float TowerRotationSpeed = 1;
    }
}
