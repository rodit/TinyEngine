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
        private DataTable dialogReqsTable = new DataTable();
        private bool localeLoaded = false;

        private string currentGlobalReqName;

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

            Project.EngineLocale = new LocaleFile("en");

            KeyDown += TinyEngineForm_KeyDown;
            lbLocales.SelectedIndexChanged += LbLocales_SelectedIndexChanged;
            txtLocaleName.TextChanged += TxtLocaleName_TextChanged;
            txtLocaleFilter.TextChanged += TxtLocaleFilter_TextChanged;
            dataLocale.CellBeginEdit += DataLocale_CellBeginEdit;
            dataLocale.CellEndEdit += DataLocale_CellEndEdit;
            dataLocale.UserDeletingRow += DataLocale_UserDeletingRow;
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
            SendMessage(txtFilterDialogs.Handle, EM_SETCUEBANNER, 0, "Filter");
            txtFilterDialogs.TextChanged += TxtFilterDialogs_TextChanged;
            dialogReqsTable.Columns.Add("Global Name").DataType = typeof(string);
            dialogReqsTable.Columns.Add("Global Value").DataType = typeof(string);
            dialogReqsTable.Columns.Add("Object").DataType = typeof(DialogPart);
            cbDialogLineType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDialogLineType.DataSource = Enum.GetValues(typeof(DialogPart.LineType));
            SendMessage(txtLineArg.Handle, EM_SETCUEBANNER, 0, "Argument");
            SendMessage(txtLineValue.Handle, EM_SETCUEBANNER, 0, "Value");
            gridGlobalReqs.CellBeginEdit += GridGlobalReqs_CellBeginEdit;
            gridGlobalReqs.CellEndEdit += GridGlobalReqs_CellEndEdit;
            gridGlobalReqs.UserDeletingRow += GridGlobalReqs_UserDeletingRow;
            txtLineArg.KeyPress += TxtLineArg_KeyPress;
            txtLineValue.KeyPress += TxtLineValue_KeyPress;
            txtEntityPropValue.KeyUp += TxtEntityPropValue_KeyUp;
            RefreshAssets();

            txtDebugConsole.Enter += TxtDebugConsole_Enter;
            txtDebugInput.KeyUp += TxtDebugInput_KeyUp;

            Project.Debug.DebugOutput += Debug_DebugOutput;
        }

        private void TxtEntityPropValue_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnAddEntProp.PerformClick();
                txtEntityPropName.Clear();
                txtEntityPropValue.Clear();
                txtEntityPropName.Focus();
            }
        }

        private void TxtLineValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            DialogPart.DialogLine line = (DialogPart.DialogLine)lbDialogPartLines.SelectedItem;
            if (line != null)
            {
                if (line.Type == DialogPart.LineType.Text)
                    line.Text = txtLineValue.Text.Replace("\r\n", "\\n");
                else if (line.Type == DialogPart.LineType.Set)
                    line.GlobalValue = txtLineValue.Text;
            }
        }

        private void TxtLineArg_KeyPress(object sender, KeyPressEventArgs e)
        {
            DialogPart.DialogLine line = (DialogPart.DialogLine)lbDialogPartLines.SelectedItem;
            if (line != null)
            {
                if (line.Type == DialogPart.LineType.Run)
                    line.Text = txtLineArg.Text;
                else if (line.Type == DialogPart.LineType.Set)
                    line.GlobalName = txtLineArg.Text;
            }
        }

        private void GridGlobalReqs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogPart part = GetDialogPart(lbDialogParts.SelectedIndex);
            if (part != null)
            {
                object value = e.Row.Cells["Global Name"].Value;
                if (value is DBNull)
                    return;
                part.GlobalRequirements.Remove((string)value);
            }
        }

        private void DataLocale_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (localeLoaded)
            {
                string group = (string)lbLocaleGroups.SelectedItem;
                Project.CurrentLocaleFile.RemoveEntry(group, (string)e.Row.Cells["LKey"].Value);
            }
        }

        private void GridGlobalReqs_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dialogReqsTable.Rows.Count == e.RowIndex)
                return;
            object value = dialogReqsTable.Rows[e.RowIndex]["Global Name"];
            if (value is DBNull)
                value = "global_name";
            currentGlobalReqName = (string)value;
        }

        private void GridGlobalReqs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DialogPart part = GetDialogPart(lbDialogParts.SelectedIndex);
            if (part != null && e.RowIndex < dialogReqsTable.Rows.Count)
            {
                DataRow row = dialogReqsTable.Rows[e.RowIndex];
                object nameVal = row[0];
                object valVal = row[1];
                if (nameVal is DBNull || valVal is DBNull)
                {
                    MessageBox.Show("Please enter a valid value.");
                }
                else
                {
                    string globalName = (string)nameVal;
                    string globalValue = (string)valVal;
                    if (e.ColumnIndex == 0 && currentGlobalReqName != null && part.GlobalRequirements.ContainsKey(currentGlobalReqName))
                    {
                        part.GlobalRequirements.Remove(currentGlobalReqName);
                        part.GlobalRequirements[globalName] = globalValue;
                    }
                    else
                        part.GlobalRequirements[globalName] = globalValue;
                    currentGlobalReqName = null;
                }
            }
        }

        private void TxtFilterDialogs_TextChanged(object sender, EventArgs e)
        {
            lbDialogs.Items.Clear();
            foreach (string dialogFile in Util.GetFileNamesRecursive(Project.Current.GetDialog("")))
            {
                if (dialogFile.Contains(txtFilterDialogs.Text))
                    lbDialogs.Items.Add(new DialogFile(dialogFile));
            }
        }

        private void LocaleEntryEditor_LocaleEntryChanged(object sender, LocaleEntryEditor.LocaleEntryChangedEventArgs e)
        {
            LocaleEntryRef ler = e.EntryRef;
            LocaleEntry entry = Project.CurrentLocaleFile.GetEntry(ler.Group, ler.Name);
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
                string kdnameold = e.OldValue + ".name";
                string kdescold = e.OldValue + ".description";
                string kdname = item.Name + ".name";
                string kdesc = item.Name + ".description";
                if (Project.CurrentLocaleFile != null)
                {
                    string dname = Project.CurrentLocaleFile.GetEntryValue("item", kdnameold);
                    string desc = Project.CurrentLocaleFile.GetEntryValue("item", kdescold);
                    if (dname != string.Empty)
                    {
                        Project.CurrentLocaleFile.RemoveEntry("item", kdnameold);
                        Project.CurrentLocaleFile.AddEntry("item", kdname, dname);
                    }
                    if (desc != string.Empty)
                    {
                        Project.CurrentLocaleFile.RemoveEntry("item", kdescold);
                        Project.CurrentLocaleFile.AddEntry("item", kdesc, desc);
                    }
                }
                item.Properties["Display Name"] = new LocaleEntryRef("item", item.Name + ".name");
                item.Properties["Description"] = new LocaleEntryRef("item", item.Name + ".description");
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
            if (lbLogs.InvokeRequired)
                lbLogs.Invoke(new Action(() =>
                {
                    lbLogs.Items.Add(args);
                    lbLogs.SelectedIndex = lbLogs.Items.Count - 1;
                }));
            else
            {
                lbLogs.Items.Add(args);
                lbLogs.SelectedIndex = lbLogs.Items.Count - 1;
            }
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
            {
                string group = (string)lbLocaleGroups.SelectedItem;
                Project.CurrentLocaleFile.AddEntry(group, (string)localeDataTable.Rows[e.RowIndex][0], (string)nval);
            }
        }

        private void DataLocale_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!localeLoaded)
                return;
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
                if (tabs.SelectedTab == tabItems && lbItems.SelectedIndex > -1 && propsItem.SelectedGridItem != null)
                {
                    string prop = propsItem.SelectedGridItem.Label;
                    TinyItem item = (TinyItem)lbItems.SelectedItem;
                    if (item.Properties.ContainsKey(prop) && prop != "Display Name" && prop != "Description")
                    {
                        item.Properties.RemoveKey(prop);
                        lbItems_SelectedIndexChanged(null, null);
                    }
                }
                else if (tabs.SelectedTab == tabEntities && lbEntities.SelectedIndex > -1 && propsEnt.SelectedGridItem != null)
                {
                    string prop = propsEnt.SelectedGridItem.Label;
                    TinyEntity entity = (TinyEntity)lbEntities.SelectedItem;
                    if (entity.Properties.ContainsKey(prop) && prop != "Display Name")
                    {
                        entity.Properties.RemoveKey(prop);
                        lbEntities_SelectedIndexChanged(null, null);
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
            else if (tabs.SelectedTab == tabDialogs)
            {
                DialogFile dialog = (DialogFile)lbDialogs.SelectedItem;
                if (dialog != null)
                    btnSaveDialog.PerformClick();
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
            lbLocaleGroups.Items.Clear();
            int selected = lbLocales.SelectedIndex;
            Project.CurrentLocaleFile = null;
            if (selected > -1)
            {
                localeDataTable.Rows.Clear();
                Project.CurrentLocaleFile = new LocaleFile((string)lbLocales.SelectedItem);
                txtLocaleName.Text = Project.CurrentLocaleFile.LocaleName;
                foreach (string key in Project.CurrentLocaleFile.Entries.Keys)
                {
                    lbLocaleGroups.Items.Add(key);
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
            foreach (string locale in Project.Current.GetAssetDirs(Project.LANG_DIR))
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
            foreach (XmlNode node in doc.GetElementsByTagName("item"))
            {
                TinyItem i = new TinyItem("null_item");
                i.Load((XmlElement)node);
                i.Properties.Add("Display Name", new LocaleEntryRef("item", i.Name + ".name"));
                i.Properties.Add("Description", new LocaleEntryRef("item", i.Name + ".description"));
                Project.Items.Add(i);
                lbItems.Items.Add(i);
            }
            lbItems_SelectedIndexChanged(null, null);
        }

        public void RefreshShops()
        {
            lbShops.Items.Clear();
            Project.Shops.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(Project.Current.GetConfig("shops.xml"));
            foreach (XmlNode node in doc.GetElementsByTagName("shop"))
            {
                TinyShop shop = new TinyShop("null_shop");
                shop.Load((XmlElement)node);
                Project.Shops.Add(shop);
                lbShops.Items.Add(shop);
            }
            lbShops_SelectedIndexChanged(null, null);
        }

        public void RefreshEntities()
        {
            lbEntities.Items.Clear();
            foreach (string entConfig in Util.GetFileNamesRecursive(Project.Current.GetConfig("entity")))
            {
                TinyEntity ent = new TinyEntity(entConfig);
                ent.Load();
                lbEntities.Items.Add(ent);
            }
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

        public void RefreshDialogs()
        {
            lbDialogs.Items.Clear();
            foreach (string dialogFile in Util.GetFileNamesRecursive(Project.Current.GetDialog("")))
            {
                lbDialogs.Items.Add(new DialogFile(dialogFile));
            }
            lbDialogs_SelectedIndexChanged(null, null);
        }

        public void RefreshAssets()
        {
            RefreshMaps();
            RefreshLocales();
            RefreshItems();
            RefreshShops();
            RefreshEntities();
            RefreshScripts();
            RefreshDialogs();
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
                    string deployBinPath = Project.Current.GetMap(Project.CurrentMapFile.Name.Replace(".tmx", ".dat"));
                    Directory.CreateDirectory(Path.GetDirectoryName(deployBinPath));
                    File.Copy(bin, deployBinPath, true);
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
                string resourceVal = i.Properties.ContainsKey("resource") ? ((AssetRef)i.Properties["resource"]).Name : "null";
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
            foreach (TinyItem item in Project.Items)
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
                i.Properties["Display Name"] = new LocaleEntryRef("item", name + ".name");
                i.Properties["Description"] = new LocaleEntryRef("item", name + ".description");
                Project.Items.Add(i);
                lbItems.Items.Add(i);
                lbItems.SelectedItem = i;
            }
        }

        private void btnLaunchConsole_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe");
        }

        private void lbDialogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbDialogParts.Items.Clear();
            lbDialogParts_SelectedIndexChanged(null, null);
            lbDialogPartLines_SelectedIndexChanged(null, null);
            if (lbDialogs.SelectedIndex > -1)
            {
                DialogFile dialog = (DialogFile)lbDialogs.SelectedItem;
                dialog.Load();
                lbDialogParts.Items.Add("[Root]");
                foreach (DialogPart part in dialog.Parts)
                    lbDialogParts.Items.Add(part);
            }
        }

        private void lbDialogParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogPart part = GetDialogPart(lbDialogParts.SelectedIndex);
            lbDialogPartLines.Items.Clear();
            if (part != null)
            {
                foreach (DialogPart.DialogLine line in part.Lines)
                {
                    lbDialogPartLines.Items.Add(line);
                }
                dialogReqsTable.Clear();
                foreach (KeyValuePair<string, string> req in part.GlobalRequirements)
                {
                    dialogReqsTable.Rows.Add(req.Key, req.Value, part);
                }
                gridGlobalReqs.DataSource = dialogReqsTable;
                gridGlobalReqs.Columns[2].Visible = false;
                gridGlobalReqs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        public DialogPart GetDialogPart(int index)
        {
            if (lbDialogs.SelectedIndex < 0)
                return null;
            if (index == 0)
                return ((DialogFile)lbDialogs.SelectedItem).Root;
            else if (index > 0)
                return (DialogPart)lbDialogParts.Items[index];
            return null;
        }

        private void btnAddDialogPart_Click(object sender, EventArgs e)
        {
            int dialogIndex = lbDialogParts.SelectedIndex;
            dialogIndex = dialogIndex > -1 ? dialogIndex + 1 : lbDialogParts.Items.Count;
            DialogPart nPart = new DialogPart();
            DialogFile selected = (DialogFile)lbDialogs.SelectedItem;
            if (selected != null)
            {
                lbDialogParts.Items.Insert(dialogIndex, nPart);
                if (dialogIndex == selected.Parts.Count + 1)
                    selected.Parts.Add(nPart);
                else
                    selected.Parts.Insert(dialogIndex, nPart);
            }
        }

        private void btnDialogPartUp_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbDialogParts.SelectedIndex;
            DialogPart part = GetDialogPart(selectedIndex);
            DialogFile dialog = (DialogFile)lbDialogs.SelectedItem;
            if (part != null)
            {
                int nIndex = selectedIndex - 1;
                if (nIndex > 0)
                {
                    lbDialogParts.Items.Remove(part);
                    lbDialogParts.Items.Insert(nIndex, part);
                    dialog.Parts.Remove(part);
                    dialog.Parts.Insert(nIndex, part);
                    lbDialogParts.SelectedItem = part;
                }
            }
        }

        private void btnDialogPartDown_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbDialogParts.SelectedIndex;
            DialogPart part = GetDialogPart(selectedIndex);
            DialogFile dialog = (DialogFile)lbDialogs.SelectedItem;
            if (part != null)
            {
                int nIndex = selectedIndex + 1;
                if (nIndex < lbDialogParts.Items.Count)
                {
                    lbDialogParts.Items.Remove(part);
                    lbDialogParts.Items.Insert(nIndex, part);
                    dialog.Parts.Remove(part);
                    if (nIndex == dialog.Parts.Count + 1)
                        dialog.Parts.Add(part);
                    else
                        dialog.Parts.Insert(nIndex, part);
                    lbDialogParts.SelectedItem = part;
                }
            }
        }

        private void btnDeleteDialogPart_Click(object sender, EventArgs e)
        {
            DialogPart part = GetDialogPart(lbDialogParts.SelectedIndex);
            DialogFile dialog = (DialogFile)lbDialogs.SelectedItem;
            if (part != null && part != dialog.Root)
            {
                lbDialogParts.Items.Remove(part);
                dialog.Parts.Remove(part);
            }
        }

        private void lbDialogPartLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLineArg.Text = "";
            txtLineValue.Text = "";
            if (lbDialogPartLines.SelectedIndex > -1)
            {
                DialogPart.DialogLine line = (DialogPart.DialogLine)lbDialogPartLines.SelectedItem;
                cbDialogLineType.SelectedItem = line.Type;
                if (line.Type == DialogPart.LineType.Text)
                {
                    txtLineArg.Enabled = false;
                    txtLineValue.Enabled = true;
                    txtLineValue.Text = line.Text.Replace("\\n", "\r\n");
                }
                else
                {
                    txtLineArg.Enabled = true;
                    if (line.Type == DialogPart.LineType.Run)
                    {
                        txtLineArg.Text = line.ScriptName;
                        txtLineValue.Enabled = false;
                    }
                    else if (line.Type == DialogPart.LineType.Set)
                    {
                        txtLineArg.Text = line.GlobalName;
                        txtLineValue.Text = line.GlobalValue;
                    }
                }
            }
        }

        private void cbDialogLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDialogLineType.SelectedIndex > -1)
            {
                DialogPart.DialogLine line = (DialogPart.DialogLine)lbDialogPartLines.SelectedItem;
                if (line != null)
                {
                    DialogPart.LineType selected = (DialogPart.LineType)cbDialogLineType.SelectedItem;
                    if (selected != line.Type)
                    {
                        line.Type = selected;
                        lbDialogPartLines_SelectedIndexChanged(null, null);
                    }
                }
            }
        }

        private void btnAddDialogLine_Click(object sender, EventArgs e)
        {
            int lineIndex = lbDialogPartLines.SelectedIndex;
            lineIndex = lineIndex > -1 ? lineIndex + 1 : lbDialogPartLines.Items.Count;
            DialogPart.DialogLine nLine = new DialogPart.DialogLine("New dialog line.");
            DialogPart selected = GetDialogPart(lbDialogParts.SelectedIndex);
            if (selected != null)
            {
                lbDialogPartLines.Items.Insert(lineIndex, nLine);
                if (lineIndex == selected.Lines.Count + 1)
                    selected.Lines.Add(nLine);
                else
                    selected.Lines.Insert(lineIndex, nLine);
            }
        }

        private void btnDialogLineUp_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbDialogPartLines.SelectedIndex;
            DialogPart.DialogLine line = (DialogPart.DialogLine)lbDialogPartLines.SelectedItem;
            DialogPart part = GetDialogPart(lbDialogParts.SelectedIndex);
            if (line != null && part != null)
            {
                int nIndex = selectedIndex - 1;
                if (nIndex > -1)
                {
                    lbDialogPartLines.Items.Remove(line);
                    lbDialogPartLines.Items.Insert(nIndex, line);
                    part.Lines.Remove(line);
                    part.Lines.Insert(nIndex, line);
                    lbDialogPartLines.SelectedItem = line;
                }
            }
        }

        private void btnDialogLineDown_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbDialogPartLines.SelectedIndex;
            DialogPart.DialogLine line = (DialogPart.DialogLine)lbDialogPartLines.SelectedItem;
            DialogPart part = GetDialogPart(lbDialogParts.SelectedIndex);
            if (line != null && part != null)
            {
                int nIndex = selectedIndex + 1;
                if (nIndex < lbDialogPartLines.Items.Count)
                {
                    lbDialogPartLines.Items.Remove(line);
                    lbDialogPartLines.Items.Insert(nIndex, line);
                    part.Lines.Remove(line);
                    if (nIndex == part.Lines.Count + 1)
                        part.Lines.Add(line);
                    else
                        part.Lines.Insert(nIndex, line);
                    lbDialogPartLines.SelectedItem = line;
                }
            }
        }

        private void btnDeleteDialogLine_Click(object sender, EventArgs e)
        {
            DialogPart.DialogLine line = (DialogPart.DialogLine)lbDialogPartLines.SelectedItem;
            DialogPart part = GetDialogPart(lbDialogParts.SelectedIndex);
            if (line != null && part != null)
            {
                lbDialogPartLines.Items.Remove(line);
                part.Lines.Remove(line);
            }
        }

        private void btnSaveDialog_Click(object sender, EventArgs e)
        {
            DialogFile selected = (DialogFile)lbDialogs.SelectedItem;
            if (selected != null)
            {
                selected.Save();
            }
        }

        private void btnNewDialog_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("New dialog file name", "New Dialog");
            if (string.IsNullOrWhiteSpace(name))
                MessageBox.Show("Invalid dialog name.");
            if (!name.EndsWith(".tlk"))
                name += ".tlk";
            if (File.Exists(Project.Current.GetDialog(name)))
                MessageBox.Show("Dialog with this name already exists.");
            else
            {
                FileStream stream = new FileStream(Project.Current.GetDialog(name), FileMode.Create);
                stream.Write("#\nNew dialog...".GetBytes(), 0, 15);
                stream.Flush();
                stream.Close();
                DialogFile file = new DialogFile(name);
                lbDialogs.Items.Add(file);
                lbDialogs.SelectedItem = file;
            }
        }

        private void btnDeleteDialog_Click(object sender, EventArgs e)
        {
            DialogFile selected = (DialogFile)lbDialogs.SelectedItem;
            if (selected != null)
            {
                if (MessageBox.Show("Are you sure you would like to delete this dialog?", "Delete Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    File.Delete(selected.GetPath());
                    lbDialogs.Items.Remove(selected);
                }
            }
        }

        private void lbEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            propsEnt.SelectedObject = null;
            if (lbEntities.SelectedIndex > -1)
            {
                TinyEntity ent = (TinyEntity)lbEntities.SelectedItem;
                propsEnt.SelectedObject = new DictionaryPropertyGridAdapter<string, object>(ent.Properties);
            }
        }

        private void btnAddEntProp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEntityPropName.Text))
                return;
            if (lbEntities.SelectedIndex > -1)
            {
                TinyEntity entity = (TinyEntity)lbEntities.SelectedItem;
                if (!entity.Properties.ContainsKey(txtEntityPropName.Text))
                {
                    string type = cbEntityPropType.Text;
                    object val = txtEntityPropValue.Text;
                    if (type == "Attack")
                    {
                        //TODO: Get attack value from combo box.
                    }
                    else if (type == "EquipData")
                        val = new EquipData();
                    else if (type == "Inventory")
                        val = new Inventory();
                    else if (type == "ShopRef")
                    {
                        TinyShop shop = (TinyShop)cbEntityPropValue.SelectedItem;
                        if (shop == null)
                            shop = Project.Shops.Find(x => x.Name == cbEntityPropValue.Text);
                        if (shop != null)
                            val = shop;
                        else
                        {
                            MessageBox.Show("Invalid shop.", "TinyEngine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else if (type == "Stats")
                        val = new EntityStats();
                    entity.Properties[txtEntityPropName.Text] = val;
                    lbEntities_SelectedIndexChanged(null, null);
                }
            }
        }

        private void lbShops_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbEntityPropType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cbEntityPropType.Text;
            cbEntityPropValue.Visible = false;
            txtEntityPropValue.Visible = false;
            if (type == "Attack")
            {
                cbEntityPropValue.Visible = true;
                //TODO: Populate combobox with attacks.
            }
            else if (type == "ShopRef")
            {
                cbEntityPropValue.Visible = true;
                foreach (TinyShop shop in Project.Shops)
                    cbEntityPropValue.Items.Add(shop);
            }
            else
            {
                txtEntityPropValue.Visible = true;
            }
        }

        private void lbLocaleGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            localeDataTable.Clear();
            if (lbLocaleGroups.SelectedIndex > -1 && localeLoaded)
            {
                List<LocaleEntry> entries = Project.CurrentLocaleFile.Entries[(string)lbLocaleGroups.SelectedItem];
                foreach (LocaleEntry entry in entries)
                {
                    if (entry == LocaleEntry.BLANK_LINE || entry is LocaleEntry.CommentEntry)
                        continue;
                    localeDataTable.Rows.Add(entry.Name, entry.Value, entry);
                }
            }
            dataLocale.AutoResizeColumns();
        }

        private void btnCompileAllMaps_Click(object sender, EventArgs e)
        {
            ProgressDialog dialog = new ProgressDialog();
            dialog.SetProgressText("Compiling maps...");
            new Thread(() =>
            {
                int count = lbMaps.Items.Count;
                int i = 0;
                foreach (object map in lbMaps.Items)
                {
                    MapFile file = (MapFile)map;
                    dialog.SetProgressText("Compiling map " + file.Name + "...");
                    dialog.SetProgress(i, count);
                    string bin = file.GetBinaryPath();
                    Directory.CreateDirectory(Path.GetDirectoryName(bin));
                    try
                    {
                        MapConverter.ConvertMap(file.GetPath(), bin);
                        string deployBinPath = Project.Current.GetMap(file.Name.Replace(".tmx", ".dat"));
                        Directory.CreateDirectory(Path.GetDirectoryName(deployBinPath));
                        File.Copy(bin, deployBinPath, true);
                    }
                    catch (IOException ex)
                    {
                        Log.Error("TinyEngine", "Error while compiling map: " + ex.Message + ".");
                    }
                    i++;
                }
                dialog.OnComplete();
            }).Start();
            dialog.ShowDialog();
        }

        private void btnSaveEntity_Click(object sender, EventArgs e)
        {

        }
    }
}