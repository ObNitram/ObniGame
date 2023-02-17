using System;
using UnityEngine;

namespace Main.Character.Module
{
    [Serializable]
    public abstract class AVector2 : MonoBehaviour
    {
        public abstract void SetVector2(Vector2 targetDirection);

        public abstract Vector2 GetVector2();

    }
}