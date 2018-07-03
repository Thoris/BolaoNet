using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Chart
{
    public class SerieValueModelView
    {
        public bool area { get; set; }
        public List<EntryXyValueModelView> values { get; set; }
        public string key { get; set; }
        public int strokeWidth { get; set; }
    }
}
