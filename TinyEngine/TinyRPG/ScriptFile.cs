using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TinyEngine.TinyRPG
{
    public class ScriptFile : TinyAsset
    {
        public bool IsSaved { get; set; }
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                IsSaved = false;
            }
        }

        public ScriptFile(string name) : base(name)
        {
            _content = "";
        }

        public new string GetPath()
        {
            return Project.Current.GetScript(Name);
        }

        public void Load()
        {
            _content = File.ReadAllText(GetPath());
            IsSaved = true;
        }

        public void Save()
        {
            File.WriteAllText(GetPath(), Content);
            IsSaved = true;
        }

        public override string ToString()
        {
            return FileName;
        }
    }
}
