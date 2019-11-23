using RPG.Control;
using UnityEngine;

namespace Assets.Scripts.Combat
{
    public class NpcTarget : MonoBehaviour, IRaycastable
    {
        public CursorType GetCursorType()
        {
            return CursorType.NPC;
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            throw new System.NotImplementedException();
        }
    }
}
