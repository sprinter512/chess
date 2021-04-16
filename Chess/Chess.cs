using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Chess : Form
    {
        public const string DummyPath = @"C:\Users\gisiu\source\repos\Chess\Chess\";
        const int chessboarddim = 8;
        const int ControlsDim = 100;
        protected string ChosenFigure;

        ChessBoardField[,] chessBoard = new ChessBoardField[chessboarddim, chessboarddim];
        ChessBoardField[,] figures = new ChessBoardField[2, 6];

        public Chess()
        {
            ChessBoard();
            ChessOptions();
            InitializeComponent();
        }

        protected virtual void ChessBoard()
        {
            for (int i = 0; i < chessboarddim; i++)
            {
                for (int j = 0; j < chessboarddim; j++)
                {
                    chessBoard[i, j] = new ChessBoardField(i, j, (i + j) % 2 == 1 ? Color.White : Color.Black);
                    chessBoard[i, j].Click += ChessBoardClick;
                    chessBoard[i, j].Size = new Size(ControlsDim, ControlsDim);
                    chessBoard[i, j].Location = new Point(ControlsDim * i, ControlsDim * j);
                    //chessBoard[i, j].SetFigure(DummyPath + "WhiteKnight.png");
                    Controls.Add(chessBoard[i, j]);
                }
            }
            this.SuspendLayout();
        }

        private void ChessBoardClick(object sender, EventArgs e)
        {
            ChessBoardField figureButton = (ChessBoardField)sender;
            figureButton.SetFigure(ChosenFigure);
        }

        protected virtual void ChessOptions()
        {

            List<string> options = new List<string>()
            {
                "King","Queen","Rook","Knight","Bishop","Pawn"
            };

            for (int i = 0; i < 6; i++)
            {
                figures[0, i] = new ChessBoardField(0, 0, Color.Aqua);
                figures[0, i].Click += ChessOptionsClick;
                figures[1, i] = new ChessBoardField(0, 0, Color.Aqua);
                figures[1, i].Click += ChessOptionsClick;

                figures[0, i].Size = new Size(ControlsDim, ControlsDim);
                figures[0, i].Location = new Point(900, ControlsDim * i);
                figures[0, i].SetFigure(DummyPath + "White" + options[i] + ".png");
                Controls.Add(figures[0,i]);

                figures[1, i].Size = new Size(ControlsDim, ControlsDim);
                figures[1, i].Location = new Point(1000, ControlsDim * i);
                figures[1, i].SetFigure(DummyPath + "Black" + options[i] + ".png");
                Controls.Add(figures[1, i]);
            }

            this.SuspendLayout();
        }

        private void ChessOptionsClick(object sender, EventArgs e)
        {
            ChessBoardField figureButton = (ChessBoardField)sender;
            ChosenFigure = figureButton.GetFigure();
        }
    }
}

