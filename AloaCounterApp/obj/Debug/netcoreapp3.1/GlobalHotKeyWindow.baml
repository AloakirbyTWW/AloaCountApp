   M S B A M L   `   `   `  ����  AloaCounterApp     WpfApp1.GlobalHotKeyWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Delete Counter��5   	      GrayBackground#���   5   	    � 	Resources 5       �� Color��%(   &	        �� 5   
   $
 Gray��61   5      .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��200 �6   .+�5   
   �� -   5         ��Name$ warningCrashLabel��5   ^   $��0��6   $��0��6   $��2��6-   $��Center=�6A   $m��gSome combinaison will crash and idk exactly which ones. ¯\_(ツ)_/¯  Basic hotkeys should work though��6y   $��14(�6�   $
��Bold"�6�   $��Segoe UI)�6  �� 5   
   -   5        $ 	nameLabel��5   -   $��1��6   $��0��6   $k��eModifier to hold with the key (Choose none if you don't want a modifier otherwise Update wont work) :��6@   $��10(�6�   $
��Bold"�6�   $��Segoe UI)�6�   �� 5   
   -   5        $ 
countLabel��5   -   $��2��6   $��0��6   $-��'Key to press to increment the counter :��6A   $��10(�6s   $
��Bold"�6�   $��Segoe UI)�6�   �� 5   
   -   5        $ 
resetLabel��5   A   $��3��6   $��0��6   $��2��6-   $U��OClick Update with one or both of the boxes above empty to have no Hotkey active��6U   $��10(�6�   $
��Bold"�6�   $��Segoe UI)�6�   �� 5   
   -   5         ��Name$ modifiersComboBox��5   0   $��1��6   $��1��6     �� Text$ Choose modifier��6K   �� 5   
   -   5        $ keysComboBox��5   0   $��2��6   $��1��6    $ 
Choose key��6F   �� 5   
   -   5         ��Name$ updateButton��5   B   $��3��6   $��0��6   $��2��6.   $��Update��6X   $��10(�6~   $
��Bold"�6�   $��Segoe UI)�6�   $��	550,0,0,0q�6�   5       5!      