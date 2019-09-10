using System.Windows;
using System.Windows.Controls;

namespace OneWayTwoWayBinding
{
    public class ListViewBehaviour
    {
        /// <summary>
        /// Enfoca automaticament el item sel·leccionat
        /// </summary>
        public static readonly DependencyProperty AutoUnselectItemProperty =
            DependencyProperty.RegisterAttached(
                "AutoUnselect",
                typeof(bool),
                typeof(ListViewBehaviour),
                new UIPropertyMetadata(false, OnAutoUnselectItemChanged));

        public static bool GetAutoUnselectItem(ListView listBox)
        {
            return (bool)listBox.GetValue(AutoUnselectItemProperty);
        }

        public static void SetAutoUnselectItem(ListView listBox, bool value)
        {
            listBox.SetValue(AutoUnselectItemProperty, value);
        }

        private static void OnAutoUnselectItemChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var listView = source as ListView;
            if (listView == null)
                return;

            if (e.NewValue is bool == false)
                listView.SelectionChanged -= OnSelectionChanged;
            else
                listView.SelectionChanged += OnSelectionChanged;
        }

        private static void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO write custom selection behaviour
        }
    }
}