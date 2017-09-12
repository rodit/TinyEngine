using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using IniParser.Parser;

namespace TinyEngine
{
    public class Config
    {
        private FileIniDataParser parser;
        public string File { get; set; }
        public IniData Data { get; set; }

        public Config(string file)
        {
            File = file;
            parser = new FileIniDataParser();
            Data = parser.ReadFile(file);
        }

        public void Save()
        {
            parser.WriteFile(File, Data);
        }
    }
}
