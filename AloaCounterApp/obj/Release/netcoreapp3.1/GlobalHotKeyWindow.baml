   M S B A M L   `   `   `  ����   AloaCounterApp     WpfApp1.GlobalHotKeyWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Delete Counter��   GrayBackground#���    � 	Resources  �� Color��%   &	        �� $
 Gray��.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $	��200 �.+��� -    ��Name$ warningCrashLabel��$��0��$��0��$��2��$��Center=�$m��gSome combinaison will crash and idk exactly which ones. ¯\_(ツ)_/¯  Basic hotkeys should work though��$��14(�$
��Bold"�$��Segoe UI)��� -   $ 	nameLabel��$��1��$��0��$k��eModifier to hold with the key (Choose none if you don't want a modifier otherwise Update wont work) :��$��10(�$
��Bold"�$��Segoe UI)��� -   $ 
countLabel��$��2��$��0��$-��'Key to press to increment the counter :��$��10(�$
��Bold"�$��Segoe UI)��� -   $ 
resetLabel��$��3��$��0��$��2��$U��OClick Update with one or both of the boxes above empty to have no Hotkey active��$��10(�$
��Bold"�$��Segoe UI)��� -    ��Name$ modifiersComboBox��$��1��$��1�� �� Text$ Choose modifier���� -   $ keysComboBox��$��2��$��1��$ 
Choose key���� -    ��Name$ updateButton��$��3��$��0��$��2��$��Update��$��10(�$
��Bold"�$��Segoe UI)�$��	550,0,0,0q�