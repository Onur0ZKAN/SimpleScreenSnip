   M S B A M L   `   `   `  ����I  EScreen cropper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Screen_cropperScreen_cropper  5   	       Screen_cropper.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Screen_cropper     5   	   -   5          � Title$  
MainWindow��5   	   $��131.974��6   $��154.153��6-    � WindowStyle$
 None=�6=    � AllowsTransparency . ���#0000 J� Opacity$ 1Q�6}    � Icon$ scss.png��6�    J� 	AllowDrop . .��5
      �� ���#000$��20q�6   $��1q�6+   ���#082 �� CornerRadius$ 1��6R    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 25Q�6   	   	Direction$		 -90Q�6/   
   RenderingBias$
 Quality=�6?      ShadowDepth$ 2Q�6W   ._�5   
   �  � RowDefinitions 5      �� 5      $��10 �6    �� 5      �� 5      $��5 �6    �� 5      $
��0.5* �6    �� 5      $��17 �6     � ColumnDefinitions 5      �� 5      $��5 �6#   �� 5      �� 5      $��5 �6#   �� 5      �� 5      $��5 �6#   �� 5      �� 5      $��5 �6#   .+�5!      �� -   5        
���   �
���   ����#cfc$��20(�5!   a   $��0,-6,0,0q�6o   $��1��6�   $��1��6�   $��30��6�   $��30��6�   .��6�   +5#      d� 5$      -   5         d�Name$ 	Serialing��5$   B   
���   �
���   �$
��Bold"�6U    d� 	IsChecked$ FalseY�6g   $��16(�6y   ���#cfc$��0,-3,0,0q�6�   $��1��6�   $��3��6�   $��30��6�   $��30��6�   .��6�   S5&      �� 5'      -   5        
���   �
���   ����#cfc$��20(�5'   ]   $��0,-6,0,0q�6k   $��1��6~   $��5��6�   $��30��6�   $��30��6�   .��6�   x5)      �� 5+      $��3��6   $��1��6%   $��5��65   $��12(�6I   $��Center=�6W   $
��Bold"�6r   ���#0f0$��Center=�6�   $��Screen snip tool��6�   �� 5,      $��4��6   $��5��6%   $	��Top=�65   $��Right=�6M   $��0,0,3,0q�6i   ���#0f0$��10(�6�   $��v1.5 ��6�   5-      5.      5/      