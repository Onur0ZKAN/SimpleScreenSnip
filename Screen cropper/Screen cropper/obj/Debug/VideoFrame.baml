   M S B A M L   `   `   `  ����I  EScreen cropper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Screen_cropperScreen_cropper  5   	       Screen_cropper.VideoFrame   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Screen_cropper     5   	   -   5        }�.    � Title$  SnippedWindow��5   	    � AllowsTransparency .  � WindowStyle$
 None=�6:    J� Opacity$ 1Q�6M   ���#0000 � ShowInTaskbar .   J� 	AllowDrop .  � 	Resources 5         SaveFade �� TargetProperty W� From		 W� To
 g� Duration  	SaveFade2��%�   &	        &	 h     �� 5   
   $ Opacity�6&   .��5      W� $ 1X�6   $	 0X�6'   $
 0:0:0.7D�6.   5      �� 5   
   $ Opacity�6'   .��5      W� $	 0.8X�6   $	 0X�6)   $
 0:0:0.5D�60   5      5      .��5      � }�.  .+�5   
   �� -   5        $��ImageContainer��5      $��25,60,25,25q�6'   $��1q�6<   ���#f33 �� CornerRadius$ 1��6c   ._�5      �� $��1q�6   ���#000 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5          
BlurRadius$ 25Q�6'      	Direction$	 -90Q�67      RenderingBias$ Quality=�6G      ShadowDepth$ 2Q�6_   ._�5"      � .+�5#      �� -   5        $��CroppedImage��5#      5$      5%      5'      �� 5)   
   -   5        $��ToolsContainer��5)   &   }�.  $	��240��6<   ���#000$��1q�6[   
�������$��35��6�   $��Center=�6�   $	��Top=�6�   ._�5+      �� $��	10,5,10,5q�6   }�.   �� Orientation$ 
Horizontal=�6B   .+�5-      �� -   5        $��WndName��5-      $	��125��6)   $��0,2,5,0q�65   $��20��6F   �� 5/      -   5        $��Start��5/      $��25��6=   $
��Auto��6H   $��0,0,5,0q�6V   $��16(�6g   $��Right=�6u   $��SemiBold"�6�   $��Stretch=�6�   $��0,-3,0,0q�6�   ��50      �� 51      $��0,2,0,0q�6   $ 5��6.   $��10��6?   $��10��6J   
���   �53      55      �� 57      -   5        $
��Stop��57      $��25��6;   $
��Auto��6F   $��0,0,5,0q�6T   $��16(�6e   $��Right=�6s   $��SemiBold"�6�   $��Stretch=�6�   $��0,-3,0,0q�6�   ��58      �� 59      $��0,2,0,0q�6!   $��10��62   $��10��6=   
���   �5;      5=      �� 5@      -   5        $��25��5@      $��0,0,0,0q�64   $��x��6E   $��22(�6Q   $��Right=�6_   $��Stretch=�6{   $��	-1,-8,0,0q�6�   5C      5E      �� 5G   
   -	   5         ��Name$ SaveNoterBorder2��5G   *    J� IsHitTestVisible .  $��25,60,25,25q�6D   $ 0Q�6Y   ���#30f05I      �� 5K   
   -
   5        $ SaveNoterBorder��5K   *    .  ���#030���#0c0$��1q�6h   $ 1��6|    J� SnapsToDevicePixels . $ 0Q�6�   $��	0,0,0,100q�6�   $��Center=�6�   $��Bottom=�6�   $��50��6�   $	��100��6  ._�5L      �� $��SAVED��6   $��20(�6%   $��Center=�63   $��Center=�6P   ���#0f06k   5M      5O      5Q      