using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using TinyEngine.TinyRPG;

namespace TinyEngine
{
    public partial class TinyEngineForm : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public TinyEngineForm()
        {
            InitializeComponent();
        }

        private DataTable localeDataTable = new DataTable();
        private bool localeLoaded = false;

        private void TinyEngineForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Log.LogEvent += OnLogMessage;
            if (!Directory.Exists("log"))
                Directory.CreateDirectory("log");
            if (!File.Exists(".tinyproject"))
            {
                FolderBrowserDialog projectChooser = new FolderBrowserDialog();
                if (projectChooser.ShowDialog() == DialogResult.OK)
                {
                    string projectDir = projectChooser.SelectedPath;
                    if (Project.IsValid(projectDir))
                        new Project(projectDir);
                    else
                        MessageBox.Show("Invalid project directory.", "TinyEngine", MessageBoxButtons.OK);
                    if (Project.Current == null)
                        Environment.Exit(1);
                    File.WriteAllText(".tinyproject", projectDir);
                }
            }
            else
                new Project(File.ReadAllText(".tinyproject"));

            if (Project.Config.Entries.ContainsKey("tiledbin"))
                txtExternalTiled.Text = Project.Config.Entries["tiledbin"];
            else
                Log.Warn("TinyEngine", "Tiled binary path not set.");
            if (Project.Config.Entries.ContainsKey("debughost"))
                txtDebugHost.Text = Project.Config.Entries["debughost"];
            else
                Log.Warn("TinyEngine", "Debug host not set.");
            if (Project.Config.Entries.ContainsKey("mapdev"))
                txtMapsDir.Text = Project.Config.Entries["mapdev"];
            else
                Log.Warn("TinyEngine", "Map directory not set.");
            if (Project.Config.Entries.ContainsKey("projbin"))
                txtConfigBin.Text = Project.Config.Entries["projbin"];
            else
                Log.Warn("TinyEngine", "Project binary directory not set.");

            ScriptEditorTab.Init();

            Project.EngineLocale = new LocaleFile("en.lang");

            KeyDown += TinyEngineForm_KeyDown;
            lbLocales.SelectedIndexChanged += LbLocales_SelectedIndexChanged;
            txtLocaleName.TextChanged += TxtLocaleName_TextChanged;
            txtLocaleFilter.TextChanged += TxtLocaleFilter_TextChanged;
            localeDataTable.TableNewRow += LocaleDataTable_TableNewRow;
            localeDataTable.RowDeleted += LocaleDataTable_RowDeleted;
            dataLocale.CellBeginEdit += DataLocale_CellBeginEdit;
            dataLocale.CellEndEdit += DataLocale_CellEndEdit;
            localeDataTable.Columns.Add("LKey").DataType = typeof(string);
            localeDataTable.Columns.Add("LValue").DataType = typeof(string);
            localeDataTable.Columns.Add("Object").DataType = typeof(LocaleEntry);
            SendMessage(txtFilterMapsLB.Handle, EM_SETCUEBANNER, 0, "Filter");
            txtFilterMapsLB.TextChanged += TxtFilterMapsLB_TextChanged;
            imgMapPreview.MouseDown += ImgMapPreview_MouseDown;
            imgMapPreview.MouseMove += ImgMapPreview_MouseMove;
            imgMapPreview.MouseUp += ImgMapPreview_MouseUp;
            lbLogs.DrawMode = DrawMode.OwnerDrawFixed;
            lbLogs.DrawItem += LbLogs_DrawItem;
            treeViewScriptFiles.NodeMouseDoubleClick += TreeViewScriptFiles_NodeMouseDoubleClick;
            tabsScriptEditors.MouseUp += TabsScriptEditors_MouseUp;
            SendMessage(txtFilterItems.Handle, EM_SETCUEBANNER, 0, "Filter");
            txtFilterItems.TextChanged += TxtFilterItems_TextChanged;
            propsItem.PropertyValueChanged += PropsItem_PropertyValueChanged;
            txtItemPropVal.KeyUp += TxtItemPropVal_KeyUp;
            SendMessage(txtItemPropName.Handle, EM_SETCUEBANNER, 0, "Name");
            SendMessage(txtItemPropVal.Handle, EM_SETCUEBANNER, 0, "Value");
            cbItemPropType.DropDownStyle = ComboBoxStyle.DropDownList;
            LocaleEntryEditor.LocaleEntryChanged += LocaleEntryEditor_LocaleEntryChanged;
            RefreshAssets();

            txtDebugConsole.Enter += TxtDebugConsole_Enter;
            txtDebugInput.KeyUp += TxtDebugInput_KeyUp;

            Project.Debug.DebugOutput += Debug_DebugOutput;
        }

        private void LocaleEntryEditor_LocaleEntryChanged(object sender, LocaleEntryEditor.LocaleEntryChangedEventArgs e)
        {
            LocaleEntryRef ler = e.EntryRef;
            LocaleEntry entry = Project.CurrentLocaleFile.GetEntry(ler.Name);
            foreach (DataRow row in localeDataTable.Rows)
            {
                if (row[2] == entry)
                {
                    row[0] = ler.Name;
                    row[1] = ler.Value;
                    break;
                }
            }
        }

        private void TxtItemPropVal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddItemProp.PerformClick();
                txtItemPropName.Clear();
                txtItemPropVal.Clear();
                txtItemPropName.Focus();
            }
        }

        private void PropsItem_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "name")
            {
                TinyItem item = Project.Items.Find(x => x.Name == (string)e.OldValue);
                item.UpdateName((string)e.ChangedItem.Value);
                int si = lbItems.SelectedIndex;
                string kdnameold = "item." + e.OldValue + ".name";
                string kdescold = "item." + e.OldValue + ".description";
                string kdname = "item." + item.Name + ".name";
                string kdesc = "item." + item.Name + ".description";
                if (Project.CurrentLocaleFile != null)
                {
                    string dname = Project.CurrentLocaleFile.GetEntryValue(kdnameold);
                    string desc = Project.CurrentLocaleFile.GetEntryValue(kdescold);
                    if (dname != string.Empty)
                    {
                        Project.CurrentLocaleFile.RemoveEntry(kdnameold);
                        Project.CurrentLocaleFile.AddEntry(kdname, dname);
                    }
                    if (desc != string.Empty)
                    {
                        Project.CurrentLocaleFile.RemoveEntry(kdescold);
                        Project.CurrentLocaleFile.AddEntry(kdesc, desc);
                    }
                }
                item.Properties["Display Name"] = new LocaleEntryRef("item." + item.Name + ".name");
                item.Properties["Description"] = new LocaleEntryRef("item." + item.Name + ".description");
                lbItems.Items.RemoveAt(si);
                lbItems.Items.Insert(si, item);
                lbItems.Invalidate();
                lbItems.SelectedItem = item;
            }
        }

        private void TxtFilterItems_TextChanged(object sender, EventArgs e)
        {
            lbItems.Items.Clear();
            foreach (TinyItem item in Project.Items)
                if (item.Name.Contains(txtFilterItems.Text) || string.IsNullOrWhiteSpace(txtFilterItems.Text))
                    lbItems.Items.Add(item);
        }

        private void TabsScriptEditors_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < tabsScriptEditors.TabCount; i++)
                {
                    Rectangle r = tabsScriptEditors.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        ScriptEditorTab tab = (ScriptEditorTab)tabsScriptEditors.TabPages[i];
                        if (tab.TryClose())
                            tabsScriptEditors.TabPages.Remove(tab);
                    }
                }
            }
        }

        private void TreeViewScriptFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ScriptFile file = (ScriptFile)e.Node.Tag;
            if (file == null)
                return;
            ScriptEditorTab tab = null;
            foreach (TabPage page in tabsScriptEditors.TabPages)
            {
                ScriptEditorTab tp = (ScriptEditorTab)page;
                if (tp.Script == file)
                {
                    tab = tp;
                    break;
                }
            }
            if (tab == null)
            {
                tab = new ScriptEditorTab(file);
                tabsScriptEditors.TabPages.Add(tab);
            }
            tabsScriptEditors.SelectedTab = tab;
        }

        private void LbLogs_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Log.LogEventArgs item = (Log.LogEventArgs)lbLogs.Items[e.Index];
            Graphics g = e.Graphics;
            Color color = Color.Black;
            if (item.Log == Log.LOG_WARN)
                color = Color.Gold;
            else if (item.Log == Log.LOG_ERROR)
                color = Color.Red;
            g.DrawString(item.ToString(), e.Font, new SolidBrush(color), new PointF(e.Bounds.X, e.Bounds.Y));
        }

        public void OnLogMessage(object sender, Log.LogEventArgs args)
        {
            lbLogs.Items.Add(args);
            lbLogs.SelectedIndex = lbLogs.Items.Count - 1;
        }

        private bool mdmp = false;
        private int mdx = 0;
        private int mdy = 0;
        private void ImgMapPreview_MouseUp(object sender, MouseEventArgs e)
        {
            mdmp = false;
        }

        private void ImgMapPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (mdmp)
            {
                int left = e.X + imgMapPreview.Left - mdx;
                if (left <= 0 && -left <= imgMapPreview.Width - panelMapPreview.Width)
                    imgMapPreview.Left = left;
                int top = e.Y + imgMapPreview.Top - mdy;
                if (top <= 0 && -top <= imgMapPreview.Height - panelMapPreview.Height)
                    imgMapPreview.Top = top;
            }
        }

        private void ImgMapPreview_MouseDown(object sender, MouseEventArgs e)
        {
            mdmp = true;
            mdx = e.X;
            mdy = e.Y;
        }

        public void SetMapPreivew(MapFile map)
        {
            if (imgMapPreview.InvokeRequired)
                imgMapPreview.Invoke(new Action(() =>
                {
                    SMP(map);
                }));
            else
                SMP(map);
        }

        private void SMP(MapFile map)
        {
            imgMapPreview.Map = map;
        }

        private void TxtFilterMapsLB_TextChanged(object sender, EventArgs e)
        {
            lbMaps.Items.Clear();
            foreach (string mapFile in Util.GetFileNamesRecursive(Project.Config.Entries["mapdev"], "*.tmx"))
            {
                if (mapFile.Contains(txtFilterMapsLB.Text))
                    lbMaps.Items.Add(new MapFile(mapFile));
            }
        }

        private void DataLocale_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!localeLoaded)
                return;
            object nval = localeDataTable.Rows[e.RowIndex][e.ColumnIndex];
            if (!(nval is string))
                return;
            if (e.ColumnIndex == 0)
            {
                LocaleEntry entry = (LocaleEntry)localeDataTable.Rows[e.RowIndex][2];
                entry.Name = (string)nval;
            }
            else
                Project.CurrentLocaleFile.AddEntry((string)localeDataTable.Rows[e.RowIndex][0], (string)nval);
        }

        private void DataLocale_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!localeLoaded)
                return;
        }

        private void LocaleDataTable_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            if (localeLoaded)
                Project.CurrentLocaleFile.RemoveEntry((string)e.Row["LKey"]);
        }

        private void LocaleDataTable_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
        }

        private void TxtLocaleFilter_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dataLocale.DataSource).DefaultView.RowFilter = string.Format("LKey LIKE '%{0}%' OR LValue LIKE '%{0}%'", txtLocaleFilter.Text);
        }

        private void Debug_DebugOutput(object sender, TinyDebug.DebugOutputEventArgs e)
        {
            if (e.Output == "<CLEAR>")
                txtDebugConsole.Clear();
            else
                txtDebugConsole.AppendText(e.Output + Environment.NewLine);
        }

        private void TxtDebugInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Project.Debug.RunCommand(txtDebugInput.Text);
                txtDebugInput.Clear();
            }
        }

        private void TxtDebugConsole_Enter(object sender, EventArgs e)
        {
            ActiveControl = txtDebugInput;
        }

        private void TinyEngineForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                SaveCurrent();
            else if (e.Control && e.KeyCode == Keys.W)
                CloseCurrent();
            else if (e.KeyCode == Keys.Delete)
            {
                if (lbItems.SelectedIndex > -1 && propsItem.SelectedGridItem != null)
                {
                    string prop = propsItem.SelectedGridItem.Label;
                    TinyItem item = (TinyItem)lbItems.SelectedItem;
                    if (item.Properties.ContainsKey(prop) && prop != "Display Name" && prop != "Description")
                    {
                        item.Properties.RemoveKey(prop);
                        lbItems_SelectedIndexChanged(null, null);
                    }
                }
            }
        }

        private void SaveCurrent()
        {
            if (tabs.SelectedTab == tabLocales && Project.CurrentLocaleFile != null)
                Project.CurrentLocaleFile.Save();
            if (tabs.SelectedTab == tabScripts)
            {
                ScriptEditorTab tab = (ScriptEditorTab)tabsScriptEditors.SelectedTab;
                if (tab != null)
                {
                    tab.Script.Save();
                    tab.Text = tab.Script.FileName;
                }
            }
        }

        private void CloseCurrent()
        {
            if (tabs.SelectedTab == tabScripts)
            {
                ScriptEditorTab tab = (ScriptEditorTab)tabsScriptEditors.SelectedTab;
                if (tab != null)
                    if (tab.TryClose())
                        tabsScriptEditors.TabPages.Remove(tab);
            }
        }

        private void TxtLocaleName_TextChanged(object sender, EventArgs e)
        {
            if (Project.CurrentLocaleFile != null)
                Project.CurrentLocaleFile.LocaleName = txtLocaleName.Text;
        }

        private void LbLocales_SelectedIndexChanged(object sender, EventArgs e)
        {
            localeLoaded = false;
            txtLocaleName.Text = "";
            int selected = lbLocales.SelectedIndex;
            Project.CurrentLocaleFile = null;
            if (selected > -1)
            {
                localeDataTable.Rows.Clear();
                Project.CurrentLocaleFile = new LocaleFile((string)lbLocales.SelectedItem);
                txtLocaleName.Text = Project.CurrentLocaleFile.LocaleName;
                foreach (LocaleEntry entry in Project.CurrentLocaleFile.Entries)
                {
                    localeDataTable.Rows.Add(entry.Name, entry.Value, entry);
                }
                dataLocale.DataSource = localeDataTable;
                dataLocale.Columns[2].Visible = false;
                dataLocale.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                localeLoaded = true;
            }
        }

        public void RefreshMaps()
        {
            lbMaps.Items.Clear();
            foreach (string mapFile in Util.GetFileNamesRecursive(Project.Config.Entries["mapdev"], "*.tmx"))
            {
                lbMaps.Items.Add(new MapFile(mapFile));
            }
            lbMaps_SelectedIndexChanged(null, null);
        }

        public void RefreshLocales()
        {
            lbLocales.Items.Clear();
            foreach (string locale in Project.Current.GetAssets(Project.LANG_DIR))
            {
                lbLocales.Items.Add(locale);
            }
            LbLocales_SelectedIndexChanged(null, null);
        }

        public void RefreshItems()
        {
            lbItems.Items.Clear();
            Project.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(Project.Current.GetConfig("items.xml"));
            foreach(XmlNode node in doc.GetElementsByTagName("item"))
            {
                TinyItem i = new TinyItem("null_item");
                i.Load((XmlElement)node);
                i.Properties.Add("Display Name", new LocaleEntryRef("item." + i.Name + ".name"));
                i.Properties.Add("Description", new LocaleEntryRef("item." + i.Name + ".description"));
                Project.Items.Add(i);
                lbItems.Items.Add(i);
            }
            lbItems_SelectedIndexChanged(null, null);
        }

        public void RefreshScripts()
        {
            tabsScriptEditors.TabPages.Clear();
            treeViewScriptFiles.Nodes.Clear();
            foreach (string dir in Directory.GetDirectories(Project.Current.GetAsset("script")))
            {
                treeViewScriptFiles.Nodes.Add(CreateDirectoryNode(new DirectoryInfo(dir)));
            }
        }

        private TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(CreateScriptFileNode(file));
            return directoryNode;
        }

        private TreeNode CreateScriptFileNode(FileInfo fileinfo)
        {
            string path = Project.Current.GetAsset("script");
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                path += Path.DirectorySeparatorChar;
            string script = fileinfo.FullName.Substring(path.Length);
            ScriptFile file = new ScriptFile(script);
            TreeNode node = new TreeNode(file.FileName);
            node.Tag = file;
            return node;
        }

        public void RefreshAssets()
        {
            RefreshMaps();
            RefreshLocales();
            RefreshItems();
            RefreshScripts();
        }

        private void btnRefreshAssets_Click(object sender, EventArgs e)
        {
            RefreshAssets();
        }

        private void btnSaveLocale_Click(object sender, EventArgs e)
        {
            Project.CurrentLocaleFile.Save();
            Log.Info("TinyEngine", "Locale file saved to " + Project.CurrentLocaleFile.Name + ".");
        }

        public void SetLBMapsState(bool enabled)
        {
            if (lbMaps.InvokeRequired)
                lbMaps.Invoke(new Action(() =>
                {
                    lbMaps.Enabled = enabled;
                    lblMapPreviewLoading.Visible = !enabled;
                }));
            else
            {
                lbMaps.Enabled = enabled;
                lblMapPreviewLoading.Visible = !enabled;
            }
        }

        private void lbMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project.CurrentMapFile = null;
            if (lbMaps.SelectedIndex > -1)
            {
                SetLBMapsState(false);
                MapFile selected = (MapFile)lbMaps.SelectedItem;
                Project.CurrentMapFile = selected;
                new Thread(new ThreadStart(() =>
                {
                    SetMapPreivew(selected);
                    SetLBMapsState(true);
                })).Start();
            }
            imgMapPreview.Left = 0;
            imgMapPreview.Top = 0;
        }

        private void btnNewMap_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Name", "New Map");
            if (string.IsNullOrWhiteSpace(name))
                return;
            if (!name.EndsWith(".tmx"))
                name += ".tmx";
            MapFile mapFile = new MapFile(name);
            if (File.Exists(mapFile.GetPath()) || Directory.Exists(mapFile.GetPath()))
                MessageBox.Show("Map already exists.", "Cannot Create Map", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string path = mapFile.GetPath();
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.Copy("resources/map_template.tmx", path);
                RefreshMaps();
            }
        }

        private void btnCompileMap_Click(object sender, EventArgs e)
        {
            if (Project.CurrentMapFile != null)
            {
                string bin = Project.CurrentMapFile.GetBinaryPath();
                Directory.CreateDirectory(Path.GetDirectoryName(bin));
                try
                {
                    MapConverter.ConvertMap(Project.CurrentMapFile.GetPath(), bin);
                }
                catch (IOException ex)
                {
                    Log.Error("TinyEngine", "Error while compiling map: " + ex.Message + ".");
                }
                lbMaps_SelectedIndexChanged(null, null);
            }
        }

        private void btnEditMap_Click(object sender, EventArgs e)
        {
            if (Project.CurrentMapFile != null)
                Process.Start(Project.Config.Entries["tiledbin"], Project.CurrentMapFile.GetPath());
        }

        private void btnDeleteMap_Click(object sender, EventArgs e)
        {
            if (Project.CurrentMapFile == null)
                return;
            if (MessageBox.Show("Are you sure you would like to delete this map?", "Delete Map", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                File.Delete(Project.CurrentMapFile.GetPath());
                string bin = Project.CurrentMapFile.GetBinaryPath();
                if (File.Exists(bin))
                    File.Delete(bin);
                imgMapPreview.Map = null;
                Project.CurrentMapFile = null;
            }
        }

        private void btnSaveExternalTools_Click(object sender, EventArgs e)
        {
            Project.Config.Entries["tiledbin"] = txtExternalTiled.Text;
            Project.Config.Entries["debughost"] = txtDebugHost.Text;
            Project.Config.Entries["mapdev"] = txtMapsDir.Text;
            Project.Config.Entries["projbin"] = txtConfigBin.Text;
            Project.Config.Save(Project.ENGINE_CONFIG);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lbLogs.Items.Clear();
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            propsItem.SelectedObject = null;
            lblItemPreviewInfo.Text = "No Item Selected.";
            pbItemPreview.Image = null;
            if (lbItems.SelectedIndex > -1)
            {
                TinyItem i = (TinyItem)lbItems.SelectedItem;
                propsItem.SelectedObject = new DictionaryPropertyGridAdapter<string, object>(i.Properties);
                lblItemPreviewInfo.Text = "Name: " + i.Name + "\nDisplay Name: " + ((LocaleEntryRef)i.Properties["Display Name"]).Value + "\nDescription:\n" + ((LocaleEntryRef)i.Properties["Description"]).Value.Replace("\\n", "\r\n");
                string resourceVal = i.Properties.ContainsKey("resource") ? (string)i.Properties["resource"] : "null";
                string itemBmp = Project.Current.GetBitmap(resourceVal);
                if (File.Exists(itemBmp))
                    pbItemPreview.Image = Util.LoadImage(itemBmp);
                else
                    pbItemPreview.Image = Util.LoadImage(Project.Current.GetBitmap("undefined.png"));
            }
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            string xml = "<items>";
            foreach(TinyItem item in Project.Items)
            {
                xml += "\n" + item.Save();
            }
            xml += "\n</items>";
            File.WriteAllText(Project.Current.GetConfig("items2.xml"), xml);
            if (Project.CurrentLocaleFile != null)
                Project.CurrentLocaleFile.Save();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to delete this item?", "TinyEngine", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Project.Items.Remove((TinyItem)lbItems.SelectedItem);
                lbItems.Items.Remove(lbItems.SelectedItem);
            }
        }

        private void chkShowMapLights_CheckedChanged(object sender, EventArgs e)
        {
            imgMapPreview.ShowLights = chkShowMapLights.Checked;
            imgMapPreview.Invalidate();
        }

        private void chkShowMapCollisions_CheckedChanged(object sender, EventArgs e)
        {
            imgMapPreview.ShowCollisions = chkShowMapCollisions.Checked;
            imgMapPreview.Invalidate();
        }

        private void chkShowMapEntities_CheckedChanged(object sender, EventArgs e)
        {
            imgMapPreview.ShowEntities = chkShowMapEntities.Checked;
            imgMapPreview.Invalidate();
        }

        private void btnAddItemProp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemPropName.Text))
                return;
            if (lbItems.SelectedIndex > -1)
            {
                TinyItem item = (TinyItem)lbItems.SelectedItem;
                if (!item.Properties.ContainsKey(txtItemPropName.Text))
                {
                    object val = txtItemPropVal.Text;
                    if (cbItemPropType.Text == "Stats")
                        val = new EntityStats();
                    item.Properties[txtItemPropName.Text] = val;
                    lbItems_SelectedIndexChanged(null, null);
                }
            }
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Please enter the new item's name.", "New Item");
            if (string.IsNullOrWhiteSpace(name) || Project.Items.Find(x => x.Name == name) != null)
                MessageBox.Show("Invalid item name.", "TinyEngine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                TinyItem i = new TinyItem(name);
                i.Properties["name"] = name;
                i.Properties["type"] = TinyItem.ItemTypes.Item;
                i.Properties["Display Name"] = new LocaleEntryRef("item." + name + ".name");
                i.Properties["Description"] = new LocaleEntryRef("item." + name + ".description");
                Project.Items.Add(i);
                lbItems.Items.Add(i);
                lbItems.SelectedItem = i;
            }
        }

        private void btnLaunchConsole_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe");
        }
    }
}
