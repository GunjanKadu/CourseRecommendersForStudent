   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   7 clr-namespace:WpfApp1.PropertiesWpfApp1.Properties  5   
       WpfApp1.Courses   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   1Resx clr-namespace:WpfApp1.Properties     5   
   -   5          � Title$  Courses��5   	   $	��450��6   $	��800��6&    � WindowStartupLocation$ CenterOwner=�62   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��261* �6   �� 5      $
��532* �6   .+�5   
   � $	��450��6   $	��Top=�6   ���	#FFFCFCFC$��2��6K   $��0,0,0.333,-29.333q�6_   .+�5      �� $��260,10,0.333,0q�6   ���	#FFB20837 J� OpacityMask
 �   �$	��Top=�6]   $	��412��6u   .+�5      �� $��10,0,-0.667,0q�6    �� Orientation$ Vertical=�64    � DataContext 6K   ��  �� ElementName$ List_Courses�� �� Path$ SelectedItem�.+�5      �� -   5         ��Name$ CourseTitle��5       $
��Bold"�6L   $��0,10,0,0q�6^   $��18(�6p   $��36��6~   
�������$��Center=�6�   ��65   �� *Title+6�   5      �� 5      -   5        $��Txt_Select_Course_Hint��5      $y�Visible=�6:   "   WpfApp1.Properties.Resources	   hintSelectCourse#��Z	 6O   
�������$��10,150,10,0q�6�   $
��14.5(�6�   $
��Bold"�6�   $��Center=�6�   
 �� TextAlignment$
 Center=�6�   $	��512��6�   �� 5      -   5        $��Img_Left��5      $��Img/left.png��6(   $��30��6>   $��30��6J    J� RenderTransformOrigin$ 
-3.8,0.633&�6U   $��-440,-22,0,0q�6x   �� 5"      -   5        $��Stack_Select_Topic��5"      $y�	Collapsed=�67   $��10,0,10.333,30q�6O   $ 
Horizontal=�6g   $��27��6�   .+�5#      �� $
��Left=�6    $
��Wrap=�6;      selectTopic#��Z 6O   $	��Top=�6|   $��22��6�   ���	#FFFBF3F3$
��Bold"�6�   $��30,0,0,0q�6�   $	��164��6�   �� 5$      -   5         ��Name$ Cmbx_CourseTopics��5$      $��
10 0 0 05 q�6:   $	��248��6�   $ 0.5,0.5&�6�   z�5%      V� 5&      .~�5'   "   �� �� 5(   "   �� 5)   "    �� Angle$ 0.301Q�62   T� 5*   "   5+      5-      5.      50      �� 52      -   5        $��Rect_Divider��52      $y�	Collapsed=�6,   ���	#FFF4F4F5
���   �$��260,81,0,365q�6c   �� 55      -   5        $��Course_Image��55      $��309,164,297,158q�6(   �� 56      -	   5        $ Txt_CourseDesc��56      $
��Wrap=�60   $��524,138,36,57q�6D   ���	#FFFEFEFE$��12(�6r   $
 Justify=�6�   �� 5>      -
   5        $��List_Courses��5>      $
��Left=�6*   $	��341��6E   $��Bottom=�6R   $	��246��6m   $��5,0,0,28q�6�   $��11(�6�   ��6y   Z� ��5?      �� 5@      .R�5A      � $	��0,2q�6    5B      �� 5C   "   $��* �63   �� 5D   "   $	��100 �63   .+�5F      �� $��	0,10,0,10q�6(   
���   �$
��Bold"�6e   ��6;   �� *Title+6e   5G      5H      5J      5L      �� 5O   
      searchYourFavCourse#��Z 6   $��
8,10,0,352q�6I   $��10(�6]   
�������$
��Bold"�6�   $
��Left=�6�   $��20��6�   �� 5P   
   -   5        $��Course_Filter��5P   -   $
��Left=�6   $��23��6l    �� TextWrapping$
 Wrap=�6x   $	��Top=�6�   $	��245��6�   $��6,42,0,0q�6�   �� 5Q   
   $��228,38,10,340q�6   $��15��6'   $��15��63   $��Img/Search.png��6>   $
��Fill=�6V   $ -0.568,0.457&�6e   5T      5U      