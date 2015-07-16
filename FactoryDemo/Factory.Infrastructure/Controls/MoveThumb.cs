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
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Control designerItem = this.DataContext as Control;

            if (designerItem != null)
            {
                if (designerItem.Parent is Canvas)
                {
                    Canvas parent = ((Canvas)designerItem.Parent);
                  
                    foreach (Control child in parent.Children)
                    {
                        if (child != designerItem)
                        {


                            double left1 = Canvas.GetLeft(child);
                            if (left1 > 0)
                            {

                            }
                        }
                    }
                }
                

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
