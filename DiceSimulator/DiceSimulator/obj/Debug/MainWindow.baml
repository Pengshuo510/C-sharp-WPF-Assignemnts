   M S B A M L   `   `   `  ����H  DDiceSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DiceSimulatorDiceSimulator  5   	       DiceSimulator.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DiceSimulator     5   	     � Title$  Dice Simulator��5	   	   $	��450��6    $	��600��6-   .��5
      � -   5        $��TheGrid��5
       � RowDefinitions 5   
   �� 5      $��3* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   6.   �� 5      $��1* �6   6,   .+�5   
   �� -   5        $
��List��5      $��0��6   $��1��6+   $��5q�5      $��25(�6   5      �� 5   
   $��0��6   $��0��6"    �� Orientation$ Vertical=�5      $��Center=�6,   .+�5      �� -   5        $��
DiceImage1��5      $	��120��6&   $	��120��63   $��20q�6?   6M   �� 5      -   5        $��
DiceImage2��5      $	��120��6&   $	��120��63   $��20q�6?   6M   5      �� 5   
   $��1��6   $��2��6"   $ 
Horizontal=�5      $��Center=�6.   .+�5      �� -   5        $
��DoIt��5      $��1��6!   $��20q�6.   $��35(�6:   $	��150��5      .��64   Do It6;   �� 5      -   5        $
��Save��5      $��1��6!   $��20q�6.   $��35(�6:   $	��150��5       .��64   Save6:   5!      5"      5#      