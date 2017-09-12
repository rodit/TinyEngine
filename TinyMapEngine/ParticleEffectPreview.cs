using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using TinyMapEngine.Maps;

namespace TinyMapEngine
{
    public partial class ParticleEffectPreview : Form
    {
        public ParticleEffect Effect { get; set; }

        public ParticleEffectPreview(ParticleEffect effect)
        {
            InitializeComponent();
            Effect = effect;
        }

        private void ParticleEffectPreview_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;

            ClientSize = new Size(Effect.Width, Effect.Height);
            ParticleEffectRenderer render = new ParticleEffectRenderer(Effect);
            render.Size = ClientSize;
            Controls.Add(render);
        }
    }

    public class ParticleEffectRenderer : Control
    {
        public const float SPEED_FACTOR = 2f;

        public ParticleEffect Effect { get; set; }

        private Random random = new Random();
        private long startTime = -1L;
        private float[] pointX;
        private float[] pointY;
        private Color[] pointColors;
        private bool[] free;
        private float[] pointAngles;
        private int sourceX;
        private int sourceY;
        private int maxVary;
        private float range;

        private Pen pen = new Pen(new SolidBrush(Color.Black));

        public ParticleEffectRenderer(ParticleEffect effect) : base()
        {
            DoubleBuffered = true;

            Effect = effect;
            pointX = new float[Effect.Max];
            pointY = new float[Effect.Max];
            pointColors = new Color[Effect.Max];
            free = new bool[Effect.Max];
            pointAngles = new float[Effect.Max];
            switch (Effect.Type)
            {
                case ParticleEffect.ParticleType.Upwards:
                    sourceX = Effect.X + Effect.Width / 2;
                    sourceY = Effect.Y + Effect.Height;
                    range = Effect.Height;
                    maxVary = effect.Width;
                    break;
                case ParticleEffect.ParticleType.Leftwards:
                    sourceX = Effect.X + Effect.Width;
                    sourceY = Effect.Y + Effect.Height / 2;
                    range = Effect.Width;
                    maxVary = effect.Height;
                    break;
                case ParticleEffect.ParticleType.Rightwards:
                    sourceX = Effect.X;
                    sourceY = Effect.Y + Effect.Height / 2;
                    range = Effect.Width;
                    maxVary = effect.Height;
                    break;
                case ParticleEffect.ParticleType.Downards:
                    sourceX = Effect.X + Effect.Width / 2;
                    sourceY = Effect.Y;
                    range = Effect.Height;
                    maxVary = effect.Width;
                    break;
                case ParticleEffect.ParticleType.Radial:
                    sourceX = Effect.X + Effect.Width / 2;
                    sourceY = Effect.Y + Effect.Height / 2;
                    range = Effect.Width / 2f;
                    maxVary = effect.Width / 2;
                    break;
            }
            pen.Width = Effect.Size;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int frameStart = Environment.TickCount;
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Black, Bounds);

            if (Effect.Duration > 0)
            {
                if (startTime == -1L)
                    startTime = Environment.TickCount;
                if (Environment.TickCount - startTime >= Effect.Duration)
                {
                    return;
                }
            }
            if (random.NextDouble() >= 1d - Effect.Chance)
            {
                int nextIndex = GetNextFree();
                if (nextIndex > -1)
                {
                    Color color = Effect.Colors.Count == 1 ? Effect.Colors[0] : Effect.Colors[random.Next(Effect.Colors.Count)];
                    float spawnX = sourceX, spawnY = sourceY;
                    switch (Effect.Type)
                    {
                        case ParticleEffect.ParticleType.Upwards:
                        case ParticleEffect.ParticleType.Downards:
                            spawnX = random.Next((sourceX - maxVary / 2), (sourceX + maxVary / 2));
                            break;
                        case ParticleEffect.ParticleType.Leftwards:
                        case ParticleEffect.ParticleType.Rightwards:
                            spawnY = random.Next((sourceY - maxVary / 2), (sourceY + maxVary / 2));
                            break;
                        case ParticleEffect.ParticleType.Radial:
                            spawnX = random.Next((sourceX - maxVary / 2), (sourceX + maxVary / 2));
                            spawnY = random.Next((sourceY - maxVary / 2), (sourceY + maxVary / 2));
                            pointAngles[nextIndex] = (float)(random.NextDouble() * 360d);
                            break;
                    }
                    SetPoint(nextIndex, spawnX, spawnY, color);
                    free[nextIndex] = false;
                }
            }
            for (int i = 0; i < Effect.Max; i++)
            {
                if (free[i])
                    continue;
                float cx = pointX[i];
                float cy = pointY[i];
                double distance = DistanceFromSource(cx, cy);
                if (distance >= range)
                    free[i] = true;
                else
                {
                    MovePoint(i, cx, cy);
                    pen.Color = pointColors[i];
                    e.Graphics.DrawRectangle(pen, pointX[i] - Effect.X, pointY[i] - Effect.Y, 1f, 1f);
                }
            }
            int diff = Environment.TickCount - frameStart;
            if (diff < 16)
            {
                Thread.Sleep(16 - diff);
            }
            Invalidate();
        }

        private void MovePoint(int index, float cx, float cy)
        {
            double nx = cx;
            double ny = cy;
            int imvxn = (sourceX - maxVary / 2);
            int imvxp = (sourceX + maxVary / 2);
            int imvyn = (sourceY - maxVary / 2);
            int imvyp = (sourceY + maxVary / 2);
            float move = Effect.Speed * SPEED_FACTOR;
            switch (Effect.Type)
            {
                case ParticleEffect.ParticleType.Downards:
                    nx = random.NextBool() ? Math.Max(imvxn, nx - random.NextDouble(0f, move)) : Math.Min(imvxp, nx + random.NextDouble(0f, move));
                    ny = cy + move;
                    break;
                case ParticleEffect.ParticleType.Upwards:
                    nx = random.NextBool() ? Math.Max(imvxn, nx - random.NextDouble(0f, move)) : Math.Min(imvxp, nx + random.NextDouble(0f, move));
                    ny = cy - move;
                    break;
                case ParticleEffect.ParticleType.Leftwards:
                    nx = cx - move;
                    ny = random.NextBool() ? Math.Max(imvyn, ny - random.NextDouble(0f, move)) : Math.Min(imvyp, ny + random.NextDouble(0f, move));
                    break;
                case ParticleEffect.ParticleType.Rightwards:
                    nx = cx + move;
                    ny = random.NextBool() ? Math.Max(imvyn, ny - random.NextDouble(0f, move)) : Math.Min(imvyp, ny + random.NextDouble(0f, move));
                    break;
                case ParticleEffect.ParticleType.Radial:
                    float angle = pointAngles[index];
                    nx = cx + move * Math.Cos(angle);
                    ny = cy + move * Math.Sin(angle);
                    break;
            }
            pointX[index] = (float)nx;
            pointY[index] = (float)ny;
        }

        private double DistanceFromSource(float cx, float cy)
        {
            return Math.Sqrt(Math.Pow(Math.Abs((cx - sourceX)), 2) + Math.Pow(Math.Abs((cy - sourceY)), 2));
        }

        private void SetPoint(int index, float x, float y, Color color)
        {
            pointX[index] = x;
            pointY[index] = y;
            pointColors[index] = color;
        }

        private int GetNextFree()
        {
            for (int i = 0; i < free.Length; i++)
                if (free[i])
                    return i;
            return -1;
        }
    }
}
