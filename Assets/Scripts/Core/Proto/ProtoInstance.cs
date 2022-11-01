using UnityEngine;

namespace Proto
{
    public class ProtoInstance : MonoBehaviour
    {
        [SerializeField] private ProtoData _protoData = new ProtoData();

        public ProtoData ProtoData => _protoData;
    }
}