using RPG.Combat;
using RPG.Control;
using RPG.Attributes;
using UnityEngine;

namespace RPG.Combat
{
    
    public class NpcTarget : MonoBehaviour, IRaycastable
    {
        public CursorType GetCursorType()
        {
            return CursorType.NPC;
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            if (!callingController.GetComponent<Fighter>().CanAttack(gameObject))
            {
                return false;
            }
            if (Input.GetMouseButton(0))
            {
                callingController.GetComponent<Fighter>().Attack(gameObject);
            }
            return false;
        }
    }
}
