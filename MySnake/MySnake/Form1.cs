using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySnake
{
    public partial class Form1 : Form
    {
        int score = 0;
        Random randFood = new Random();

        Food food;

        Graphics paper;

        Snake snake = new Snake();

        Boolean left = false, right = false, up = false, down = false;// khai báo 4 biến tg trưng cho đi lên , xuống...

        public Form1()
        {
            InitializeComponent();
            food = new Food(randFood);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            // vẽ rắn 
            //SolidBrush sb = new SolidBrush(Color.Red);

            //Graphics g = this.CreateGraphics();
            //g.FillEllipse(sb, new Rectangle(0, 0, 10, 10));
            //g.FillEllipse(sb, new Rectangle(0, 0, 10, 10));
            //g.FillEllipse(sb, new Rectangle(0, 0, 10, 10));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            
            //vẽ thực phẩm
            food.drawFood(paper);
            snake.drawSnake(paper);

            ////kiểm tra thực phẩm sau khi trạm vào sinh ra thực phẩm có tọa độ mới
            //for (int i = 0; i < snake.snakeRec.Length; i++)
            //{
            //    if (snake.snakeRec[i].IntersectsWith(food.foodRec))
            //    {
            //        food.foodLocation(randFood);
            //    }
            //}

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Enter)
            {
                timer1.Enabled = true;
                left = false; right = false; up = false; down = false;
                label1.Text = "";
            }
            if(e.KeyData== Keys.Up && down == false)
            {
                up = true;
                down = false;
                left = false;
                right = false;
            }

            if (e.KeyData == Keys.Down && up == false)
            {
                up = false;
                down = true;
                left = false;
                right = false;
            }

            if (e.KeyData == Keys.Left && right == false)
            {
                up =false;
                down = false;
                left = true;
                right = false;
            }
      
            if (e.KeyData == Keys.Right && left == false)
            {
                up = false;
                down = false;
                left = false;
                right = true;
            }            

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelScore.Text = score.ToString();

            if (down == true) { snake.moveDown(); }

            if (up == true) { snake.moveUp(); }

            if (right == true) { snake.moveRight(); }

            if (left == true) { snake.moveLeft(); }

            //kiểm tra thực phẩm sau khi trạm vào sinh ra thực phẩm có tọa độ mới
            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodRec))
                {
                    score += 5;
                    snake.growSnake();// mỗi lần va trạm food thì tăng độ dài rắn lên
                    food.foodLocation(randFood);
                }
            }
            collision();
            this.Invalidate();//thao tác này để cập nhật lại
        }

        // hàm va trạm
        public void collision()
        {
            for (int i = 1; i < snake.SnakeRec.Length;i++ )
            {
                if(snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                {
                    Restart();
                }
            }
            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > 290)
            {
                Restart();
            }
            if (snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > 290)
            {
                Restart();
            }
        }

        void Restart()
        {
            timer1.Enabled = false;
            label1.Text = "Bấm phím Enter để bắt đầu chơi";
            toolStripStatusLabelScore.Text = "0";
            score = 0;
            MessageBox.Show(" ^_^ Ngủm củ tỏi ^_^");
            snake = new Snake();
        }
    }

    

}
