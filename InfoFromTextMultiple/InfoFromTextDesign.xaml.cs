using System;
using System.Activities;
using System.Activities.Presentation.Converters;
using System.Activities.Presentation.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using InfoFromText;
namespace InfoFromText
{
    // Lógica de interação para InfoFromTextDesign.xaml
    public partial class InfoFromTextDesign
    {
        public List<StackPanel> items = new List<StackPanel>();
        public static Grid grid;
        StackPanel stack = new StackPanel();
        RowDefinition gridRow = new RowDefinition();
        int i = 0;


        public InfoFromTextDesign()
        {
            InitializeComponent();
            grid = beGrid;
        }


        private void AddNewLine(object sender, RoutedEventArgs e)
        {
            CreateLine(); i++;
        }
        private void CreateLine()
        {
            gridRow = new RowDefinition();
            gridRow.Tag = i.ToString();
            ColumnDefinition columnTo = new ColumnDefinition();
            ColumnDefinition columnEqual = new ColumnDefinition();
            ColumnDefinition columnExpressionOne = new ColumnDefinition();
            ColumnDefinition columnAnd = new ColumnDefinition();
            ColumnDefinition columnExpressionTwo = new ColumnDefinition();
            ColumnDefinition columnComma = new ColumnDefinition();
            ColumnDefinition columnParagraph = new ColumnDefinition();
            ColumnDefinition columnButtonClose = new ColumnDefinition();
            gridRow.Height = new GridLength(1, GridUnitType.Auto);

            grid.ColumnDefinitions.Add(columnTo);
            grid.ColumnDefinitions.Add(columnEqual);
            grid.ColumnDefinitions.Add(columnExpressionOne);
            grid.ColumnDefinitions.Add(columnAnd);
            grid.ColumnDefinitions.Add(columnExpressionTwo);
            grid.ColumnDefinitions.Add(columnComma);
            grid.ColumnDefinitions.Add(columnParagraph);
            grid.ColumnDefinitions.Add(columnButtonClose);

            grid.RowDefinitions.Add(gridRow);
            stack = new StackPanel { Margin = new Thickness(2) };
            stack.Orientation = Orientation.Horizontal;



            ExpressionTextBox To = new ExpressionTextBox
            {
                Name = "TO",
                Expression = OutputTemplete.Expression,
                ExpressionType = OutputTemplete.ExpressionType,
                OwnerActivity = ModelItem,
                UseLocationExpression = true,
                HintText = "To",
                Width = 90,
                Margin = new Thickness(2),
            };

            TextBlock igual = new TextBlock
            {
                Text = "=",
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(2)
            };

            ExpressionTextBox expressionOne = new ExpressionTextBox
            {
                Expression = InputString.Expression,
                ExpressionType = InputString.ExpressionType,
                OwnerActivity = ModelItem,
                HintText = "Enter argument1",
                Width = 110,
                Margin = new Thickness(2)

            };
            TextBlock and = new TextBlock
            {
                Text = "and",
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(2)
            };

            ExpressionTextBox expressionTwo = new ExpressionTextBox
            {
                Expression = InputString.Expression,
                ExpressionType = InputString.ExpressionType,
                OwnerActivity = ModelItem,
                HintText = "Enter argument2",
                Width = 110,
                Margin = new Thickness(2),
              
            };
            var binding = new Binding()
            {
                Mode = BindingMode.TwoWay,
                Converter = new ArgumentToExpressionConverter(),
                ConverterParameter = "In",
                Path = new PropertyPath("ModelItem.Inputs[(0)]")
            };

            TextBlock comma = new TextBlock
            {
                Text = "paragraph",
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(2)
            };


            ExpressionTextBox paragraphNumber = new ExpressionTextBox()
            {
                Expression = InputInt.Expression,
                ExpressionType = InputInt.ExpressionType,
                OwnerActivity = ModelItem,
                UseLocationExpression = true,
                HintText = "Enter paragraph number",
                Width = 50,
                Margin = new Thickness(2),
            };

            /*
            To.SetBinding(Exemple., bindingOut);
            expressionTwo.SetBinding(ExpressionTextBox.ExpressionProperty, bindingIn);
            paragraphNumber.SetBinding(ExpressionTextBox.ExpressionProperty, bindingIn);*/

   

            var index = i + 1;
            Button btnClose = new Button
            {
                Tag = $"{i}",
                Content = "X",
                FontSize = 12,
                Width = 24,
                Height = 24,
                Margin = new Thickness(2)
            };
            btnClose.AddHandler(Button.ClickEvent, new RoutedEventHandler(RemoveRow));

            Grid.SetColumn(To, 0);
            Grid.SetColumn(igual, 1);
            Grid.SetColumn(expressionOne, 2);
            Grid.SetColumn(and, 3);
            Grid.SetColumn(expressionTwo, 4);
            Grid.SetColumn(comma, 5);
            Grid.SetColumn(paragraphNumber, 5);
            Grid.SetColumn(btnClose, 6);

            stack.Children.Add(To);
            stack.Children.Add(igual);
            stack.Children.Add(expressionOne);
            stack.Children.Add(and);
            stack.Children.Add(expressionTwo);
            stack.Children.Add(comma);
            stack.Children.Add(paragraphNumber);
            stack.Children.Add(btnClose);
            stack.Tag = i;
            grid.Children.Add(stack);
            items.Add(stack);
            Grid.SetRow(stack, i);
        }


        void RemoveRow(object sender, RoutedEventArgs e)
        {
            i--;
            var row = Grid.GetRow((Button)sender);
            var tag = ((Button)sender).Tag.ToString();
            
            foreach(var child in grid.RowDefinitions)
            {
                var t = child.Tag.ToString();
                if (tag.Equals(t))
                {
                    grid.RowDefinitions.Remove(child);
                    break;
                }
            }

            foreach (StackPanel child in grid.Children)
            {
                var t = child.Tag.ToString();
                if (tag.Equals(t))
                {
                    grid.Children.Remove(child);
                    break;
                }
            }
            try
            {
                Grid.SetRow(stack, i - 1);
            }
            catch { i = 0; }
           
        }
    }

  
}
