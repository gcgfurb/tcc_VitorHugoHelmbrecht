using UnityEngine;

namespace Assets.Scripts
{
    public class SetColorOnLoad : MonoBehaviour
    {
        public Material material;

        void Start() {
            material.color = Utils.Utils.Color;
        }
    }
}