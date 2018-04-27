using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vives
{
    public class Microcontroller : IComparable
    {
        public string name { get; set; }
        public int ClockFre { get; set; }
        public double NumberOfInstructionsPerClockCycle { get; set; }
        public double MIPS
        {
            get
            {
                return ClockFre * NumberOfInstructionsPerClockCycle;
            }
        }

        public Microcontroller(string pName = "NA", int pClockFre = 0, double pNOIPCC = 0)
        {
            this.name = pName;
            this.ClockFre = pClockFre;
            this.NumberOfInstructionsPerClockCycle = pNOIPCC; 
        }

        public static  bool operator >(Microcontroller a, Microcontroller b)
        {
            if (a.MIPS > b.MIPS)
                return true;
          

            return false;
        }

        public static bool operator <(Microcontroller a, Microcontroller b)
        {
            if (a.MIPS < b.MIPS)
                return true;
          

            return false;
        }

        public static bool operator ==(Microcontroller a, Microcontroller b)
        {
            if (a.MIPS == b.MIPS)
                return true;
           

            return false;
        }

        public static bool operator !=(Microcontroller a, Microcontroller b)
        {
            if (a.MIPS != b.MIPS)
                return true;
           

            return false;
        }



        public override string ToString()
        {
            return ("\r\nname: " + name + "\r\nClock Frequency: " + ClockFre + "\r\nNumberOfInstructions: " + NumberOfInstructionsPerClockCycle + "\r\nMIPS: " + MIPS); 
        }
        // hier kan je programmeren hoe je dat .net jou microcontrollers 
        // moet vergelijken. 
        public int CompareTo(object obj)
        {
            if ((obj == null) || (obj.GetType() != typeof(Microcontroller))) {
                return 0;  // verkeerde vergelijking geef nul terug. 
            }
            Microcontroller microcontrollerToCompare =
                obj as Microcontroller;

           // de mips van beide microontroller vergelijking.
           // Dit gebeurt via compareto van de double struct. 
            return this.MIPS.CompareTo(microcontrollerToCompare.MIPS); 
        }
        // vergelijkt de referentie van de obejecten in de heap. 
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        // voorziet een snelle zoek methode in collections.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
