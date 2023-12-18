using System;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		//Инициализируем переменные класса
        int numb = 0; //Элемент массива мебели
        Vector relativeMousePos; // Координаты мыши
        FrameworkElement draggedObject; //Элемент движения(наша мебель), которая апкастнута до класса FrameworkElement
        List<Border> Mebel = new List<Border>(); //Массив с нашей мебелью
        public MainWindow()
        {
            InitializeComponent();
        }

		//Функция захвата изображения
        void StartDrag(object sender, MouseButtonEventArgs e)
        {
            draggedObject = (FrameworkElement)sender;//Приравниваем к элементу движения инициализированному выше объект, который подписан на эту функцию и отправил
			//запрос на начало функции
            relativeMousePos = e.GetPosition(draggedObject) - new Point();//Задаём ккординаты мыши
            draggedObject.MouseMove += OnDragMove; //Подписываемся на функцию движения объекта мышкой
            draggedObject.LostMouseCapture += OnLostCapture;//Подписываемся на сброс фокуса
            draggedObject.MouseUp += OnMouseUp; //Подписываеся на событие поднятия кнопки мыши вверх
            Mouse.Capture(draggedObject);//Запускаем функцию Capture на нашей мышке, передавая туда элемент движения(для работы с элементом, на который мы кликнули)
        }

		//Функция движения
        void OnDragMove(object sender, MouseEventArgs e)
        {
            UpdatePosition(e); //Вызывает функцию обновления позиции, в зависимости от координат мыши.
        }

		//Функции обновления позиции
        void UpdatePosition(MouseEventArgs e)
        {
            var point = e.GetPosition(mainField);//Получаем координаты мыши отностилеьно всей формы
            var newPos = point - relativeMousePos;//Задаём новые координаты(координаты мыши относительно Canvas
            Canvas.SetLeft(draggedObject, newPos.X);//Передаём горизонтальные координаты в Canvas
            Canvas.SetTop(draggedObject, newPos.Y);//Передаём вертикальные координаты в Canvas
        }

		//Функция поднятия кнопки мыши
        void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            FinishDrag(sender, e);//Вызываем функцию окончания переноса
            Mouse.Capture(null);//Запускаем функцию Capture на нашей мышке, передавая туда null, чтобы сбросить объект, с которым мы работаем
        }
		
		//Функция сброса фокуса
        void OnLostCapture(object sender, MouseEventArgs e)
        {
            FinishDrag(sender, e);//Вызываем функцию прекращения захвата изображения, передавая туда наш элемент по подписке и свойства мыши (e)
        }

		//Функция прекращения захвата изображения
        void FinishDrag(object sender, MouseEventArgs e)
        {
			//Отписываемся от всех функций, на которые подписывались в StartDrag
            draggedObject.MouseMove -= OnDragMove;
            draggedObject.LostMouseCapture -= OnLostCapture;
            draggedObject.MouseUp -= OnMouseUp;
            UpdatePosition(e);//Последний раз обновляем позицию картинки перед сбросом
        }

		//Функция фокуса на элементе для рисования рамки вокруг выбранного элемента
        private void getFocusOnObject(object sender, MouseButtonEventArgs e)
        {
            LostBorder(Mebel[numb]);//Вызываем функцию сброса рамки, передавая туда элемент
            Border figura = sender as Border;//Получаем сам элемент
            numb = int.Parse((string)figura.Tag);//Получаем тэг этого элемента и превращаем в int, чтобы обраттиься к списку всех элементов по индексу
            DrawBorder(Mebel[numb]);//Рисуем рамку вокруг выбранного элемента
        }

		//Функция удаления объекта оп нажатию правой кнопки мыши
        private void killObject(object sender, MouseButtonEventArgs e) 
        {
            Border figura = sender as Border; //Получаем сам элемент
            numb = int.Parse((string)figura.Tag);//Получаем тэг этого элемента и превращаем в int, чтобы обраттиься к списку всех элементов по индексу
            Mebel.Remove(Mebel[numb]);//Удаляем из списка всех элементов
            mainField.Children.Remove(figura);//Удаляем с Canvas
        }
        
        private void Add(object sender, RoutedEventArgs e)//добавление
        {
            string str = "";//Инициализируем строку пути к элементу
			
			//Проверяем какой элемент из списка выбран и присваемваем путь к картинке
            if ((bool)RefrigeratorRB.IsChecked) str = "pics/1.png";
            if ((bool)FireRB.IsChecked) str = "pics/2.png";
            if ((bool)WaterRB.IsChecked) str = "pics/3.png";
            if ((bool)BoxRB.IsChecked) str = "pics/4.png";
            if ((bool)TableRB.IsChecked) str = "pics/5.png";

            AddPattern(str);//Вызываем функци добавления по паттерну
        }

		//Функция рисования рамок
        private void DrawBorder(object sender)
        {
            var b = (Border)sender;//получаем элемент
            b.BorderThickness = new Thickness(1);//Задаём ему свойство толщины границ равным 1 пикселю
        }

		//Функция убирания рамок
        private void LostBorder(object sender)
        {
            var b = (Border)sender;//получаем элемент
            b.BorderThickness = new Thickness(0);//Задаём ему свойство толщины границ равным 0 пикселей, т.е. убираем
        }
        
		//Функция добавления на Canvas по паттерну
        private void AddPattern(string pattern)
        {
            var myBrush = new ImageBrush();//Инициализируем кисть для рисования
            var border = new Border//Инициализируем границу 
            {
                BorderBrush = Brushes.Aqua,//задаём границе цвет
                BorderThickness = new Thickness(0)//и толщину. Изначально равную 0, т.к. только добавленный элемент не выбран
            };
            var SomeImg = new Image//Инициализируем картинку
            {
                Source = new BitmapImage(new Uri(@pattern, UriKind.Relative)),//передаём путь полученный в функци Add, чтобы нарисовать картинку
                Width = 100,//Задаём ширину
                Height = 100,//И высоту
            };
            border.Child = SomeImg;//Добавляем картинку в дочерние элементы к границе
            Mebel.Add(border);//Добавляем картинку в массив картинок
            border.Tag = (Mebel.Count - 1).ToString();//Задаём ей тэг с равным её индексу
            myBrush.ImageSource = SomeImg.Source; //Рисуем картинку кистью инициализированной выше
            border.MouseLeftButtonDown += new MouseButtonEventHandler(getFocusOnObject); //Подписываем на функцию рисования рамки
            border.MouseLeftButtonDown += new MouseButtonEventHandler(StartDrag);//Подписываем на фукнцию начала захвата
            border.MouseRightButtonDown += new MouseButtonEventHandler(killObject);//Подписываем на функцию удаления объекта
            Canvas.SetLeft(border, 100);//Задаём нашей картинке координаты на Canvas по горизонтали
            Canvas.SetTop(border, 100);//и по вертикали
            mainField.Children.Add(border);//И добавляем на сам Canvas
        }

		//Функция перемещения слайдера изменения градуса поворота
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(Mebel.Count != 0)//Проверяем есть ли у нас хоть один элемент
            {
				//Если есть
                RotateTransform rotate = new RotateTransform(AngleSlider.Value);//Создаём объект поворота картинки и передаём туда цифру в градусах(взятую из слайдера)
                rotate.CenterX = 50;//Указываем центр (50;50), т.к. наша картинка 100x100 и её центр находится в (50;50)
                rotate.CenterY = 50;
                AngleTextValue.Content = AngleSlider.Value.ToString()+ "°";//Изменяем текст картинки на значения градусов на слайдере
                Mebel[numb].RenderTransform = rotate;//Поворачиваем нашу картинку
            }
        }
    }

}
