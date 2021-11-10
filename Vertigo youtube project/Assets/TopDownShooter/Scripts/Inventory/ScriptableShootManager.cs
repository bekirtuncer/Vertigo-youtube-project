using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Stat;
using UniRx;

namespace TopDownShooter.Inventory 
{
    [CreateAssetMenu(menuName ="TopDownShooter/Inventory/ScriptableShootManager")]
    public class ScriptableShootManager : AbstractScriptableManager<ScriptableShootManager>
    {
        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("scriptable shoot manager activated");
        }

        public override void Destroy()
        {
            base.Destroy();
            Debug.Log("scriptable shoot manager destroyed");
        }

        public void Shoot(Vector3 origin, Vector3 direction, IDamage damage)
        {
            RaycastHit rHit;
            var physic = Physics.Raycast(origin, direction, out rHit);
            MessageBroker.Default.Publish(new EventPlayerShoot(origin));
            if (physic)
            {
                int colliderInstanceId = rHit.collider.GetInstanceID();
                if (DamagebleHelper.DamagebleList.ContainsKey(colliderInstanceId)) 
                {
                    DamagebleHelper.DamagebleList[colliderInstanceId].Damage(damage);
                }
            }
        }
    }
}
