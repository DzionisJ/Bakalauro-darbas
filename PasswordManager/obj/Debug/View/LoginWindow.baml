   M S B A M L   `   `   `  ����J  FPasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PasswordManager.ViewModelPasswordManager.ViewModel  5   	   &     PasswordManager.View.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PasswordManager.ViewModel     5   	     � Title$  Login��5   	   
���   �$	��400��6*   $	��450��67    � 	Resources 5
      .  (PasswordManager.ViewModel.LoginViewModel   LoginDataModel��%   &	          5   
   6   5      .��5      �� 
�������$��35,37,35,38.8q�6#   ._�5   
   �� 
�������$��20q�6j    � DataContext 6   ��  �� Source# [  .+�5      �� $��Welcome��6   
���   �$��25(�69   $��Center=�6G   6f   �� 5      6   �� 5      $��Email��6   
���   �69   �� 5      -   5         ��Name$ txtUsername��5      
�������
���   �$��18(�6V   ��6d   ��  �� Path$ txtUsername� �� Mode$ TwoWay=�6�   �� 5      $��Password��6   
���   �6<   �� 5      -   5        $ txtPassword��5      
�������
���   �$��18(�6V   $0��*pack://application:,,,/Resources/#password)�6�   ��6d   �� $ txtPassword�$ TwoWay=�6�   �� 5      -   5        $��	btnSubmit��5      $��Submit��6&   $��60 10q�67   
���   �
�������$��18(�5   (   ��66   �� *LoginCommand+�� 5      -   5        $��create_acc_button��5      $��18(�6.   $��60 10q�6<   
���   �
�������.��6�   Create an account6�   5      5      5      