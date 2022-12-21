using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace WpfApp222
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {

           public int[,] mas = new int[15, 15] //Изначальный массив лабиринта
            {

                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1 },
                { 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 9 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };
        ObservableCollection<ObservableCollection<Cell>> karta;
        static int sizeCol = 15;
        static int sizeRow = 15;
        static int player_row = 1;
        static int player_col = 1;
        static int key_row = 2;
        static int key_col = 1;
        Player player = new Player { Row = player_row, Col = player_col };
        Klyuch klyuch = new Klyuch { Row = key_row, Col = key_col };
        //Exit exit = new Exit { Row = key_row, Col = key_col };
        public Game()
        {
            InitializeComponent();
            GetMap();
            rightBorder.DataContext = player;
        }
        void Win() //победа
        {
            if (player.Score == 0)
            {
                MessageBox.Show("Возьми ключ!");
            }
            //if(exit.Exit1==1)
            else
            {
                MessageBox.Show("Вы выбрались!");
                Close();
            }
        }

        private void Window_KeyDown(Object sender, KeyEventArgs e) //события нажатия клавиш
        {
            int dx = 0, dy = 0;
            switch (e.Key)
            {
                case Key.Up:
                    dy = -1;
                    break;
                case Key.Right:
                    dx = 1;
                    break;
                case Key.Down:
                    dy = 1;
                    break;
                case Key.Left:
                    dx = -1;
                    break;
            }

            int Y = player.Row, X = player.Col;
            int nextY = Y + dy, nextX = X + dx;
            bool CanMove = false;

            if (nextY < 0 || nextY > 14) return; // 14 надо заменить на константы размера
            if (nextX < 0 || nextX > 14) return;

            Cell target = karta[nextY][nextX];

            if (target is Klyuch)
            {
                player.Score++;
                CanMove = true;
            }
             if (Y==6 && X==14)
            {
               // exit.Exit1++;
                CanMove = true;
                Win();
            }
            else if (target is Wall)
            {

            }
            else
            {
                CanMove = true;
            }

            if (CanMove)
            {
                karta[Y][X] = new Cell() { Row = Y, Col = X };
                karta[nextY][nextX] = player;
                player.Row = nextY;
                player.Col = nextX;
            }
        }

        void GetMap()//создание карты
        {
            //1 - стена
            //0 - пространство
            //9 - выход
            //5 - игрок
            //8 - ключ
            while (mas[player_row, player_col] == 1) //Размещение игрока
            {
                Random rnd = new Random();
                player_row = rnd.Next(1, 14);
                player_col = rnd.Next(1, 14);

            }
            mas[player_row, player_col] = 5;
            while (mas[key_row, key_col] == 1) //Размещение ключа
            {
                Random rnd = new Random();
                key_row = rnd.Next(1, 14);
                key_col = rnd.Next(1, 14);
            }
            mas[key_row, key_col] = 8;

            karta = new ObservableCollection<ObservableCollection<Cell>>();
            for (int i = 0; i < sizeRow; i++)
            {
                karta.Add(new ObservableCollection<Cell>());
                for (int j = 0; j < sizeCol; j++)
                {
                    switch (mas[i, j])
                    {
                        case 1:
                            karta[i].Add(new Wall { Row = i, Col = j });
                            break;
                        case 0:
                            karta[i].Add(new Cell { Row = i, Col = j });
                            break;
                        case 5:
                            karta[i].Add(new Player { Row = i, Col = j });
                            break;
                      case 8:
                           karta[i].Add(new Klyuch { Row = i, Col = j });
                           break;
                        case 9:
                            karta[i].Add(new Exit { Row = i, Col = j });
                            break;
                    }
                }
            }
            player.File = "player.png";
            klyuch.File = "key.png";
            karta[player.Row][player.Col] = new Cell { Row = player.Row, Col = player.Col };

            player.Row = player_row;
            player.Col = player_col;
            karta[player_row][player_col] = player;
            ic.ItemsSource = karta;
        }
    }

}