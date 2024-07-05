using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Utils.ApiClients.YandexApi
{
    internal class Tr
    {
        public string? text { get; set; }
        public string? pos { get; set; }
        public Syn[]? syn { get; set; }
        public Mean[]? mean { get; set; }
        public Ex[]? ex { get; set; }
    }
}
