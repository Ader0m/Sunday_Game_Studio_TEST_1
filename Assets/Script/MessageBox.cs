using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    public class MessageBox: MonoBehaviour
    {
        public int ImageNum;

        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
