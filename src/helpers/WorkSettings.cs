using Models.ModelSettings;
using System.Text.Json;
using System.IO;

namespace Helpers.HelpWorkSettings{
    class WorkSettings{
        
        public WorkSettings(){
            GetSettings();
        }
        public Settings Settings{get; private set;}
        private void GetSettings(){

            string jsonString = File.ReadAllText("settings.json");

            Settings = JsonSerializer.Deserialize<Settings>(jsonString);
            
        }
    }

}