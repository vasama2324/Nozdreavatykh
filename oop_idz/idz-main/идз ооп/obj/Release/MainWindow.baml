   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3      WpfApp3.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp3       � Title$%  Планировка кухни�� � WindowStyle$ SingleBorderWindow=�$	��450��$	��810��$	��800��$	��450��$	��810��$	��450��
�������.���  � ColumnDefinitions �� $	��60* ��� $
��611* ��� $
��139* �.+��� 
���   �$��10q� �� CornerRadius$ 10��$��3��$��	0,0,139,0q�._��� -    ��Name$ 	mainField��
�������|�. $	��656��$	��419��}�. � $
��Left=�$	��409��$	��Top=�$	��121��$��2��$��5,10,0,0q�.+��� $
��Left=�$	��117��$��Bottom=�$	��111��$��
10,0,0,282q�.@�	� -    	�Name$ RefrigeratorRB��$��Холодильник��$
��Left=�$	��Top=�
������� d� 	IsChecked$
 TrueY�	� -   $ FireRB��$��
Плита��$
��Left=�$	��Top=�
�������	� -   $ WaterRB��$��Рукомойник��$	��101��	� -   $ TableRB��$��Стол��$	��101��	� -   $ BoxRB��$��Шкаф��$	��101���� -   $��Добавить��$��56�� �� Left$	 669��
 �� Top$	 149��$��18,139,10,214q��� -   	 ��Name$	 AngleSlider��$��Center=�$��	0,215,0,0q�$	��Top=�$	��101��
 � Maximum$	
 360Q��� $	��0°��$��10,233,90,0q�$	��Top=� J� RenderTransformOrigin$ 
0.623,0.31&��� $��360°��$
��Left=�$��
85,233,0,0q�$	��Top=��� $��	Угол:��$
��Left=�$��
37,284,0,0q�$	��Top=��� -	    ��Name$ AngleTextValue��$	��0°��$��68,283,19,0q�$	��Top=�