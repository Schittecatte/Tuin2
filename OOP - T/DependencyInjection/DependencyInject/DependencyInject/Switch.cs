using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vives
{
    enum State { Up,Down};

    class Switch
    {

        IOnOff onOff; // Referentie naar een object dat je wil in- of uitschakelen
                      // Die referentie komt binnen via dependency injection. 
        State state;  // Wat is de stand van de schakelaar. 

        // Constructor die de dependecy injecteert in het huidige object. 
        public Switch (IOnOff onOff)
        {
            this.onOff = onOff;
            state = new State();
            state = State.Down; 
        }

        public void Up()
        {
        if (state != State.Up)
            {
                state = State.Up;
                onOff.On();         // Schakel het object dat kan eender welk type object zijn. 
                                    // dat IOnOff implementeert. 
            }
        }

        public void Down()
        {
            if (state != State.Down)
            {
                state = State.Down;
                onOff.Off(); 
            }
        }






    }
}
