﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace OneWayTwoWayBinding
{
    public static class SelectorBehavior
    {
        #region bool ShouldSelectItemOnMouseUp

        public static readonly DependencyProperty ShouldSelectItemOnMouseUpProperty =
            DependencyProperty.RegisterAttached(
                "ShouldSelectItemOnMouseUp", typeof(bool), typeof(SelectorBehavior),
                new PropertyMetadata(default(bool), HandleShouldSelectItemOnMouseUpChange));

        public static void SetShouldSelectItemOnMouseUp(DependencyObject element, bool value)
        {
            element.SetValue(ShouldSelectItemOnMouseUpProperty, value);
        }

        public static bool GetShouldSelectItemOnMouseUp(DependencyObject element)
        {
            return (bool)element.GetValue(ShouldSelectItemOnMouseUpProperty);
        }

        private static void HandleShouldSelectItemOnMouseUpChange(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Selector selector)
            {
                selector.PreviewMouseDown -= HandleSelectPreviewMouseDown;
                selector.MouseUp -= HandleSelectMouseUp;

                if (Equals(e.NewValue, true))
                {
                    selector.PreviewMouseDown += HandleSelectPreviewMouseDown;
                    selector.MouseUp += HandleSelectMouseUp;
                }
            }
        }

        private static void HandleSelectMouseUp(object sender, MouseButtonEventArgs e)
        {
            var selector = (Selector)sender;

            if (e.ChangedButton == MouseButton.Left && e.OriginalSource is Visual source)
            {
                var container = selector.ContainerFromElement(source);
                if (container != null)
                {
                    var index = selector.ItemContainerGenerator.IndexFromContainer(container);
                    if (index >= 0)
                    {
                        selector.SelectedIndex = index;
                    }
                }
            }
        }

        private static void HandleSelectPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = e.ChangedButton == MouseButton.Left;
        }
        #endregion

    }

}