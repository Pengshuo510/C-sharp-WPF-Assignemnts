   M S B A M L   `   `   `  ����I  EPopulationDBMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PopulationDBMSPopulationDBMS  5   	       PopulationDBMS.EditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PopulationDBMS     5   	     � Title$  Edit Population��5	   	   $	��150��6!   $	��300��6.    � WindowStartupLocation$ CenterOwner=�6:    � 
ResizeMode$ NoResize=�6^   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $��0��6   $
��City��6-   $��12(�6<   $��Center=�5      $��Right=�62   $��5q�6U   6b   �� 5   
   $��1��6   $��0��6   $��
Population��6-   $��12(�6B   $��Center=�5      $��Right=�62   $��5q�6U   6b   �� 5   
   -   5        $��txtCity��5      $��0��6!   $��1��6.   $��5q�6>   ��6I   �� *City+6a   �� 5   
   $��1��6   $��1��6   $��5q�6/   ��6:   �� *PopulationNum+6[   �� 5   
   $��5��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Right=�6K   .+�5      �� -   5        $
��Save��5      $
��Save��6!   $��5q�60   $��75��6;   6I   �� 5      -   5        $��Cancel��5      $��Cancel��6#   $��5q�64   $��75��6?   6M   5      5      5       