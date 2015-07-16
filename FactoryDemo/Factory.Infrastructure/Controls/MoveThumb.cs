using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Factory.Infrastructure.Controls
{
    public class MoveThumb : Thumb
    {
        public MoveThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
            TouchMove += MoveThumb_TouchMove;
        }

        void MoveThumb_TouchMove(object sender, System.Windows.Input.TouchEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Control designerItem = this.DataContext as Control;

            if (designerItem != null)
            {
               

                double left = Canvas.GetLeft(designerItem);
                double top = Canvas.GetTop(designerItem);

                double newleft = left + e.HorizontalChange;
                double newtop =top + e.VerticalChange;
                if (newleft<0)
                {
                    newleft = 0;
                }
                if (newtop < 0)
                {
                    newtop = 0;
                }
                Canvas.SetLeft(designerItem, newleft);
                Canvas.SetTop(designerItem, newtop);
            }
        }
    }
}
