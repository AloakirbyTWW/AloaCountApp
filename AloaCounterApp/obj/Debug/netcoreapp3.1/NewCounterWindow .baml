   M S B A M L   `   `   `  ����  AloaCounterApp    WpfApp1.NewCounterWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  New Counter��5   	      GrayBackground#���   5   	    � 	Resources 5       �� Color��%(   &	        �� 5   
   $
 Gray��61   5      .��5	      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��250 �6   .+�5   
   �� -   5         ��Name$ 	nameLabel��5   -   $��0��6   $��0��6   $4��.Name (try to use valid Windows folder names) :��6@   $��10(�6y   $
��Bold"�6�   $��Segoe UI)�6�   �� 5   
   -   5        $ 
countLabel��5   -   $��1��6   $��0��6   $5��/Starting number (in millie seconds for times) :��6A   $��10(�6{   $
��Bold"�6�   $��Segoe UI)�6�   �� 5   
   -   5        $ nbToAddLabel��5   -   $��2��6   $��0��6   $6��0Increment number (in millie seconds for times) :��6C   $��10(�6~   $
��Bold"�6�   $��Segoe UI)�6�   �� 5   
   -   5         ��Name$ nameTextBox��5   /   $��0��6   $��1��6   6/   �� 5   
   -   5        $ countTextBox��5   /   $��1��6   $��1��6   6/   �� 5   
   -   5        $ nbToAddTextBox��5   /   $��2��6   $��1��6   6/   �� 5   
   -   5         ��Name$ create��5   B   $��3��6   $��0��6   $��2��6.   $��Create��6R   $��10(�6x   $
��Bold"�6�   $��Segoe UI)�6�   $��150,0,150,0q�6�   5       5!      