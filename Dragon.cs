using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragonRageFlight
{
    public class Dragon
    {
        public int positionToStart { get; set; }
        public int positionToFinish { get; set; }
        public PictureBox dragonImage { get; set; }
        private Random randomSpeed = new Random();

        public bool Fly()
        {
            Point CurrentCoordinates = dragonImage.Location;
            CurrentCoordinates.X += randomSpeed.Next(1, 6);
            dragonImage.Location = CurrentCoordinates;
            if(CurrentCoordinates.X >= positionToFinish)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveDragonsToStart()
        {
            dragonImage.Left = positionToStart;
        }

    }
}
