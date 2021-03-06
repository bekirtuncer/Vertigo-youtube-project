using System.Collections;
using System.Collections.Generic;
using TouchControlsKit;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "TopDownShooter/Input/TCK Input Data")]
    public class TCKInputData : AbstractInputData
    {
        public string AxisName;
        public bool IsAction;
        public override void ProcessInput()
        {
            if (IsAction)
            {
                if(TCKInput.GetAction(AxisName, EActionEvent.Down))
                {
                    Horizontal = 1;
                }
                else if (TCKInput.GetAction(AxisName, EActionEvent.Up))
                {
                    Horizontal = 0;
                }
            }
            else
            {
                Vector2 move = TCKInput.GetAxis(AxisName);
                Horizontal = move.x;
                Vertical = move.y;
            } 
        }
    }
}
