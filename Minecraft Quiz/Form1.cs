using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Minecraft_Quiz
{
    public partial class Form1 : Form
    {
        Random rn = new Random(); //создаю новый рандом.

        int слогаемое1; //создаю две переменные для сложения.
        int слогаемое2;

        int уменьшаемое; //создаю две переменные для вычитания.
        int вычитаемое;

        int множимое; //создаю две переменные для умножения.
        int множитель;

        int делимое; //создаю две переменнные для деления.
        int делитель;

        int TimeLeft; //времени осталось... (для таймера).

        public Form1()
        {
            InitializeComponent();
        }

        private void linkVk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://vk.com/srmufa07");
        }

        public void StartTheQuiz()
        {
            //ОПЕРАЦИЯ СЛОЖЕНИЯ:
            слогаемое1 = rn.Next(51); //создает случайное число от 1 до 50.
            слогаемое2 = rn.Next(51);
            plusLeftLabel.Text = слогаемое1.ToString(); //переделываю в строку (string).
            plusRightLabel.Text = слогаемое2.ToString();
            sum.Value = 0; //эта строчка гарантирует, что СУММА будет 0 до присваивания ей каких-либо значений.

            //ОПЕРАЦИЯ ВЫЧИТАНИЯ:
            уменьшаемое = rn.Next(1, 101);//создает рандомное число.
            вычитаемое = rn.Next(1, уменьшаемое);
            minusLeftLabel.Text = уменьшаемое.ToString(); //переделываю в строку.
            minusRightLabel.Text = вычитаемое.ToString();
            difference.Value = 0; //эта строчка тоже гарантирует, что РАЗНОСТЬ будет 0.

            //ОПЕРАЦИЯ УМНОЖЕНИЯ:
            множимое = rn.Next(2, 11);
            множитель = rn.Next(2, 11);
            timesLeftLabel.Text = множимое.ToString(); //переделываю в сторку.
            timesRightLabel.Text = множитель.ToString();
            product.Value = 0; //анологично, как в прошлых операциях.

            //ОПЕРАЦИЯ ДЕЛЕНИЯ:
            делимое = rn.Next(2, 11);
            делитель = rn.Next(2, 11);
            int temporaryQuotient = rn.Next(2, 11); //это чтобы не получалось дробное число.
            делимое = делитель * temporaryQuotient; //это тоже. я хз че это)
            dividedLeftLabel.Text = делимое.ToString();
            dividedRightLabel.Text = делитель.ToString();
            quotient.Value = 0; //понятно.

            //УСТАНАВЛИВАЮ ТАЙМЕР:
            TimeLeft = 60; //задаю время.
            timeLabel.Text = "60 cекунд"; //вывожу текст.
            timer1.Start(); //запускаю.
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false; //можно ли нажать кнопку повторно.
        }

        private bool CheckTheAnswer() //проверяет правильные ли ответы.
        {
            if ((слогаемое1 + слогаемое2 == sum.Value)
                && (уменьшаемое - вычитаемое == difference.Value)
                && (множимое * множитель == product.Value)
                && (делимое / делитель == quotient.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer()) //если ответы правильные.
            {
                timer1.Stop(); //таймер останавливается.
                MessageBox.Show("Молодец!", "Тест пройден!"); //высвечивается сообщение о "победе".
                startButton.Enabled = true; //кнопка старта опять доступна.
            }

            else if (TimeLeft > 0) //если время больше 0.
            {
                TimeLeft = TimeLeft - 1; //убирается 1 секунда.
                timeLabel.Text = TimeLeft + " секунд"; //показывет, что осталось ... секунд.
            }

            else
            {
                timer1.Stop(); //если время вышло.
                timeLabel.Text = "Время вышло!";
                MessageBox.Show("Ты не успел(а), лошара))");
                sum.Value = слогаемое1 + слогаемое2;
                difference.Value = уменьшаемое - вычитаемое;
                product.Value = множимое * множитель;
                quotient.Value = делимое / делитель;
                startButton.Enabled = true;
            }
        }
    }
}
