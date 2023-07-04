using UnityEngine;

namespace Assets.Script.Tools
{
    public class MessageBox : MonoBehaviour
    {
        public int ImageNum;

        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
