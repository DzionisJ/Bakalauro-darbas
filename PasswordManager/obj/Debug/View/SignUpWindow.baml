   M S B A M L   `   `   `  ����J  FPasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PasswordManager.ViewModelPasswordManager.ViewModel  5   	   '    !PasswordManager.View.SignUpWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PasswordManager.ViewModel     5   	     � Title$  SignUpWindow��5   	   
���   �$	��400��63   $	��450��6@    � 	Resources 5      /  )PasswordManager.ViewModel.SignupViewModel   SignUpDataModel��%   &	          5   
   6    5      .��5      �� 
�������$��35,37,35,38.8q�6#   ._�5   
   �� 
�������$��20q�6k    � DataContext 6   ��  �� Source# [  .+�5      �� $��Create an Account��6   
���   �$��25(�6C   $��Center=�6Q   6p   �� 5      6   �� 5      $��Email��6   
���   �69   �� 5      -   5         ��Name$ txtUsername��5      
�������
���   �$��18(�6V   ��6d   ��  �� Path$ txtUsername� �� Mode$ TwoWay=�6�   �� 5      $��Password��6   
���   �6<   �� 5      -   5        $ txtPassword��5      
�������
���   �$��18(�6U   $0��*pack://application:,,,/Resources/#password)�6�   ��6c   �� $ txtPassword�$ TwoWay=�6�   �� 5      -   5        $��	btnSubmit��5      $��Submit��6&   $��60 10q�67   
���   �
�������$��18(�5   (   ��66   �� *SignupCommand+�� 5      -   5        $��backToLoginWindow��5      $��60 10q�6.   
���   �$��18(�6P   
�������.��6�   Already have an account?6�   5      5      5      