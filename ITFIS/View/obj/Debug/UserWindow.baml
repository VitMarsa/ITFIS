   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView  5   	   clr-namespace:ViewView  5   	       View.UserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:View     5   	   &localUCclr-namespace:View     5   	   -   5          � Title$  ITFIS��5	   	   $	��750��6   $
��1200��6$   $	��750��61   $
��1200��6A   
������� � Icon$ Images/logo.png��6d    � WindowStartupLocation$ CenterScreen=�6{   .��5      � .+�5   
   �� $��Stretch=�6   $��Stretch=�64   
������� � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName��%�  '��       �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6.   .R�5   "   � $��Panel��6'   .+�5   &   �� $ ContentSite��67   $��Center=�5   )   $��Center=�5   )   $��Header��5   )   $
��10,2q�5   )   5   #   	 5   "   P� 5   &   
 �@��
IsSelected . . �5   *   �� $ Panel��61    � �� �	#FFC6E3FD6Z   5   '   P� 5   &   
 �@��
IsSelected .  . �5   *   �� $ Panel��61    � ��
 �����6Z   5   '   5!      5#      �� 5$       � ��$ 16(�61   �� 5%       � ��$ Garamond)�63   �� 5&       � ��$
 Bold"�63   �� 5'       � ��$	 175��6.   �� 5(       � y�$ 	Collapsed=�63   5)      5*      .@�5+      �� -   5        $��userAboutTab��5+      $��O mně��6*   .��5,         View.UserAbout  -   5          Name$ 	userAbout��5,   $   5-      �� 5.      -   5        $��adminUserTab��5.      $��Správa uživatelů��6+   .��5/         View.AdminUserControl  -   5          Name$ 	adminUser��5/   +   50      �� 51      -   5        $��adminCourseTab��51      $��Správa kurzů��6,   .��52         View.AdminCourseControl  -   5          Name$ adminCourse��52   -   53      �� 54      -   5        $��lectorOverviewTab��54      $��Studenti a hodnocení��6/   .��55         View.LectorOverview  -	   5          Name$ lectorOverview��55   )   56      �� 57      -
   5        $��userOverviewTab��57      $��Kurzy a hodnocení��6-   .��58         View.UserOverview  -   5          Name$ userOverview��58   '   59      �� 5:      -   5        $��userRegistrationTab��5:      $��
Registrace��61   .��5;         View.UserRegistration  -   5          Name$ userRegistration��5;   +   5<      5=      5>      5?      