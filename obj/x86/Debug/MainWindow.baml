   M S B A M L   `   `   `  ����T  PDiscreteGestureBasics-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:Microsoft.Samples.Kinect.DiscreteGestureBasics.Microsoft.Samples.Kinect.DiscreteGestureBasics  5   	   ?    9Microsoft.Samples.Kinect.DiscreteGestureBasics.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Nlocal<clr-namespace:Microsoft.Samples.Kinect.DiscreteGestureBasics     5   	   -   5          � Title$$  Kinect Quadrotor Control Panel��5   	   $	��650��5   	   $
��1305��6    � 	Resources 5         MediumGreyBrush �� Color  KinectPurpleBrush  KinectBlueBrush  KinectWhiteBrush �� DataTypeF   @Microsoft.Samples.Kinect.DiscreteGestureBasics.GestureResultView � RowDefinitions �� StringFormat��%?  &	        &	 #     &	 F     &	 i     (�� �     5      *, +)�� 5	   
   $ 	#ff6e6e6e��62   �� 5
   
   $ 	#ff52318f��64   �� 5   
   $ 	#ff00BCF2��62   �� 5   
   $ White��63   �� 5   
   "  6   .R�5      � $
��Auto��6   $��5q�6    ��6+   �� *	BodyColor+ 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��Stretch=�6   $��14(�6v   $��Segoe UI)�6�   $��SemiBold"�6�   $��5q�6�   ��6:   �� *QuadrotorState+$ Status: {0}��6�   �� 5      $��1��6   �� 5      $��18(�6R   $��Segoe UI)�6`   $��SemiBold"�6v   �6   �� *GestureType+$ Movement: {0}��6v    �� 5      $��18(�6N   $��Segoe UI)�6\   $��SemiBold"�6r   �6   �� *	Process+$ Tendancy: {0}��6r   5      5      5      5      .��5      � $��0 0 0 0q�6   ��5   
   �� 5        �� ImageSource$ Images/night.jpg��6    5"   
   �� 5#      $
��Auto �6   �� 5$      $��* �6   �� 5%      $
��Auto �6   .+�5(   
   �� $��0��6   $��Images\Logo.png��6   $
��Left=�66   $
��Fill=�6Q   $��32��6`   $��81��6l   $��0 10 0 5q�6w   �� 5)   
   $��0��6   $��0 0 -1 0q�6!   $��Right=�63   $��Bottom=�6O   #��[ 6j   $��Segoe UI)�6�   $��18(�6�   Quadrotor Control6�   �� 5*   
   $��0��6   $��Images\Status.png��6   $
��None=�68   $��Center=�6G   $��0 0 0 5q�6d   � 5,   
   -   5         �Name$ contentGrid��5,      $��1��6$    � ColumnDefinitions 5-      �� 5.      $��1* �6#   �� 5/      $��1* �6#    51      �� 52      $��7* �6    �� 53      $��1* �6    .+�57      �� 	 �� Orientation$	 Vertical=�6   $��10,10,10,10q�60   $��0��6E   $	��454��6R   $	��Top=�6_   .+�58      (� -   5        
 (�Name$
 kinectBodyViewbox��58      .��59      �� ��6   �� *ImageSource+5:      5;      �� 5<      $��1��6   $
��Left=�6%   $	��468��6@   $��	10,10,0,0q�6M   $	��Top=�6`   $	��619��6x   .+�5=      �� -   5         ��Name$ airplane��5=      $��50��6+    �� Left$	 289��67   
 �� Top$	 206��6I   $��50��6Z   $��Images/whitequad.png��6e   5>      � 5?      $��1��6   $��1��6#    5@      �� 5A      $��* �6'   �� 5B      $��* �6'    5D      �� 5E      $��* �6$   �� 5F      $��* �6$   .+�5H      �� $��0��6   $��0��6)   $��Stretch=�6:   $��18(�6�   $��Segoe UI)�6�   $��SemiBold"�6�   #��[ 6�   ��6X   �� *
Abcsissa+$ X: {0}��6�   �� 5I      $��1��6   $��0��6)   $��Stretch=�6:   $��18(�6�   $��Segoe UI)�6�   $��SemiBold"�6�   #��[ 6�   ��6X   �� *
Ordinate+$ Y: {0}��6�   �� 5J      -   5         ��Name$ Land_Button��5J      $
��Land��6.   $��1��6=   $��0��6M   $
��Left=�6Z   $��Center=�6v   $��75��6�    J� RenderTransformOrigin$ 0.405,0.267&�6�   #���  6�   
�������
����  �6  �� 5K      -   5        $ EmergencyStop��5K      $��EmergencyStop��60   $��1��6H   $��1��6X   $
��Left=�6e   $��Center=�6�   $	��121��6�   #���  6�   
���  ��6�   5L      5M      � 5N   
   $��2��6    5O      �� 5P      $��1* �6#   �� 5Q      $��1* �6#   .+�5S      �� -   5        $��	statusBar��5S   G   $��0��6   $��Stretch=�6)   $��Bottom=�6X   #��[  6s   .@�5T      �� ��6    �� *
StatusText+5U      �� 5V      $��1��6   $8��2Copyright © 2015 Interface Designed by Philip Lin��6*   $��12(�6c   $��Right=�6q   $��Segoe UI)�6�   $��SemiBold"�6�   #��[ 6�   5W      5X      5Y      