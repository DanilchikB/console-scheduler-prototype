using System;
using Helpers.HelpWorkSettings;
using System.Collections.Generic;

namespace Helpers.HelpCommands{
    class Commands{
        public void ViewAllCommands(WorkSettings ws){
            
            Console.WriteLine("Доступные команды:");

            foreach(KeyValuePair<string, Dictionary<string, string>> command in ws.Settings.Commands){
                Console.WriteLine("    "+command.Value["Command"]+" - "+command.Value["Description"]+".");
            }
            Console.WriteLine();
        }

        public string takeCommand(string enterCommand, WorkSettings ws){

            enterCommand = enterCommand.Trim();
            foreach(KeyValuePair<string, Dictionary<string, string>> command in ws.Settings.Commands){
                if(enterCommand == command.Value["Command"]){
                    return command.Key;
                }
            }
            return null;
        }
    }
} 