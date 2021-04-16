using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class ChessBoardField : Button
    {
        protected int DimX;
        protected int DimY;
        protected string IconPath;

        public ChessBoardField(int x, int y, Color color)
        {
            DimX = x;
            DimY = y;

            this.BackColor = color;
        }

        public void SetFigure(string iconPath)
        {
            IconPath = iconPath;
            Bitmap picture = new Bitmap(iconPath);

            this.Image = picture;
            
        }

        public string GetFigure()
        {
            return IconPath;
        }
    }
}
