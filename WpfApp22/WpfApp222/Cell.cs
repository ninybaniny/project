using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace WpfApp222
{
    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Row, Col;

        string file = "empty.png";
        public virtual Brush Bkg { get => Brushes.Transparent; set { } }
        public virtual string File { get => GetImageUri(file); set { file = value; Fire(); } }
        protected string GetImageUri(string shortname)
        {
            string ass = new AssemblyName(GetType().Assembly.FullName).Name;
            return "/" + ass + ";component/images/" + shortname;
        }
        protected void Fire([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
    class Player : Cell
    {
        int score = 0;

        string file = "player.png";
        override public string File { get => GetImageUri(file); set { file = value; Fire(); } }
        public int Score { get => score; set { score = value; Fire("Score"); } }
    }
    class Wall : Cell
    {
        string file = "wall.png";
        public override string File { get => GetImageUri(file); set { file = value; Fire("File"); } }

        Brush bkg = Brushes.Black;
        public override Brush Bkg { get => bkg; set { bkg = value; Fire(); } }

    }
    class Klyuch : Cell
    {
        string file = "key.png";
        new public string File { get => GetImageUri(file); set { file = value; Fire("File"); } }

        Brush bkg = Brushes.Transparent;
        public override Brush Bkg { get => bkg; set { bkg = value; Fire(); } }
    }
    class Exit : Cell
    {
       // int exit = 0;

        string file = "star.png";
      new public string File { get => GetImageUri(file); set { file = value; } }

       Brush bkg = Brushes.Transparent;
       public override Brush Bkg { get => bkg; set { bkg = value; } }
       // public int Exit1 { get => exit; set { exit = value; Fire("Score"); } }
    }
}
