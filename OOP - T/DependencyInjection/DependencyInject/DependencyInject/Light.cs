using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives;

namespace DependencyInject
{
    class Light : IOnOff
    {
        public bool IsOn { get; set; }



        public void Off()
        {
            Debug.WriteLine("Light is turned off");
            IsOn = false; 
        }

        public void On()
        {
            Debug.WriteLine("Light is turned onn");
            IsOn = true;
        }
    }
}
