using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CupheadModdingTemplate;

public class Veggies
{
    public void Init()
    {
        new VeggiesOnion().Init();
        new VeggiesPotato().Init();
    }
}
