﻿using System;
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

namespace DragDropExample
{
    /// <summary>
    /// Interaction logic for Circle.xaml
    /// </summary>
    public partial class Circle : UserControl
    {
        private Brush _previousFill = null;

        public Circle()
        {
            InitializeComponent();
        }

        public Circle(Circle c)
        {
            InitializeComponent();
            this.circleUI.Height = c.circleUI.Height;
            this.circleUI.Width = c.circleUI.Height;
            this.circleUI.Fill = c.circleUI.Fill;
            
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                //Package the data
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, circleUI.Fill.ToString());
                data.SetData("Double", circleUI.Height);
                data.SetData("Object", this);

                // Initiate the drag-and-drop operation. This method takes dragSource, data(the dataObject created) and the allowed operations
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                // If the string can be converted into a Brush,
                // convert it and apply it to the ellipse.
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    Brush newFill = (Brush)converter.ConvertFromString(dataString);
                    circleUI.Fill = newFill;

                    // Set Effects to notify the drag source what effect
                    // the drag-and-drop operation had.
                    // (Copy if CTRL is pressed; otherwise, move.)
                    if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                    {
                        e.Effects = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effects = DragDropEffects.Move;
                    }
                }
            }
            e.Handled = true;
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            // Save the current Fill brush so that you can revert back to this value in DragLeave.
            _previousFill = circleUI.Fill;

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string dataString = (string)e.Data.GetData(DataFormats.Text);

                // If the string can be converted into a Brush, convert it.
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    Brush newFill = (Brush)converter.ConvertFromString(dataString.ToString());
                    circleUI.Fill = newFill;
                }
            }
        }

        protected override void OnDragLeave(DragEventArgs e)
        {
            base.OnDragLeave(e);
            // Undo the preview that was applied in OnDragEnter.
            circleUI.Fill = _previousFill;
        }
    }
}
