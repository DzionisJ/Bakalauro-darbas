   M S B A M L   `   `   `  ����J  FPasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PasswordManager.ViewModelPasswordManager.ViewModel  5   	        PasswordManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6vm'clr-namespace:PasswordManager.ViewModel     5   	     � Title$  Manager��5   	   $	��450��6   $	��900��6&    � 
ResizeMode$ NoResize=�62   
������� � 	Resources 5      -  'PasswordManager.ViewModel.DataViewModel   Info  HeaderStyleE �� 
TargetType&   System.Windows.Controls.DataGrid �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%A  &	        &	      '  k       5   
   6*   �� 5   
   "  6%   .�5      ��  �@ ColumnHeaderStyle# �  62   5      �� 5   
   "  6   .�5      ��  � ��$ 30��6'   �� 5       � ��
 �   �6+   �� 5       � ��
 �����6+   �� 5       � ��$ 18(�6)   5      5      .��5      � }�. 
�������$��	0,0,3.6,0q�66    � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5!   
   �� 5"      $��10 �6   �� 5#      $
��auto �6   �� 5$      $
��auto �6   �� 5%      $
��auto �6   �� 5&      $
��auto �6   �� 5'      $
��auto �6   �� 5(      $
��auto �6   �� 5)      $
��auto �6   �� 5*      $
��auto �6   �� 5+      $
��auto �6   �� 5,      $
��auto �6   �� 5-      $
��auto �6   �� 5.      $��* �6   .+�51   
   �� -   5         ��Name$ HeaderNewData��51      $��Add new Data��6+   $��1��6?   $��1��6M   $��24(�6]   6m   �� 52   
   -   5        $ EmailUsername��52      $��14(�6+   $��Email/Username��69   $��2��6O   $��1��6\   $��0,10,0,0q�6l   �� 53   
   -   5        $��Emailbox��53      $	��250��6"   $��3��6.   $��14(�6;   $��1��6J   $��0,10,0,0q�6�   ��6Z   �� *STUFF.AccEmail+	 �� Mode$	 TwoWay=�6�   �� 54   
   $��Password��6   $	��250��6$   $��4��61   $��14(�6>   $��1��6M   $��0,10,0,0q�6]   �� 55   
   -   5        $��PassBox��55      $	��250��6"   $��5��6.   $��1��6;   $��14(�6K   $��0,10,0,0q�6�   ��6Z   �� *STUFF.AccPassword+$	 TwoWay=�6�   �� 56   
   $��Website��6   $	��250��6#   $��6��60   $��1��6>   $��14(�6N   $��0,10,0,0q�6]   �� 57   
   -   5        $��
WebsiteBox��57      $	��250��6$   $��7��61   $��1��6>   $��14(�6N   $��0,10,0,0q�6�   ��6]   �� *STUFF.AccWebsite+$	 TwoWay=�6�   �� 58   
   -   5        $��EnterNewData��58      
���   �$��8��68   $��1��6E   $��14(�6U   
�������$��0,10,0,0q�6�   ��6x   �� *SubmitNewDataCommand+.��6�   Submit6�   �� 59   
   -   5        $��	ExportCSV��59      $��9��6"   
���   �$��1��6C   $��14(�6S   
���������6v   �� *SubmitCSVExportCommand+.��6�   Export CSV Format6�   �� 5:   
   -   5        $��Password_Generator��5:      $��10��6+   
���   �$��1��6M   
�������$��14(�6q   .��6�   Password Generator6�   �� 5;   
   -	   5        $��Username_generator��5;      $��1��6+   $��11��6;   
���   �
�������$��14(�6p   .��6�   UserName Generator6�   � 5?   
   $��4.8,0.4,0.4,177q�6   $��12��6)   $��2��6;   $��1��6K   .+�5B        -
   5        
  Name$
 MainDataGrid��5B      #���  6W      AlternatingRowBackground
 ��ح�   AutoGenerateColumns .     SelectionUnit$
 Cell=�5C   .   $��0,0,0.6,-83q�6C   ��5B   -   �� *list+$	 OneWay=�   RowStyle 5E      �� 5F      )  #System.Windows.Controls.DataGridRow"  6   .�5G      ��  �@J�SnapsToDevicePixels . 6@   �� 5H       � ��
 �����67    �� Triggers 5I      P� 5J       P� Property �@ AlternationIndex P� Value$ 1��6B   . �5K   "   ��  � �� �	#FFD0D0E06?   5L      P� 5M       �@J�IsMouseOver . . �5N   "   ��  � �� �#F9F99F6?   5O      P� 5P       �@=�HasError . . �5Q   "   ��  �@J�Effect 5R   &   3  -System.Windows.Media.Effects.DropShadowEffect  5S   *      Color$ 	#FFB61111��6;      ShadowDepth$ 0Q�6M      
BlurRadius$ 20Q�6]   5U   #   5V      5X         Columns 5]      0  *System.Windows.Controls.DataGridTextColumn  5^      ,  &System.Windows.Controls.DataGridColumn   Header$ Email/Username��6)      FontSize$ 14Q�6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� *
AccEmail+  5_      -   5        passcollumn��$  | Password��5_   >   $ 14Q�6U      
FontFamily$0 *pack://application:,,,/Resources/#password)�6c    6�   �� *AccPassword+  5`      $  | Website/App��6)   $ 14Q�6A    6O   �� *
AccWebsite+4	  .System.Windows.Controls.DataGridTemplateColumn	  5b      $  | Hide��6-    	  CellTemplate 5c      �� 5d      .R�5e   "   �� -   5        $��	Show/hide��5e   )   6=   5f      5h      5k      5n      5p      5q      