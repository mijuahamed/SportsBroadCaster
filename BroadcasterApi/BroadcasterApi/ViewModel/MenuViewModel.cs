using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class MenuViewModel
    {
        public int Id { set; get; }
        public int RootId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Url { get; set; }
        public MenuViewModel MenuObj { set; get; }

    }
}
