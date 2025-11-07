using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CtrlLib.MyControls
{
    /// <summary>トグルボタン共通機能</summary>
    public class ToggleButton : Control
    {
        private class MyRectangle
        {
            private GraphicsPath grPath;
            private float x;
            private float y;
            private float width;
            private float height;

            public MyRectangle()
            {
            }
            public MyRectangle(float _width, float _height, float _radius, float _x = 0f, float _y = 0f)
            {
                x = _x;
                y = _y;
                width = _width;
                height = _height;
                grPath = new GraphicsPath();
                if (_radius <= 0f)
                {
                    grPath.AddRectangle(new RectangleF(x, y, width, height));
                }
                else
                {
                    RectangleF ef = new RectangleF(x, y, 2f * _radius, 2f * _radius);
                    RectangleF ef2 = new RectangleF(width - (2f * _radius) - 1f, x, 2f * _radius, 2f * _radius);
                    RectangleF ef3 = new RectangleF(x, height - (2f * _radius) - 1f, 2f * _radius, 2f * _radius);
                    RectangleF ef4 = new RectangleF(width - (2f * _radius) - 1f, height - (2f * _radius) - 1f, 2f * _radius, 2f * _radius);

                    grPath.AddArc(ef, 180f, 90f);
                    grPath.AddArc(ef2, 270f, 90f);
                    grPath.AddArc(ef4, 0f, 90f);
                    grPath.AddArc(ef3, 90f, 90f);
                    grPath.CloseAllFigures();
                }
            }

            public GraphicsPath path => grPath;
            public RectangleF Rect => new RectangleF(x, y, width, height);
            public float Radius { get; set; }
        }

        private float _diameter;
        private MyRectangle _rect;
        private RectangleF _circle;
        private bool _isON;
        private float _artis;
        private Color _borderColor;
        private bool _textEnabled;
        private string _onText = "";
        private string _offText = "";
        private Color _onColor;
        private Color _offColor;
        private Timer _paintTicker = new Timer();

        /// <summary>ステータス変更のイベント</summary>
        public event SliderChangedEventHandler SliderValueChanged;
        /// <summary>スライダーイベントのハンドル</summary>
        /// <param name="sender">送信対象</param>
        /// <param name="e">引数</param>
        public delegate void SliderChangedEventHandler(object sender, EventArgs e);

        /// <summary>初期設定</summary>
        public ToggleButton()
        {
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            _artis = 4f;
            _diameter = 30f;
            _rect = new MyRectangle(2f * _diameter, _diameter + 2f, _diameter / 2f, 1f, 1f);
            _circle = new RectangleF(1f, 1f, _diameter, _diameter);
            _isON = false;
            _textEnabled = true;
            _borderColor = Color.LightGray;
            _paintTicker.Tick += new EventHandler(paintTicker_Tick);
            _paintTicker.Interval = 200;
            _onColor = Color.Green;
            _offColor = Color.DarkGray;
            ForeColor = Color.White;
            _onText = "ON";
            _offText = "OFF";
        }

        /// <summary>有効化のステータス変更に</summary>
        /// <param name="e">引数</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate(); //再び描く
            base.OnEnabledChanged(e);
        }
        /// <summary>左クリックにステータス更新</summary>
        /// <param name="e">引数</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                toggle();
                base.OnMouseDown(e);
            }
        }

        /// <summary>描画イベント</summary>
        /// <param name="e">引数</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (base.Enabled)
            {
                //背景を描く
                using (SolidBrush brush = new SolidBrush(IsOn ? _onColor : _offColor))
                {
                    e.Graphics.FillPath(brush, _rect.path);
                }
                using (Pen pen = new Pen(_borderColor, 2f))
                {
                    e.Graphics.DrawPath(pen, _rect.path);
                }
                
                //テキストを描く
                if (_textEnabled)
                {
                    using (Font font = new Font("MS UI Gothic", (8.2f * _diameter) / 30f, FontStyle.Bold))
                    {
                        SolidBrush b = new SolidBrush(ForeColor);
                        if (IsOn)
                        {
                            int height = TextRenderer.MeasureText(_onText, base.Font).Height;
                            float num2 = (_diameter - height) / 2f;
                            e.Graphics.DrawString(_onText, base.Font, b, 5f, num2 + 1f);
                        }
                        else
                        {
                            int height = TextRenderer.MeasureText(_offText, base.Font).Height;
                            float num2 = (_diameter - height) / 2f;
                            e.Graphics.DrawString(_offText, base.Font, b, _diameter + 2f, num2 + 1f);
                        }
                    }
                }

                //丸を描く
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillEllipse(brush, _circle);
                }
                using (Pen pen = new Pen(Color.LightGray, 1.2f))
                {
                    e.Graphics.DrawEllipse(pen, _circle);
                }
            }

            base.OnPaint(e);
        }

        /// <summary>サイズ変更のイベント</summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.Width = (Height - 2) * 2;
            _diameter = Width / 2;
            _artis = (4f * _diameter) * 30f;
            _rect = new MyRectangle(2f * _diameter, _diameter + 2f, _diameter / 2f, 1f, 1f);
            _circle = new RectangleF(!IsOn ? 1f : (Width - _diameter - 1f), 1f, _diameter, _diameter);
            base.OnResize(e);
        }

        private void paintTicker_Tick(object sender, EventArgs e)
        {
            float x = _circle.X;
            if (IsOn)
            {
                if ((x + _artis) <= (Width - _diameter) - 1f)
                {
                    x += _artis;
                    _circle = new RectangleF(x, 1f, _diameter, _diameter);
                    Invalidate();
                }
                else
                {
                    x = Width - _diameter - 1f;
                    _circle = new RectangleF(x, 1f, _diameter, _diameter);
                    Invalidate();
                    _paintTicker.Stop();
                }
            }
            else if (x - _artis >= 1f)
            {
                x -= _artis;
                _circle = new RectangleF(x, 1f, _diameter, _diameter);
            }
            else
            {
                _circle = new RectangleF(1f, 1f, _diameter, _diameter);
                Invalidate();
                _paintTicker.Stop();
            }
        }

        /// <summary>ステータスを変更</summary>
        public void toggle()
        {
            _isON = !_isON;
            IsOn = _isON;
        }

        /// <summary>テキスト表示</summary>
        public bool ShowText
        {
            get => _textEnabled;
            set
            {
                _textEnabled = value;
                Invalidate();
            }
        }

        /// <summary>有効化</summary>
        /// <remarks>True：有効化、False：無効化</remarks>
        public bool IsOn
        {
            get => _isON;
            set
            {
                _paintTicker.Stop();
                _isON = value;
                _paintTicker.Start();
                if (SliderValueChanged != null)
                    SliderValueChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>ボーダー色</summary>
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>元々のサイズ</summary>
        protected override Size DefaultSize => new Size(60, 35);
        /// <summary>有効化のテキスト</summary>
        public string onText
        {
            get => _onText;
            set
            {
                _onText = value;
                Invalidate();
            }
        }
        /// <summary>無効化のテキスト</summary>
        public string offText
        {
            get => _offText;
            set
            {
                _offText = value;
                Invalidate();
            }
        }
        /// <summary>有効化の色</summary>
        public Color onColor
        {
            get => _onColor;
            set
            {
                _onColor = value;
                Invalidate();
            }
        }
        /// <summary>無効化の色</summary>
        public Color offColor
        {
            get => _offColor;
            set
            {
                _offColor = value;
                Invalidate();
            }
        }
    }
}
