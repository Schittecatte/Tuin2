using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vives
{
    class CinemaVisitor
    {
        // static field, zal gedeeld worden met alle 
        // objecten die ooit van CinemaVistor zullen gemaakt worden. 

        public static int ActualNumberOfVisitors = 0;

        public string VisitorName { get; set; }
        public string MovieTitle { get; set; }

        public CinemaVisitor(string pVisitorName, string pMovieTitle)
        {

            VisitorName = pVisitorName;
            MovieTitle = pMovieTitle;

            // nieuwe bezoeker registeren;
            ActualNumberOfVisitors++;

        }
        public override string ToString()
        {

            return VisitorName + " (" + MovieTitle + ")";

        }

//Destructor(omgekeerde van constructor).
    ~CinemaVisitor()
        {

            ActualNumberOfVisitors--;


        }

    }
}
