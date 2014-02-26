using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Linq;
namespace MySnake
{
    class Snake
    {
        private Rectangle[] snakeRec;

        public Rectangle[] SnakeRec
        {
            get
            {
                return snakeRec; 
            }
        }
        private SolidBrush bursh;
        private int x, y, width, height;

        /// Hàm khởi tạo rắn

        public Snake()
        {
            snakeRec = new Rectangle[3];//truyền độ dài con rắn

            bursh = new SolidBrush(Color.Brown); // truyền màu cho rắn

            x = 20; y = 0; width = 10; height = 10; // tạo rắn hình tròn

            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 10;// để không bị đè
            }
        }

        // Vẽ Rắn
        public void drawSnake(Graphics paper)
        {
            foreach ( Rectangle rec in snakeRec)
            {
                paper.FillEllipse(bursh, rec);
            }
        }

        // Vẽ rắn trong lúc di chuyển
        public void drawSnakeRun()
        {
            for(int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }

        public void moveDown()
        {
            drawSnakeRun();
            snakeRec[0].Y += 10;
        }

        public void moveUp()
        {
            drawSnakeRun();
            snakeRec[0].Y -= 10;
        }

        public void moveRight()
        {
            drawSnakeRun();
            snakeRec[0].X += 10;
        }

        public void moveLeft()
        {
            drawSnakeRun();
            snakeRec[0].X -= 10;
        }

        public void growSnake()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X,snakeRec[snakeRec.Length - 1].Y, width, height));
            snakeRec = rec.ToArray();//cập nhật lại 
        }




       
    }
}
