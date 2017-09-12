using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TinyEngine.TinyRPG;

namespace TinyEngine
{
    public partial class AssetPreviewer : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private AssetRef _asset;
        public AssetRef Asset
        {
            get
            {
                return _asset;
            }
            set
            {
                _asset = value;
                RefreshPreview();
            }
        }

        private AnimationLoader _anim = new AnimationLoader();
        private SpriteSheetLoader _spriteSheet = new SpriteSheetLoader();
        private SpriteSheetLoader.SpriteSheetPB pbSprite = new SpriteSheetLoader.SpriteSheetPB();
        private Font defaultFont;

        public AssetPreviewer()
        {
            InitializeComponent();
            SuspendLayout();
            pbSprite.Dock = DockStyle.Fill;
            pbSprite.Location = new Point(0, 0);
            pbSprite.Name = "pbSprite";
            pbSprite.Size = new Size(335, 306);
            pbSprite.TabIndex = 10;
            pbSprite.TabStop = false;
            Controls.Add(pbSprite);
            ResumeLayout(false);
            PerformLayout();
            defaultFont = txtPreview.Font;
        }

        private void AssetPreviewer_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private int cAnimFrame = 0;
        public void RefreshPreview()
        {
            pbPreview.Image = null;
            pbSprite.SpriteSheet = null;
            txtPreview.Visible = false;
            cAnimFrame = 0;
            animTimer.Stop();
            _anim.Dispose();
            _spriteSheet.Dispose();
            txtPreview.Font = defaultFont;
            switch (Asset.Type)
            {
                case AssetRef.AssetType.Animation:
                    _anim.Load(Asset.Name);
                    animTimer.Interval = (int)_anim.Delay;
                    animTimer.Start();
                    break;
                case AssetRef.AssetType.Bitmap:
                    pbPreview.Image = Util.LoadImage(Project.Current.GetBitmap(Asset.Name));
                    SetClientSizeCore(pbPreview.Image.Width, pbPreview.Image.Height);
                    break;
                case AssetRef.AssetType.Config:
                case AssetRef.AssetType.Dialog:
                case AssetRef.AssetType.Language:
                    txtPreview.Visible = true;
                    txtPreview.Text = File.ReadAllText(Project.Current.GetAsset(Asset.Name));
                    break;
                case AssetRef.AssetType.Font:
                    PrivateFontCollection fonts = new PrivateFontCollection();
                    string loc = Project.Current.GetAsset(Asset.Name);
                    fonts.AddFontFile(Project.Current.GetAsset(Asset.Name));
                    txtPreview.Visible = true;
                    txtPreview.Font = new Font(fonts.Families[0], 10f);
                    txtPreview.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
                    fonts.Dispose();
                    break;
                case AssetRef.AssetType.Spritesheet:
                    _spriteSheet.Load(Asset.Name);
                    pbSprite.SpriteSheet = _spriteSheet;
                    break;
                case AssetRef.AssetType.Sound:
                    Sound sound = Project.FindSoundInstance(Asset.Name);
                    sound.Play();
                    break;
            }
        }

        private void animTimer_Tick(object sender, EventArgs e)
        {
            if (cAnimFrame == _anim.Frames.Count)
                cAnimFrame = 0;
            pbPreview.Image = _anim.Frames[cAnimFrame];
            SetClientSizeCore(pbPreview.Image.Width, pbPreview.Image.Height);
            cAnimFrame++;
        }
    }
}
