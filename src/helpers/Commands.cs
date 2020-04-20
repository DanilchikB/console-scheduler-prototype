using System;
using Helpers.HelpWorkSettings;
using System.Collections.Generic;

namespace Helpers.HelpCommands{
    class Commands{
        public void ViewAllCommands(){
            WorkSettings ws = new WorkSettings();
            Console.WriteLine("Доступные команды:");

            foreach(KeyValuePair<string, Dictionary<string, string>> command in ws.Settings.Commands){
                Console.WriteLine("    "+command.Value["Command"]+" - "+command.Value["Description"]+".");
            }
            Console.WriteLine();
        }
    }
} 