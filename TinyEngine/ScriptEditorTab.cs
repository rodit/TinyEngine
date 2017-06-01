using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using ScintillaNET;
using ScintillaNET_FindReplaceDialog;
using TinyEngine.TinyRPG;
using org.freeinternals.format.classfile;

namespace TinyEngine
{
    public class ScriptEditorTab : TabPage
    {
        private static Dictionary<string, ClassFile> classes = new Dictionary<string, ClassFile>();
        private static Dictionary<string, ClassFile> keywordToClass;
        private static Dictionary<ClassFile, string> classToKeywords = new Dictionary<ClassFile, string>();

        public static ClassFile LoadClassFile(string path)
        {
            if (classes.ContainsKey(path))
                return classes[path];
            return classes[path] = new ClassFile(File.ReadAllBytes(Path.Combine(Project.Config.Entries["projbin"], path)));
        }

        public static void Init()
        {
            keywordToClass = new Dictionary<string, ClassFile>()
            {
                { "game", LoadClassFile("net/site40/rodit/tinyrpg/game/Game.class") },
                { "helper", LoadClassFile("net/site40/rodit/tinyrpg/game/script/ScriptHelper.class") },
                { "cutsene", LoadClassFile("net/site40/rodit/tinyrpg/game/script/CutseneHelper.class") },
                { "quests", LoadClassFile("net/site40/rodit/tinyrpg/game/quest/QuestManager.class") },
                { "util", LoadClassFile("net/site40/rodit/util/Util.class") },
                { "audio", LoadClassFile("net/site40/rodit/tinyrpg/game/audio/AudioManager.class") },
                { "sfx", LoadClassFile("net/site40/rodit/tinyrpg/game/audio/SoundEffectManager.class") }
            };
        }

        public const string JS_KEYWORDS = "abstract boolean break byte case catch char class const continue debugger default delete do double else enum export extends false final finally float for function goto if implements import in instanceof int interface let long native new null package private protected public return short static super switch synchronized this self throw throws transient true try typeof var void volatile while with";
        public const string ENGINE_KEYWORDS = "game helper cutsene quests util audio sfx";
        public const string ENGINE_AUTO = ENGINE_KEYWORDS;
        private static string secondaryKeywordsCache = null;

        public ScriptFile Script { get; set; }
        public Scintilla Editor { get; set; } = new Scintilla();

        public static FindReplace findReplace = new FindReplace();
        public static GoTo sgoto = new GoTo(null);

        bool init = true;
        public ScriptEditorTab(ScriptFile script) : base()
        {
            Script = script;
            Editor.Dock = DockStyle.Fill;
            Controls.Add(Editor);
            Editor.Margins[0].Width = 16;
            Editor.TextChanged += Editor_TextChanged;
            Editor.CharAdded += Editor_CharAdded;
            Editor.AutoCCompleted += Editor_AutoCCompleted;
            Editor.Lexer = Lexer.Cpp;
            Editor.Styles[Style.Default].Font = "Consolas";
            Editor.Styles[Style.Default].SizeF = 10.5f;
            Editor.Styles[Style.Default].Bold = false;
            Editor.Styles[Style.LineNumber].ForeColor = Color.DarkGray;
            Editor.Styles[Style.Cpp.Comment].ForeColor = Color.ForestGreen;
            Editor.Styles[Style.Cpp.CommentLine].ForeColor = Color.ForestGreen;
            Editor.Styles[Style.Cpp.String].ForeColor = Color.Red;
            Editor.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            Editor.Styles[Style.Cpp.Word2].ForeColor = Color.BlueViolet;
            Editor.Styles[Style.Cpp.EscapeSequence].ForeColor = Color.DarkRed;
            Editor.Styles[Style.Cpp.Number].ForeColor = Color.DarkOrange;
            Editor.Styles[Style.BraceBad].ForeColor = Color.DarkRed;
            Editor.Styles[Style.BraceLight].ForeColor = Color.Gray;
            Editor.Styles[Style.CallTip].Font = "Consolas";
            Editor.Styles[Style.CallTip].SizeF = 10.5f;
            Editor.Styles[Style.CallTip].Bold = false;
            Editor.SetKeywords(0, JS_KEYWORDS + " " + ENGINE_KEYWORDS);
            Editor.AssignCmdKey(Keys.Control | Keys.S, Command.Null);
            Editor.KeyDown += Editor_KeyDown;
            Editor.WordChars += ".";
            Script.Load();
            Editor.Text = script.Content;
            Text = Script.FileName;
            Editor.AutoCAutoHide = true;
            LoadClasses();
            init = false;
        }

        private void Editor_AutoCCompleted(object sender, AutoCSelectionEventArgs e)
        {
            string[] parts = Editor.GetLastWord().Split('.');
            string host = parts[parts.Length >= 2 ? parts.Length - 2 : 0].Replace(".", "");
            if (keywordToClass.ContainsKey(host))
            {
                string sel = e.Text;
                Editor.CallTipShow(Editor.CurrentPosition, GetNiceDeclaration(Array.Find(keywordToClass[host].getMethods(), x => GetMethodName(x) == sel).getDeclaration()));
            }
        }

        private void LoadClasses()
        {
            if (secondaryKeywordsCache == null)
            {
                secondaryKeywordsCache = "";
                foreach (string kw in ENGINE_KEYWORDS.Split(' '))
                {
                    ClassFile cls = keywordToClass[kw];
                    classToKeywords[cls] = "";
                    string keywords = "";
                    if (cls.getMethods() != null)
                    {
                        List<string> methods = new List<string>();
                        foreach (MethodInfo method in cls.getMethods())
                        {
                            string name = GetMethodName(method);
                            if (name != "<clinit>" && !name.Contains("$") && name != "<init>")
                                methods.Add(name);
                        }
                        methods.Sort();
                        foreach (string method in methods)
                            keywords += " " + method;
                    }
                    if (cls.getFields() != null)
                    {
                        List<string> fields = new List<string>();
                        foreach (FieldInfo field in cls.getFields())
                        {
                            string name = GetFieldName(field);
                            fields.Add(name);
                        }
                        fields.Sort();
                        foreach (string field in fields)
                            keywords += " " + field;
                    }
                    classToKeywords[cls] = keywords.Substring(1);
                    secondaryKeywordsCache += keywords;
                }
                secondaryKeywordsCache = secondaryKeywordsCache.Substring(1);
            }
            Editor.SetKeywords(1, secondaryKeywordsCache);
        }

        private string GetNiceDeclaration(string declaration)
        {
            string[] parts = System.Text.RegularExpressions.Regex.Split(declaration, "\\s+", System.Text.RegularExpressions.RegexOptions.None);
            string nice = "";
            parts[1] = RemovePackage(parts[1]);
            foreach (string part in parts)
            {
                if (part.StartsWith("("))
                    nice += "(" + RemovePackage(part.Replace("(", "").Replace(",", "")) + (part.EndsWith(")") ? "" : ",");
                else if (part.EndsWith(","))
                    nice += " " + RemovePackage(part.Replace(",", "")) + ",";
                else if (part.EndsWith(")"))
                    nice += " " + RemovePackage(part.Replace(")", "")) + ")";
                else if (part.Trim() != ",")
                    nice += " " + part;
            }
            return nice.Substring(1);
        }

        private string RemovePackage(string className)
        {
            string[] parts = className.Split('.');
            if (parts.Length == 1)
                return parts[0];
            return parts[parts.Length - 1];
        }

        private string GetMethodName(MethodInfo info)
        {
            string decl = info.getDeclaration();
            string[] parts = System.Text.RegularExpressions.Regex.Split(decl, "\\s+", System.Text.RegularExpressions.RegexOptions.None);
            for (int i = 0; i < parts.Length; i++)
                if (parts[i + 1].Contains("("))
                    return parts[i];
            return decl;
        }

        private string GetFieldName(FieldInfo info)
        {
            string[] parts = System.Text.RegularExpressions.Regex.Split(info.getDeclaration(), "\\s+", System.Text.RegularExpressions.RegexOptions.None);
            return parts[parts.Length - 1];
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                findReplace.Scintilla = Editor;
                findReplace.ShowFind();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                sgoto.SetEditor(Editor);
                sgoto.ShowGoToDialog();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.OemCloseBrackets)
                Editor.CallTipCancel();
        }

        private void Editor_CharAdded(object sender, CharAddedEventArgs e)
        {
            int currentPos = Editor.CurrentPosition;
            int wordStartPos = Editor.WordStartPosition(currentPos, true);

            var lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                string kw = ENGINE_AUTO;
                string lastWord = Editor.GetLastWord();
                bool dot = lastWord.EndsWith(".");
                string[] wordParts = lastWord.Split('.');
                string host = wordParts[wordParts.Length >= 2 ? wordParts.Length - 2 : 0].Replace(".", "");
                string sub = "";
                if (wordParts.Length > 1)
                    sub = wordParts[wordParts.Length - 1];
                if (keywordToClass.ContainsKey(host))
                    kw = classToKeywords[keywordToClass[host]];
                Editor.AutoCCancel();
                if (!Editor.AutoCActive)
                {
                    int len = dot ? 0 : (wordParts.Length > 1 ? sub.Length : lenEntered);
                    Editor.AutoCShow(len, kw);
                }
            }
        }

        private int maxLineNumberCharLength;
        private void Editor_TextChanged(object sender, EventArgs e)
        {
            if (!init)
            {
                Script.Content = Editor.Text;
                if (!Text.EndsWith("*"))
                    Text = Script.FileName + "*";
            }

            var maxLineNumberCharLength = Editor.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            const int padding = 2;
            Editor.Margins[0].Width = Editor.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = maxLineNumberCharLength;
        }

        public bool TryClose()
        {
            if (!Script.IsSaved)
                if (MessageBox.Show("Would you like to save changes to this script before closing it?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    Script.Save();
            return true;
        }
    }
}
