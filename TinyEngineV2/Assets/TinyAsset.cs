using System;
using System.IO;

namespace TinyEngine.Assets
{
    public class TinyAsset
    {
        protected string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string FileName
        {
            get
            {
                return Path.GetFileName(_name);
            }
        }

        public TinyAsset(string name)
        {
            _name = name;
        }

        public string GetPath()
        {
            return TinyEngine.Project.GetAsset(Name);
        }
    }
}
