   M S B A M L   `   `   `  ����J  FPasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PasswordManager.ViewModelPasswordManager.ViewModel  5   	   2    ,PasswordManager.View.UserNameGeneratorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PasswordManager.ViewModel     5   	     � Title$  Username Generator��5   	   $	��300��6%   $	��800��62   .��5	      �� 
�������.+�5   
   �� -   5        $��Generated_username_box��5      $��24(�6O    �� 
IsReadOnly . ��60   ��  �� Path$ Username�6r   �� 5   
   $��10��6   6"   �� 5   
   -   5        $��generateusername��5      
���   �
�������$��24(�6u   ��6O   �� *SubmitNewUsername+.��6�   
Generate6�   �� 5   
   6   �� 5   
   -   5        $��GenUsrnameLentgh��5      ��6*   �� $ UsrNameLegth�6P   �� 5   
   6   �� 5   
   
��� � �$��14(�6&    d� 	IsChecked 64   �� *CanUseSpecial+ �� Mode$ TwoWay=�.��6f   Avoid special symbols6}   �� 5   
   
��� � �$��14(�6&    64   �� *CanUseUpper+$ TwoWay=�.��6d   Avoid UpperCase6u   �� 5   
   
��� � �$��14(�6&    64   �� *CanUseLower+$ TwoWay=�.��6d   Avoid LowerCase6u   �� 5   
   
��� � �$��14(�6&    64   �� *CanUseDigit+$ TwoWay=�.��6d   Avoid Digits6r   �� 5   
   
��� � �$��14(�6&    64   �� *NoAmobiguossymbols+$ TwoWay=�.��6k   Avoid I, 1, 0 and O6�   5      5      