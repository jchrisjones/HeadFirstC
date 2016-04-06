using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_5_HideAndSeek
{
    interface IHidingPlace
    {
        string HidingPlace { get;}

        int HidingPlaceChecked { get; set; }
    }
}
