using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_5_HideAndSeek
{
    class Outside : Location
    {
        //=========== Fields ==========//

        private bool _hot;

        //======== Constructors =======//
        public Outside(string name, bool hot) : base(name)
        {
            Hot = hot;
        }

        //======== Properties =========//

        public bool Hot { get { return _hot; } private set { _hot = value; } }

        public override string Description
        {
            get
            {
                if (Hot)
                    return base.Description + " It's very hot here.";
                else
                    return base.Description;
            }
        } 



        //========= Methods ===========//
    }
}
