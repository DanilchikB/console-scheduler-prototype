using System.Collections.Generic;

namespace Models.ModelSettings{
    class Settings{
        public string LocalDB{get;set;}
        public Dictionary<string,Dictionary<string,string>> Commands{get;set;}
    }
}